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
    /// Логика взаимодействия для PassportTable.xaml
    /// </summary>
    public partial class PassportTable : Page
    {
        public PassportTable()
        {
            InitializeComponent();
            DataGridPassports.ItemsSource = Entities.GetContext().ПаспортныеДанные.ToList();
        }

        private void AddEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddPassportTable((sender as Button).DataContext as ПаспортныеДанные));
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var PassportsForRemoving = DataGridPassports.SelectedItems.Cast<ПаспортныеДанные>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {PassportsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().ПаспортныеДанные.RemoveRange(PassportsForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridPassports.ItemsSource = Entities.GetContext().ПаспортныеДанные.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void PasswordTable_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridPassports.ItemsSource = Entities.GetContext().ПаспортныеДанные.ToList();
            }
        }
    }
}
