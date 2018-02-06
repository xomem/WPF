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
            Querys.fillPosition();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text != "" || srunameBox.Text != "" || adressBox.Text != "" || phoneBox.Text != "" || cityBox.Text != "" || dataPiker.SelectedDate != null || roomSelect.SelectedItem != null || positionSelect.SelectedItem != null || departmentSelect.SelectedItem != null)
            {
                //Querys.addEmploy(nameBox.Text, srunameBox.Text, patronymicBox.Text);
                MessageBox.Show("Запись успешно добавленна");
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
