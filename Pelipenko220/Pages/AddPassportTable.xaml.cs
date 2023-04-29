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
    /// Логика взаимодействия для AddPassportTable.xaml
    /// </summary>
    public partial class AddPassportTable : Page
    {
        public AddPassportTable(ПаспортныеДанные selectedPassports)
        {
            InitializeComponent();

            if (selectedPassports != null )
                _currentPassports = selectedPassports;

            DataContext = _currentPassports;

        }
        private ПаспортныеДанные _currentPassports = new ПаспортныеДанные();

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentPassports.КемВыдан))
                errors.AppendLine("Укажите кем выдан паспорт!");
            if (_currentPassports.Серия <= 0)
                errors.AppendLine("Укажите серию паспорта! (4 цифры)");
            if (_currentPassports.Номер <= 0)
                errors.AppendLine("Укажите номер паспорта! (6 цифр)");
            if (string.IsNullOrWhiteSpace(_currentPassports.КодПодразделения))
                errors.AppendLine("Укажите код подразделения паспорта! (***-***)");

            //Проверяем переменную errors на наличие ошибок
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //Добавляем в объект Cars новую запись
            if (_currentPassports.КодПаспорта == 0)
                Entities.GetContext().ПаспортныеДанные.Add(_currentPassports);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
