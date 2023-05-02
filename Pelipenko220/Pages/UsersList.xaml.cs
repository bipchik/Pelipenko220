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
using System.Windows.Shapes;

namespace Pelipenko220.Pages
{
    /// <summary>
    /// Логика взаимодействия для UsersList.xaml
    /// </summary>
    public partial class UsersList : Window
    {
        public UsersList()
        {
            InitializeComponent();
            var currentUsers = Entities.GetContext().Пользователь.ToList();
            UserList.ItemsSource = currentUsers;
        }
    }
}
