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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private void LoginBox_Changed(object sender, RoutedEventArgs e)
        {
            txtHintLogin.Visibility = Visibility.Visible;
            if (LoginBox.Text.Length > 0)
            {
                txtHintLogin.Visibility = Visibility.Hidden;
            }
        }
        private void PassBox_Changed(object sender, RoutedEventArgs e)
        {
            txtHintLogin.Visibility = Visibility.Visible;
            if (PassBox.Password.Length > 0)
            {
                txtHintPass.Visibility = Visibility.Hidden;
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PassBox.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            using (var db = new Entities())
            {
                var user = db.ИнформацияОЧитателе.AsNoTracking().FirstOrDefault(u => u.Логин == LoginBox.Text && u.Пароль == PassBox.Password);

                if (user == null) 
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return;
                }
            }
        }
    }
}
