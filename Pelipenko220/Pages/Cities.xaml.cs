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
    /// Логика взаимодействия для Cities.xaml
    /// </summary>
    public partial class Cities : Page
    {
        public Cities()
        {
            InitializeComponent();
            DataGridCities.ItemsSource = Entities.GetContext().Город.ToList();
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var CitiesForRemoving = DataGridCities.SelectedItems.Cast<Город>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {CitiesForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Город.RemoveRange(CitiesForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridCities.ItemsSource = Entities.GetContext().Город.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void AddEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddCities((sender as Button).DataContext as Город));
        }
        private void AuthorTable_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridCities.ItemsSource = Entities.GetContext().Город.ToList();
            }
        }
    }
}