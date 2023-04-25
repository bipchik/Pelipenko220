using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.IO; //для осуществления чтения/записи в файл
using System.Diagnostics; //для запуска Блокнота
using Microsoft.Win32; //для работы диалоговых окон открытия/сохранения файла


namespace Pelipenko220
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { label1.Content = DateTime.Now.ToString(); };
            timer.Start();
        }

        internal static object Select(string v)
        {
            throw new NotImplementedException();
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            // определяем путь к файлу ресурсов
            var uri = new Uri("Dictionary.xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            // определяем путь к файлу ресурсов
            var uri = new Uri("DictionaryMy.xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            Export(path);
        }
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "exportFile.txt");
        void Export(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            using (var db = new Entities())
            {
                foreach (var element in db.Пользователь)
                {
                    sw.WriteLine($"{element.КодПользователя} {element.Фамилия} {element.Имя} {element.Отчество} {element.Логин} {element.Пароль}");
                }
            }
            sw.Close();
            Process.Start("notepad.exe", path);
        }
        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {
            Import();
        }
        void Import()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*)";
            ofd.ShowDialog();
            if (ofd.FileName == "")
            {
                MessageBox.Show("Файл для импорта не найден!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string fileContent = File.ReadAllText(ofd.FileName);
                MessageBox.Show(fileContent, "Содержание файла.");
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
