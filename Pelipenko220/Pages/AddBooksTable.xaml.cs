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
    /// Логика взаимодействия для AddBooksTable.xaml
    /// </summary>
    public partial class AddBooksTable : Page
    {
        public AddBooksTable()
        {
            InitializeComponent();
            DataContext = _currentBook;
        }
        private ИнформацияОКниге _currentBook = new ИнформацияОКниге();
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentBook.Название))
                errors.AppendLine("Укажите название книги!");
            if (_currentBook.Авторы == null)
                errors.AppendLine("Укажите автора книги!");
            if (_currentBook.Издательство == null)
                errors.AppendLine("Укажите издательство книги!");
            if (_currentBook.ГодИздания > 0)
                errors.AppendLine("Укажите год издания книги!");
            if (_currentBook.КолвоСтраниц > 0)
                errors.AppendLine("Укажите количество страниц книги!");
            //Проверяем переменную errors на наличие ошибок
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //Добавляем в объект Cars новую запись
            if (_currentBook.ИнвентарныйНомер == 0)
                библEntities1.GetContext().ИнформацияОКниге.Add(_currentBook);
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
