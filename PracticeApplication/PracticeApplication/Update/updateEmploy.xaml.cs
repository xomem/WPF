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

namespace PracticeApplication.Update
{
    /// <summary>
    /// Interaction logic for updateEmploy.xaml
    /// </summary>
    public partial class updateEmploy : Page
    {
        public updateEmploy()
        {
            InitializeComponent();
        }
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (idBox.Text != "")
            {
                //Querys.updateEmploy(employID.Text, nameBox.Text, srunameBox.Text, patronymicBox.Text);
            }
            else
            {
                errorLabel.Content = "Поле должно быть заполннено";
            }
        }

        private void getData_Click(object sender, RoutedEventArgs e)
        {
            if (idBox.Text != "")
            {
                Employer employer = Querys.GetEmployDataByID(idBox.Text);
                if (employer != null)
                {
                    nameBox.Text = employer.name;
                    surnameBox.Text = employer.surname;
                    patronymicBox.Text = employer.patronymic;
                    positionSelect.SelectedItem = employer.position;
                    
                    dataPiker.DataContext = employer.dateOfBirth;
                    departmentSelect.SelectedIndex = employer.department;
                    roomSelect.SelectedValue = employer.room;
                    cityBox.Text = employer.city;
                    adressBox.Text = employer.adres;
                    phoneBox.Text = employer.phone;
                }
            }
            else
            {
                errorLabel.Content = "Поле должно быть заполннено";
            }
        }
    }
}
