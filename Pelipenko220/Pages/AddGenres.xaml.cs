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
    /// Логика взаимодействия для AddGenres.xaml
    /// </summary>
    public partial class AddGenres : Page
    {
        public AddGenres(Жанры selectedGenre)
        {
            InitializeComponent();
            if (selectedGenre != null)
                _currentGenre = selectedGenre;

            DataContext = _currentGenre;
        }
        private Жанры _currentGenre = new Жанры();
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentGenre.Название))
                errors.AppendLine("Введите название города!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //Добавляем в объект Cars новую запись
            if (_currentGenre.КодЖанра == 0)
                Entities.GetContext().Жанры.Add(_currentGenre);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            this.NavigationService.Navigate(new Uri("/Pages/Genres.xaml", UriKind.Relative));
        }
    }
}