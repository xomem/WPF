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

namespace PracticeApplication.Add
{
    /// <summary>
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Page
    {
        public AddRoom()
        {
            InitializeComponent();
            var departmens = Querys.fillDepartment().ToArray();
            departmentSelect.ItemsSource = departmens;
            departmentSelect.DisplayMemberPath = "departmentName";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (numberBox.Text != "" && departmentSelect.SelectedItem != null)
            {
                Querys.addRoom(Convert.ToInt32(numberBox.Text), (departmentSelect.SelectedItem as SecurityDepartment).departmentId);
                //MessageBox.Show("Запись успешно добавленна");
                if (errorLabel.Content.ToString() != "")
                {
                    errorLabel.Content = "";
                }
            }
            else
            {
                errorLabel.Content = "Не все поля заполенны";
            }
        }
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

       
    }
}
