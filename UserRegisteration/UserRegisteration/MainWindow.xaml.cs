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

namespace UserRegisteration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int chance;
        public MainWindow()
        {
            InitializeComponent();
            chance = 3;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var password = txtPassword.Password;
            if (name == "admin" && password == "123")
            {
                MessageBox.Show("Login successful", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                RegisterationForm form = new RegisterationForm();
                form.ShowDialog();
            }
            else if(chance==0)
            {
                MessageBox.Show("You have exhaused all attempts","Invalid",MessageBoxButton.OK,MessageBoxImage.Error);
                this.Close();
            }
           else
            {           
                MessageBox.Show($"Wrong credentials You have {chance} attempts", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                chance--;
            }
            
        }
    }
}
