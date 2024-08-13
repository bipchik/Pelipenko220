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
using System.IO; //для осуществления чтения/записи в файл
using System.Diagnostics; //для запуска Блокнота



namespace Pelipenko220.Pages
{
    /// <summary>
    /// Логика взаимодействия для GiveBooksTable.xaml
    /// </summary>
    public partial class GiveBooksTable : Page
    {
        public GiveBooksTable()
        {
            InitializeComponent();
            DataGridGiveBooks.ItemsSource = Entities.GetContext().ВыдачаКниги.ToList();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var GiveBooksForRemoving = DataGridGiveBooks.SelectedItems.Cast<ВыдачаКниги>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {GiveBooksForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().ВыдачаКниги.RemoveRange(GiveBooksForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridGiveBooks.ItemsSource = Entities.GetContext().ВыдачаКниги.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void AddEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddGiveBooks((sender as Button).DataContext as ВыдачаКниги));
        }
        private void GiveBooksTable_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridGiveBooks.ItemsSource = Entities.GetContext().ВыдачаКниги.ToList();
            }
        }


    }
}
