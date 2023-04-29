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
    /// Логика взаимодействия для BooksTable.xaml
    /// </summary>
    public partial class BooksTable : Page
    {
        public BooksTable()
        {
            InitializeComponent();
            DataGridBooks.ItemsSource = Entities.GetContext().ИнформацияОКниге.ToList();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var BooksForRemoving = DataGridBooks.SelectedItems.Cast<ИнформацияОКниге>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {BooksForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().ИнформацияОКниге.RemoveRange(BooksForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridBooks.ItemsSource = Entities.GetContext().ИнформацияОКниге.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void AddEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddBooksTable((sender as Button).DataContext as ИнформацияОКниге));
        }
        private void BooksTable_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridBooks.ItemsSource = Entities.GetContext().ИнформацияОКниге.ToList();
            }
        }

    }
}
