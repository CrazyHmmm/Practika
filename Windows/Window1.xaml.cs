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
using WpfAppPRACTIKA.Migrations;
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
            var login = tx2_2.Text;
            var pass = tx3_3.Text;
            var context = new AppDbContext();
            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists is not null) 
            { 
                MessageBox.Show("Такой пользователь уже существует");
                return; 
            }
            var user = new User { Login = login, Password = pass };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Welcom, olyx");

           
        }
       
        
    }
}
