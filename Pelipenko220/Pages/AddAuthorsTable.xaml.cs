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
    /// Логика взаимодействия для AddAuthorsTable.xaml
    /// </summary>
    public partial class AddAuthorsTable : Page
    {
        public AddAuthorsTable(Авторы selectedAuthors)
        {
            InitializeComponent();

            if (selectedAuthors != null)
                _currentAuthors = selectedAuthors;

            DataContext = _currentAuthors;
        }
        private Авторы _currentAuthors = new Авторы();
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentAuthors.ФИО))
                errors.AppendLine("Введите ФИО автора!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //Добавляем в объект Cars новую запись
            if (_currentAuthors.КодАвтора == 0)
                Entities.GetContext().Авторы.Add(_currentAuthors);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
