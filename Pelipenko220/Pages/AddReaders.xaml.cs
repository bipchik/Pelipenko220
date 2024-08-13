using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pelipenko220.Pages
{
    public partial class AddReaders : Page
    {
        private Читатели _currentReader = new Читатели();

        public AddReaders(Читатели selectedReader)
        {
            InitializeComponent();

            if (selectedReader != null)
                _currentReader = selectedReader;

            DataContext = _currentReader;
            PassportCmbBox.ItemsSource = Entities.GetContext().ПаспортныеДанные.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentReader.ФИО))
                errors.AppendLine("Укажите ФИО читателя!");
            if (string.IsNullOrWhiteSpace(_currentReader.Телефон))
                errors.AppendLine("Укажите телефон читателя!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentReader.КодЧитателя == 0)
                Entities.GetContext().Читатели.Add(_currentReader);

            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            this.NavigationService.Navigate(new Uri("/Pages/Readers.xaml", UriKind.Relative));
        }

        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void PassportCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPassport = PassportCmbBox.SelectedItem as ПаспортныеДанные;
            if (selectedPassport != null)
            {
                _currentReader.ПаспортныеДанные = selectedPassport;
            }
        }
    }
}
