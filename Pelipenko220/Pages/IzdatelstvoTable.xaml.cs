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
    /// Логика взаимодействия для IzdatelstvoTable.xaml
    /// </summary>
    public partial class IzdatelstvoTable : Page
    {
        public IzdatelstvoTable()
        {
            InitializeComponent();
            DataGridIzdatelstvo.ItemsSource = Entities.GetContext().Издательство.ToList();
        }

        private void AddEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddIzdatelstvoTable((sender as Button).DataContext as Издательство));
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var IzdatelstvoForRemoving = DataGridIzdatelstvo.SelectedItems.Cast<Издательство>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {IzdatelstvoForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Издательство.RemoveRange(IzdatelstvoForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridIzdatelstvo.ItemsSource = Entities.GetContext().Издательство.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void IzdatelstvoTable_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridIzdatelstvo.ItemsSource = Entities.GetContext().Издательство.ToList();
            }
        }
    }
}
