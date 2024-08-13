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

namespace Pelipenko220.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
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
        
        private void Passport_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PassportTable();
        }

        private void Authors_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AuthorsTable();
        }

        private void Izdatelstvo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new IzdatelstvoTable();
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new BooksTable();
        }

        private void GiveBooks_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new GiveBooksTable();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Worker();
        }

        private void Readers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Readers();
        }

        private void Cities_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Cities();
        }

        private void Genres_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Genres();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/Authorization.xaml", UriKind.Relative));
        }
    }
}
