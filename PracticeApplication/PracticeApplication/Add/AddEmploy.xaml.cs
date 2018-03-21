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
    /// Interaction logic for AddEmploy.xaml
    /// </summary>
    public partial class AddEmploy : Page
    {
        public AddEmploy()
        {
            InitializeComponent();
            var positions = Querys.fillPosition().ToArray();
            positionSelect.ItemsSource = positions;
            positionSelect.DisplayMemberPath = "positionName";

            var departmens = Querys.fillDepartment().ToArray();
            departmentSelect.ItemsSource = departmens;
            departmentSelect.DisplayMemberPath = "departmentName";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text != "" && srunameBox.Text != "" && adressBox.Text != "" && phoneBox.Text != "" && cityBox.Text != "" && dataPiker.SelectedDate != null && roomSelect.SelectedItem != null && positionSelect.SelectedItem != null && departmentSelect.SelectedItem != null)
            {
                Querys.addEmploy(nameBox.Text, srunameBox.Text, patronymicBox.Text, Convert.ToString(dataPiker.SelectedDate), (positionSelect.SelectedItem as SecurityPosition).positionId, (departmentSelect.SelectedItem as SecurityDepartment).departmentId,  cityBox.Text, adressBox.Text, phoneBox.Text, (roomSelect.SelectedItem as SecurityRoom).roomId.ToString());
                MessageBox.Show("Запись успешно добавленна");
                if(errorLabel.Content.ToString() != "")
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

        private void departmentSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (departmentSelect.SelectedValue.ToString() != "")
            {
                var department = departmentSelect.SelectedItem as SecurityDepartment;
                int departmentID = department.departmentId;
           
                var rooms = Querys.fillRoom(departmentID).ToArray();
                roomSelect.ItemsSource = rooms;
                roomSelect.DisplayMemberPath = "roomName";
            }
        }
    }
}
