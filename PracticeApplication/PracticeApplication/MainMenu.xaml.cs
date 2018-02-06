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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private SimpleQueryResult SimpleQueryResult;

        Window MainWin;
        MainWindow mainWindow = new MainWindow();
        public MainMenu(Window MainWin)
        {
            InitializeComponent();
            this.MainWin = MainWin;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MainWin.Title = "Главное меню";
        }

        private void allEmploy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employers = Querys.readEmployers();
                mainWindow.successfulConnection();
                SimpleQueryResult = new SimpleQueryResult(employers);
                NavigationService.Navigate(SimpleQueryResult);
                MainWin.Title = "Все сотрудники";
            }
            catch (Exception ex)
            {
                mainWindow.errorConnection(ex);
            }
        }

        private void addEmploy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmploy());
            MainWin.Title = "Добавить сотрудника";
        }
    }
}
