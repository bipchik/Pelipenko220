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
    /// Логика взаимодействия для AddIzdatelstvoTable.xaml
    /// </summary>
    public partial class AddIzdatelstvoTable : Page
    {
        public AddIzdatelstvoTable(Издательство selectedIzdatelstvo)
        {
            InitializeComponent();

            if (selectedIzdatelstvo != null)
                _currentIzdatelstvo = selectedIzdatelstvo;

            DataContext = _currentIzdatelstvo;
            CityCmbBox.ItemsSource = Entities.GetContext().Город.ToList();
        }
        private Издательство _currentIzdatelstvo = new Издательство();

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentIzdatelstvo.Название))
                errors.AppendLine("Укажите название издательства!");
            if (_currentIzdatelstvo.Город == null)
                errors.AppendLine("Выберите город!");

            //Проверяем переменную errors на наличие ошибок
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //Добавляем в объект Cars новую запись
            if (_currentIzdatelstvo.КодИздательства == 0)
                Entities.GetContext().Издательство.Add(_currentIzdatelstvo);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            this.NavigationService.Navigate(new Uri("/Pages/IzdatelstvoTable.xaml", UriKind.Relative));
        }
    }
}
