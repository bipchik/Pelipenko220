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
using System.Security.Cryptography;
using System.Diagnostics;

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
        private void passBox_Changed(object sender, RoutedEventArgs e)
        {
            hintPass.Visibility = Visibility.Visible;
            if (passBox.Password.Length > 0)
            {
                hintPass.Visibility = Visibility.Hidden;
            }
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(loginBox.Text) || string.IsNullOrEmpty(passBox.Password))
            {
                MessageBox.Show("Введите логин и пароль!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var db = new Entities())
            {
                string HashPass = GetHash(passBox.Password);
                var user = db.Работники.AsNoTracking().FirstOrDefault(u => u.Логин == loginBox.Text && u.Пароль == HashPass);

                if (user == null) 
                {
                    MessageBox.Show("Пользователь с такими данными не найден!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new Uri("/Pages/Main.xaml", UriKind.Relative));
                }
            }

        }
        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }

        private void loginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            hintLogin.Visibility = Visibility.Visible;
            if (loginBox.Text.Length > 0)
            {
                hintLogin.Visibility = Visibility.Hidden;
            }
        }

        private void reg_Link(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/Registration.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("\"C:\\Users\\Ф\\source\\repos\\Pelipenko220\\СпарвСис.chm\"");
        }
    }
}
