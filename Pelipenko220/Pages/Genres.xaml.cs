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
    /// Логика взаимодействия для Genres.xaml
    /// </summary>
    public partial class Genres : Page
    {
        public Genres()
        {
            InitializeComponent();
            DataGridGenres.ItemsSource = Entities.GetContext().Жанры.ToList();
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var GenresForRemoving = DataGridGenres.SelectedItems.Cast<Жанры>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {GenresForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Жанры.RemoveRange(GenresForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridGenres.ItemsSource = Entities.GetContext().Жанры.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void AddEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddGenres((sender as Button).DataContext as Жанры));
        }
        private void AuthorTable_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridGenres.ItemsSource = Entities.GetContext().Жанры.ToList();
            }
        }
    }
}