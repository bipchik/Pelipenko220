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
            if (string.IsNullOrEmpty(LoginInput.Text) || string.IsNullOrEmpty(PassInput.Password) || string.IsNullOrEmpty(ChekPassInput.Password) || string.IsNullOrEmpty(SernameInput.Text) || string.IsNullOrEmpty(NameInput.Text) || string.IsNullOrEmpty(PatInput.Text))
            {
                MessageBox.Show("Введите логин и пароль!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var db = new Entities())
            {
                var user = db.ИнформацияОЧитателе.AsNoTracking().FirstOrDefault(u => u.Логин == LoginInput.Text && u.Пароль == PassInput.Password && u.Пароль == ChekPassInput.Password && u.Фамилия == SernameInput.Text && u.Имя == NameInput.Text && u.Отчество == PatInput.Text);

                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            
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
            HintPass.Visibility = Visibility.Visible;
            if (PassInput.Password.Length > 0)
            {
                HintPass.Visibility = Visibility.Hidden;
            }
        }
    }
}
