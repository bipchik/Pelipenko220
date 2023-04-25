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

namespace Pelipenko220.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            //проверка на пустые поля
            if (string.IsNullOrEmpty(LoginInput.Text) || string.IsNullOrEmpty(PassInput.Password) || string.IsNullOrEmpty(ChekPassInput.Password) || string.IsNullOrEmpty(SernameInput.Text) || string.IsNullOrEmpty(NameInput.Text))
            {
                MessageBox.Show("Заполните все обязтельные поля!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (PassInput.Password.Length >= 6)
            {
                bool eng = true; //англ раскладка
                bool num = false;

                for (int i = 0; i < PassInput.Password.Length; i++) //перебираем символы
                {
                    if (PassInput.Password[i] >= 'А' && PassInput.Password[i] <= 'Я' || PassInput.Password[i] >= 'а' && PassInput.Password[i] <= 'я') eng = false;//если русская раскладка
                    if (PassInput.Password[i] >= '0' && PassInput.Password[i] <= '9') num = true;
                }

                if (!eng)
                {
                    MessageBox.Show("Для пароля доступна только английская раскладка!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (!num)
                {
                    MessageBox.Show("Пароль должен содержать хотя бы одну цифру.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (eng && num) { }// проверяем соответсвие
            }
            else
            {
                MessageBox.Show("Пароль должен содержать минимум 6 символов.", "Слишком короткий пароль!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //проверка на совпадение паролей
            if (PassInput.Password != ChekPassInput.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using (var db1 = new Entities())
            {
                var user = db1.Пользователь.AsNoTracking().FirstOrDefault(u => u.Логин == LoginInput.Text);

                if (user != null)
                {
                    MessageBox.Show("Этот логин уже зарегестрирован!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                //запись в БД
                Entities db2 = new Entities();
                Пользователь userObject = new Пользователь
                {
                    Фамилия = SernameInput.Text,
                    Имя = NameInput.Text,
                    Отчество = PatInput.Text,
                    Логин = LoginInput.Text,
                    Пароль = GetHash(PassInput.Password)
                };
                db2.Пользователь.Add(userObject);
                db2.SaveChanges();

                MessageBox.Show("Пользователь зарегестрирован!", "Регистрация завершена!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/Pages/Tables.xaml", UriKind.Relative));
        }
        
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/Pages/Authorization.xaml", UriKind.Relative));
        }
        public void Reset()
        {
            LoginInput.Text = "";
            SernameInput.Text = "";
            PatInput.Text = "";
            PassInput.Password = "";
            ChekPassInput.Password = "";
        }
        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }
        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HintLogin.Visibility = Visibility.Visible;
            if (LoginInput.Text.Length > 0)
            {
                HintLogin.Visibility = Visibility.Hidden;
            }
        }
        private void SernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HintSername.Visibility = Visibility.Visible;
            if (SernameInput.Text.Length > 0)
            {
                HintSername.Visibility = Visibility.Hidden;
            }
        }
        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HintName.Visibility = Visibility.Visible;
            if (NameInput.Text.Length > 0)
            {
                HintName.Visibility = Visibility.Hidden;
            }
        }
        private void PatBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HintPat.Visibility = Visibility.Visible;
            if (PatInput.Text.Length > 0)
            {
                HintPat.Visibility = Visibility.Hidden;
            }
        }
        private void PassBox_Changed(object sender, RoutedEventArgs e)
        {
            HintPass.Visibility = Visibility.Visible;
            if (PassInput.Password.Length > 0)
            {
                HintPass.Visibility = Visibility.Hidden;
            }
        }
        private void ChekPassBox_Changed(object sender, RoutedEventArgs e)
        {
            HintChekPass.Visibility = Visibility.Visible;
            if (ChekPassInput.Password.Length > 0)
            {
                HintChekPass.Visibility = Visibility.Hidden;
            }
        }
    }
}
