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
            LoadData();
        }

        private void LoadData()
        {
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
                    LoadData();
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
                LoadData();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var query = Entities.GetContext().ПаспортныеДанные.AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchSeriesNumber.Text))
            {
                query = query.Where(p => p.СерияИНомер.Contains(SearchSeriesNumber.Text));
            }

            if (!string.IsNullOrWhiteSpace(SearchDivisionCode.Text))
            {
                query = query.Where(p => p.КодПодразделения.Contains(SearchDivisionCode.Text));
            }

            DataGridPassports.ItemsSource = query.ToList();
        }
    }
}
