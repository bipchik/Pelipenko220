using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;

namespace Pelipenko220.Pages
{
    public partial class GiveBooksTable : Page
    {
        public GiveBooksTable()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataGridGiveBooks.ItemsSource = Entities.GetContext().ВыдачаКниги
                .Include(b => b.ИнформацияОКниге)
                .Include(b => b.Работники)
                .Include(b => b.Читатели)
                .ToList();
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
                    LoadData();
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
                LoadData();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                DataGridGiveBooks.ItemsSource = Entities.GetContext().ВыдачаКниги
                    .Include(b => b.ИнформацияОКниге)
                    .Include(b => b.Работники)
                    .Include(b => b.Читатели)
                    .Where(b => b.ИнформацияОКниге.Название.ToLower().Contains(searchText)
                             || b.Читатели.ФИО.ToLower().Contains(searchText)
                             || b.Работники.ФИО.ToLower().Contains(searchText))
                    .ToList();
            }
            else
            {
                LoadData();
            }
        }
    }
}
