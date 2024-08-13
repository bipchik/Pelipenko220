using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
namespace Pelipenko220.Pages
{
    public partial class AddGiveBooks : Page
    {
        public AddGiveBooks(ВыдачаКниги selectedGiveBook)
        {
            InitializeComponent();

            if (selectedGiveBook != null)
                _currentGiveBook = selectedGiveBook;

            DataContext = _currentGiveBook;
            BookNameCmbBox.ItemsSource = Entities.GetContext().ИнформацияОКниге.ToList();
            WorkerCmbBox.ItemsSource = Entities.GetContext().Работники.ToList();
            ReaderCmbBox.ItemsSource = Entities.GetContext().Читатели.ToList();
        }
        private ВыдачаКниги _currentGiveBook = new ВыдачаКниги();
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentGiveBook.ИнформацияОКниге == null)
                errors.AppendLine("Укажите название книги!");
            if (GiveDate.SelectedDate == null)
                errors.AppendLine("Укажите дату выдачи книги!");
            else _currentGiveBook.ДатаВыдачи = (DateTime)GiveDate.SelectedDate;
            //Проверяем переменную errors на наличие ошибок
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //Добавляем в объект Cars новую запись
            if (_currentGiveBook.КодВыдачи == 0)
                Entities.GetContext().ВыдачаКниги.Add(_currentGiveBook);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            this.NavigationService.Navigate(new Uri("/Pages/GiveBooksTable.xaml", UriKind.Relative));
        }
    }
}
