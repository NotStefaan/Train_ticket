using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Train_ticket.BD;

namespace Train_ticket.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Autoriz());
        }

        private void Registr_button_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                if (Reg_pass.Password != Reg_pass2.Password)
                {

                    Reg_pass2.ToolTip = "Пароли не совпадают";
                    Reg_pass2.BorderBrush = Brushes.Red;
                }
                else
                {
                    var User = Train_dbEntities1.GetContext().Users.Add(new Users()
                    {
                        Name = Reg_name.Text,
                        PasswordHash = Reg_pass.Password,
                        Email = Reg_Email.Text,
                        RegistrationDate = DateTime.Now
                    });

                    Reg_pass2.BorderBrush = Brushes.DarkBlue;
                    Train_dbEntities1.GetContext().SaveChanges();
                    MessageBox.Show($"Пользователь {User.Name} зарегестрировался");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                throw;
            }
        }
    }
}
