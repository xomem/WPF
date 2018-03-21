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
    /// Interaction logic for AddPosition.xaml
    /// </summary>
    public partial class AddPosition : Page
    {
        public AddPosition()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text != "" && salaryBox.Text != "")
            {
                Querys.addPosition(nameBox.Text, salaryBox.Text);
                successfully();
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
        public void successfully()
        {
            MessageBox.Show("Запись успешно добавлена");
        }
    }
}
