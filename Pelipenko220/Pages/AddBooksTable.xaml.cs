using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pelipenko220.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddBooksTable.xaml
    /// </summary>
    public partial class AddBooksTable : Page
    {
        public AddBooksTable(ИнформацияОКниге selectedBook)
        {
            InitializeComponent();

            if (selectedBook != null)
                _currentBook = selectedBook;

            DataContext = _currentBook;
            AuthorCmbBox.ItemsSource = Entities.GetContext().Авторы.ToList();
            GenreCmbBox.ItemsSource = Entities.GetContext().Жанры.ToList();
            IzdatelstvoCmbBox.ItemsSource = Entities.GetContext().Издательство.ToList();
        }
        private ИнформацияОКниге _currentBook = new ИнформацияОКниге();
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentBook.Название))
                errors.AppendLine("Укажите название книги!");
            if (_currentBook.Авторы == null)
                errors.AppendLine("Выберите автора книги!");
            if (_currentBook.Издательство == null)
                errors.AppendLine("Выберите издательство книги!");
            if (_currentBook.ГодИздания < 4)
                errors.AppendLine("Год издания книги должен содержать 4 цифры!");
            if (_currentBook.КолвоСтраниц <= 0)
                errors.AppendLine("Укажите количество страниц книги!");
            //Проверяем переменную errors на наличие ошибок
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //Добавляем в объект Cars новую запись
            if (_currentBook.ИнвентарныйНомер == 0)
                Entities.GetContext().ИнформацияОКниге.Add(_currentBook);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            this.NavigationService.Navigate(new Uri("/Pages/BooksTable.xaml", UriKind.Relative));
        }
        private void Year_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void KolvoStr_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Cost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
