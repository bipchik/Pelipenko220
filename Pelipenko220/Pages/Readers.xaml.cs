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
    /// Логика взаимодействия для Readers.xaml
    /// </summary>
    public partial class Readers : Page
    {
        public Readers()
        {
            InitializeComponent();
            DataGridReaders.ItemsSource = Entities.GetContext().Читатели.ToList();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var ReadersForRemoving = DataGridReaders.SelectedItems.Cast<Читатели>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {ReadersForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Читатели.RemoveRange(ReadersForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridReaders.ItemsSource = Entities.GetContext().Читатели.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void AddEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddReaders((sender as Button).DataContext as Читатели));
        }
        private void GiveBooksTable_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridReaders.ItemsSource = Entities.GetContext().Читатели.ToList();
            }
        }
    }
}