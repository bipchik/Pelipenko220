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
    /// Логика взаимодействия для AddPassportTable.xaml
    /// </summary>
    public partial class AddPassportTable : Page
    {
        public AddPassportTable(ПаспортныеДанные selectedPassports)
        {
            InitializeComponent();

            if (selectedPassports != null )
                _currentPassports = selectedPassports;

            DataContext = _currentPassports;
        }
        private ПаспортныеДанные _currentPassports = new ПаспортныеДанные();

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentPassports.КемВыдан))
                errors.AppendLine("Укажите кем выдан паспорт!");
            if (_currentPassports.КодПодразделения < 6)
                errors.AppendLine("Код подразделения должен содержать 6 цифр!");

            //Проверяем переменную errors на наличие ошибок
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //Добавляем в объект Cars новую запись
            if (_currentPassports.КодПаспорта == 0)
                Entities.GetContext().ПаспортныеДанные.Add(_currentPassports);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            this.NavigationService.Navigate(new Uri("/Pages/PassportTable.xaml", UriKind.Relative));
        }

        private void KemVidan_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^А-Я]+").IsMatch(e.Text);
        }

        private void SeriaAndNomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Cod_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
