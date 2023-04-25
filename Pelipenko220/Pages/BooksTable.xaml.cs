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
            DataGridBooks.ItemsSource = библEntities1.GetContext().ИнформацияОКниге.ToList();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/Pages/AddBooksTable.xaml", UriKind.Relative));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BooksTable_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                библEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridBooks.ItemsSource = библEntities1.GetContext().ИнформацияОКниге.ToList();
            }
        }

    }
}
