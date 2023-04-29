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
    /// Логика взаимодействия для AuthorsTable.xaml
    /// </summary>
    public partial class AuthorsTable : Page
    {
        public AuthorsTable()
        {
            InitializeComponent();
            DataGridAuthors.ItemsSource = Entities.GetContext().Авторы.ToList();
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var AuthorsForRemoving = DataGridAuthors.SelectedItems.Cast<Авторы>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {AuthorsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Авторы.RemoveRange(AuthorsForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridAuthors.ItemsSource = Entities.GetContext().Авторы.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void AddEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddAuthorsTable((sender as Button).DataContext as Авторы));
        }
        private void AuthorTable_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridAuthors.ItemsSource = Entities.GetContext().Авторы.ToList();
            }
        }
    }
}
