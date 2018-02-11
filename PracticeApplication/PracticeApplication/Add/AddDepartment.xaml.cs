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
    /// Interaction logic for AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Page
    {
        public AddDepartment()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (departmentBox.Text != "")
            {
                if (Querys.addDepartment(departmentBox.Text))
                {
                    alreadeExists();
                }
                else
                {
                    successfully();
                }
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
        public void alreadeExists()
        {
            MessageBox.Show("Такой кабинет уже существует");
        }
        public void successfully()
        {
            MessageBox.Show("Запись успешно добавлена");
        }
    }
}
