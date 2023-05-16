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
using Train_ticket.BD;
using Train_ticket.Controllers;
using Train_ticket.Windows;

namespace Train_ticket.Views
{
    /// <summary>
    /// Логика взаимодействия для Autoriz.xaml
    /// </summary>
    public partial class Autoriz : Page
    {
        public Autoriz()
        {
            InitializeComponent();
        }

        private void Click_auth_registr(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var User = Train_dbEntities1.GetContext().Users.FirstOrDefault(x => x.Name == Login.Text && x.PasswordHash == Pass.Password);
            
            if (User == null)
            {
                //Пользователь не найден
                //MessageBox.Show("Пользователь не найден");
                Login.ToolTip = "Пользователя с таким именем не существует";
                Login.BorderBrush = Brushes.Red;

                Pass.ToolTip = "Проверьте корректность написания пароля";
                Pass.BorderBrush = Brushes.Red;
                return;
            }

            //Пользователь найден
            if (User != null) 
            {
                UserObj.pohui = User;
                new MainWindow().Show();

            }

        }
    }
}
