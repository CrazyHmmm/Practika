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
using WpfAppPRACTIKA.Windows;
using Microsoft.EntityFrameworkCore;
using static WpfAppPRACTIKA.MainWindow;

namespace WpfAppPRACTIKA.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void b2_1_Click(object sender, RoutedEventArgs e)
        {
            var email = tx2_1.Text;
            var login = tx2_2.Text;
            var pass = tx2_3.Text;
            var pass2 = tx2_4.Text;  
            var context = new AppDbContext();
            var user_exists = context.Users.FirstOrDefault(x => (x.Login == login || x.Login == email));
            if (user_exists is not null) 
            { 
                MessageBox.Show("Такой пользователь уже существует");
                return; 
            }



            if (tx2_1.Text.Length >= 1  && tx2_3.Text.Length >= 6 && tx2_4.Text.Length >= 6)
            {
                if (tx2_1.Text.Contains("@") && tx2_1.Text.Contains("."))
                {
                    if (tx2_3.Text.Contains("!") || tx2_3.Text.Contains("$") || tx2_3.Text.Contains("#") || tx2_3.Text.Contains("%") || tx2_3.Text.Contains("&") || tx2_3.Text.Contains("@"))
                    {
                        if (pass == pass2)
                        {
                            var user = new User { Login = login, Email = email, Password = pass };
                            context.Users.Add(user);
                            context.SaveChanges();
                            MessageBox.Show("Welcom, olyx");
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Hide();
                        }
                        else
                        {
                            error_pass.Visibility = Visibility.Visible;
                        }
                    }
                    else error_pass_1.Visibility = Visibility.Visible;
                }
                else
                {
                    error_email.Visibility = Visibility.Visible;
                }
            }
            else
            {
                error_lenght.Visibility = Visibility.Visible;
            }
        }

      

        private void tx2_1_TextChanged(object sender, TextChangedEventArgs e)
        {
           


            if (tx2_1.Text != "")
            {
                txtSearchPlaceholder_3.Visibility = Visibility.Hidden;
            }
            else
            {
                txtSearchPlaceholder_3.Visibility = Visibility.Visible;

            }
           
        }

        private void tx2_2_TextChanged(object sender, TextChangedEventArgs e)
        {
          

            if (tx2_2.Text != "")
            {
                txtSearchPlaceholder_4.Visibility = Visibility.Hidden;
            }
            else
            {
                txtSearchPlaceholder_4.Visibility = Visibility.Visible;

            }
        }

        private void tx3_3_TextChanged(object sender, TextChangedEventArgs e)
        {
        

            if (tx2_3.Text != "")
            {
                txtSearchPlaceholder_5.Visibility = Visibility.Hidden;
            }
            else
            {
                txtSearchPlaceholder_5.Visibility = Visibility.Visible;

            }
        }

        private void tx4_4_TextChanged(object sender, TextChangedEventArgs e)
        {
          

            if (tx2_4.Text != "")
            {
                txtSearchPlaceholder_6.Visibility = Visibility.Hidden;
            }
            else
            {
                txtSearchPlaceholder_6.Visibility = Visibility.Visible;

            }
        }

        private void eye_1_Click(object sender, RoutedEventArgs e)
        {
            var text = ps2_1.Password;
            ps2_1.Visibility = Visibility.Collapsed;
            tx2_3.Visibility = Visibility.Visible;
            tx2_3.Text = text;
            eye_1.Visibility = Visibility.Hidden;
            eye_2.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var text = tx2_3.Text;
            ps2_1.Visibility = Visibility.Visible;
            tx2_3.Visibility = Visibility.Collapsed;
            ps2_1.Password = text;
            eye_2.Visibility = Visibility.Hidden;
            eye_1.Visibility = Visibility.Visible;
        }

        private void eye_3_Click(object sender, RoutedEventArgs e)
        {

            var text = ps2_2.Password;
            ps2_2.Visibility = Visibility.Collapsed;
            tx2_4.Visibility = Visibility.Visible;
            tx2_4.Text = text;
            eye_3.Visibility = Visibility.Hidden;
            eye_4.Visibility = Visibility.Visible;
        }

        private void eye_4_Click(object sender, RoutedEventArgs e)
        {
            var text = tx2_4.Text;
            ps2_2.Visibility = Visibility.Visible;
            tx2_4.Visibility = Visibility.Collapsed;
            ps2_2.Password = text;
            eye_4.Visibility = Visibility.Hidden;
            eye_3.Visibility = Visibility.Visible;
        }
    }
}
