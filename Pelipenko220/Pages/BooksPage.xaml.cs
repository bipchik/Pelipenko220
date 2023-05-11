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
    /// Логика взаимодействия для BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        public BooksPage()
        {
            InitializeComponent();
            var currentBooks = Entities.GetContext().ИнформацияОКниге.ToList();
            BooksList.ItemsSource = currentBooks;
            CmbBoxSortBook.SelectedIndex = 0;
        }

        private void SearchBook_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateBooks();
        }

        private void CmbBoxSortBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBooks();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearFilters();
        }
        private void UpdateBooks()
        {
            //загружаем всех пользователей в список
            var currentUsers = Entities.GetContext().ИнформацияОКниге.ToList();

            //осуществляем поиск по Ф.И.О. без учета регистра букв
            currentUsers = currentUsers.Where(x => x.Название.ToLower().Contains(SearchBook.Text.ToLower())).ToList();

            //осуществляем сортировку в зависимости от выбора пользователя
            if (CmbBoxSortBook.SelectedIndex == 0)
                BooksList.ItemsSource = currentUsers.OrderBy(x => x.Название).ToList();
            else BooksList.ItemsSource = currentUsers.OrderByDescending(x => x.Название).ToList();
        }
        private void ClearFilters()
        {
            SearchBook.Text = "";
            CmbBoxSortBook.Text = "";
        }
    }
}
