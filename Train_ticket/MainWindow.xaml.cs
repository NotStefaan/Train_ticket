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
using Train_ticket.Controllers;

namespace Train_ticket
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Contacts.Text = UserObj.pohui.Name;
        }

        //обработчик нажатия на кнопу ЛК
        private void AddPresetButton_Click(object sender, RoutedEventArgs e)
        {
            var addButton = sender as FrameworkElement;
            if (addButton != null)
            {
                addButton.ContextMenu.IsOpen = true;
            }
        }

        //Обработчик комбобокса типа билетов
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            TypeOfBox.Items.Insert(0, "Please select any value");
            TypeOfBox.SelectedIndex = 0;
            TypeOfBox.Text = "Please, select any value";
            if (TypeOfBox.SelectedIndex < 0)
            {
                TypeOfBox.Text = "Please, select any value";
            }
        }

    }
}
