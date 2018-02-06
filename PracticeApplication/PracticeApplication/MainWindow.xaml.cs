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

namespace PracticeApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainMenu MainMenu;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            //MainFrame.Content = new MainMenu();
            MainMenu = new MainMenu(this);
            MainFrame.Navigate(MainMenu);            
        }

        public void successfulConnection()
        {
            //Status.Content = "Запрос выполнен успешно";
        }
        public void errorConnection(Exception ex)
        {
            //Status.Content = "Ошибка выполнения запроса - " + ex;
            MessageBox.Show("Ошибка выполнения запроса - " + ex);
        }
    }
}
