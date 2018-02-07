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
using System.Data;
using System.Data.SqlClient;

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
        private bool HasRows(DataTable room)
        {
            return room.Rows.Count > 0;
        }
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

        private void findEmployByRoom_Click(object sender, RoutedEventArgs e)
        {
            Find.SearchEngine searchEngine = new Find.SearchEngine();
            string str;
            bool hasInput = searchEngine.TryGetName("Поиск сотрудника по номеру кабинета", out str);
            if (hasInput)
            {
                var Rooms = Querys.employByRoom(str);
                if (HasRows(Rooms))
                {
                    SimpleQueryResult = new SimpleQueryResult(Rooms);
                    NavigationService.Navigate(SimpleQueryResult);
                }
                else
                {
                    //searchEngine.checkError("Поиск сотрудника по номеру кабинета");
                }
            }
        }
    }
}
