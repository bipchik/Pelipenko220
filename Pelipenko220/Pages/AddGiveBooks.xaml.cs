using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для AddGiveBooks.xaml
    /// </summary>
    public partial class AddGiveBooks : Page
    {
        public AddGiveBooks()
        {
            InitializeComponent();
            DataContext = _currentGiveBook;
        }
        private ВыдачаКниги _currentGiveBook = new ВыдачаКниги();
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentGiveBook.ИнформацияОКниге == null)
                errors.AppendLine("Укажите название книги!");
            if (_currentGiveBook.ИнформацияОЧитателе == null)
                errors.AppendLine("Укажите ФИО читателя!");
            if (GiveDate.SelectedDate == null)
                errors.AppendLine("Укажите дату выдачи книги!");
            else _currentGiveBook.ДатаВыдачи = (DateTime)GiveDate.SelectedDate;
            if (TakeDate.SelectedDate == null)
                errors.AppendLine("Укажите дату возврата книги!");
            else _currentGiveBook.ДатаВозврата = TakeDate.SelectedDate;
            //Проверяем переменную errors на наличие ошибок
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //Добавляем в объект Cars новую запись
            if (_currentGiveBook.ИнвентарныйНомер == 0)
                библEntities1.GetContext().ВыдачаКниги.Add(_currentGiveBook);
            try
            {
                библEntities1.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
