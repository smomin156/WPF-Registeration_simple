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
using System.Windows.Shapes;
using System.IO;

namespace UserRegisteration
{
    /// <summary>
    /// Interaction logic for RegisterationForm.xaml
    /// </summary>
    public partial class RegisterationForm : Window
    {
        public RegisterationForm()
        {
            InitializeComponent();
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "This is required !!";
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string address = txtAddress.Text;
            string country = txtCountry.Text;
            string tel="No tel";
            string mobile="No Mobile";
            if (chkTel.IsChecked == true)
            {
                tel = txtTel.Text;
            }
            if (chkMob.IsChecked == true)
            {
                mobile = txtMobile.Text;
            }
            string gender = chkMale.IsChecked == true ? "Male" : "Female";
            string marital = chkMarried.IsChecked == true ? "Married" : "single";
            string qualify = "";

            try
            {
                using(StreamWriter writer=new StreamWriter(@"C:\UserData\"+username+".txt"))
                {
                    writer.WriteLine("username : " + username);
                    writer.WriteLine("password : " + password);
                    writer.WriteLine("address : " + address);
                    writer.WriteLine("country : " + country);
                    writer.WriteLine("tel : " + tel);
                    writer.WriteLine("mobile : " + mobile);
                    writer.WriteLine("gender : " + gender);
                    writer.WriteLine("marital status : " + marital);
                    foreach (object item in listQualification.SelectedItems)
                    {
                        ListBoxItem li = (ListBoxItem)item;
                        qualify += li.Content + " ";
                    }
                    writer.WriteLine("qualification : " + qualify);

                }
                MessageBox.Show("Data Saved Successesfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void chkTel_Checked(object sender, RoutedEventArgs e)
        {
            txtTel.Visibility = Visibility.Visible;
        }

        private void chkMob_Checked(object sender, RoutedEventArgs e)
        {
            txtMobile.Visibility = Visibility.Visible;
        }

        private void chkTel_Unchecked(object sender, RoutedEventArgs e)
        {
            txtTel.Visibility = Visibility.Hidden;
        }

        private void chkMob_Unchecked(object sender, RoutedEventArgs e)
        {
            txtMobile.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string[] arr = Directory.GetFiles(@"C:\UserData");
            foreach (string n in arr)
            {
                listUser.Items.Add(n);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            listUser.Items.Clear();
        }

        private void listUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            object item = listUser.SelectedItem;
            string path = item.ToString();
            string line = "";
            try
            {
                using(StreamReader reader=new StreamReader(path))
                {
                    line = reader.ReadToEnd();
                    txtrich.Document.Blocks.Clear();
                    txtrich.AppendText(line);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtrich.Document.Blocks.Clear();
            listUser.Items.Clear();
            txtUsername.Text = "";
            txtPassword.Password = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            txtTel.Text = "";
            txtCountry.SelectedItem = "";
            
        }
    }
}
