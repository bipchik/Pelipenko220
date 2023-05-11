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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            var currentUsers = Entities.GetContext().Пользователь.ToList();
            UserList.ItemsSource = currentUsers;
            CmbBoxSortFIO.SelectedIndex = 0;
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearFilters();
        }

        private void SearchFIO_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void CmbBoxSortFIO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }
        private void UpdateUsers()
        {
            //загружаем всех пользователей в список
            var currentUsers = Entities.GetContext().Пользователь.ToList();

            //осуществляем поиск по Ф.И.О. без учета регистра букв
            currentUsers = currentUsers.Where(x => x.ФИО.ToLower().Contains(SearchFIO.Text.ToLower())).ToList();

            //осуществляем сортировку в зависимости от выбора пользователя
            if (CmbBoxSortFIO.SelectedIndex == 0)
                UserList.ItemsSource = currentUsers.OrderBy(x => x.ФИО).ToList();
            else UserList.ItemsSource = currentUsers.OrderByDescending(x => x.ФИО).ToList();
        }
        private void ClearFilters()
        {
            SearchFIO.Text = "";
            CmbBoxSortFIO.Text = "";
        }
    }
}
