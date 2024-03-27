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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            b2_1.IsEnabled = false;
        }

        private void tx2_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((tx2_1.Text.Length == 0) || (tx2_2.Text.Length == 0) || (tx2_3.Text.Length == 0) || (tx2_4.Text.Length == 0) || (tx2_1.Text == ",") || (tx2_2.Text == ",") || (tx2_3.Text == ",") || (tx2_4.Text == ","))
                b2_1.IsEnabled = false;
            else b2_1.IsEnabled = true;
        }

        private void tx2_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((tx2_1.Text.Length == 0) || (tx2_2.Text.Length == 0) || (tx2_3.Text.Length == 0) || (tx2_4.Text.Length == 0) || (tx2_1.Text == ",") || (tx2_2.Text == ",") || (tx2_3.Text == ",") || (tx2_4.Text == ","))
                b2_1.IsEnabled = false;
            else b2_1.IsEnabled = true;
        }

        private void tx3_3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((tx2_1.Text.Length == 0) || (tx2_2.Text.Length == 0) || (tx2_3.Text.Length == 0) || (tx2_4.Text.Length == 0) || (tx2_1.Text == ",") || (tx2_2.Text == ",") || (tx2_3.Text == ",") || (tx2_4.Text == ","))
                b2_1.IsEnabled = false;
            else b2_1.IsEnabled = true;
        }

        private void tx4_4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((tx2_1.Text.Length == 0) || (tx2_2.Text.Length == 0) || (tx2_3.Text.Length == 0) || (tx2_4.Text.Length == 0) || (tx2_1.Text == ",") || (tx2_2.Text == ",") || (tx2_3.Text == ",") || (tx2_4.Text == ","))
                b2_1.IsEnabled = false;
            else b2_1.IsEnabled = true;
        }

        private void eye_1_Click(object sender, RoutedEventArgs e)
        {
            ps2_1.Visibility = Visibility.Visible;
            eye_1.Visibility = Visibility.Hidden;
            tx2_3.Visibility = Visibility.Hidden;
            eye_2.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tx2_3.Visibility = Visibility.Visible;
            eye_1.Visibility = Visibility.Visible;
            eye_2.Visibility = Visibility.Hidden; 
            ps2_1.Visibility = Visibility.Hidden; 
        }
    }
}
