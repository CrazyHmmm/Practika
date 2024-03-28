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
using WpfAppPRACTIKA.Windows;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;


namespace WpfAppPRACTIKA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }



        private void tb1_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 reg = new Window1();

            reg.Show();

            this.Hide();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            ps1.Password = tx2.Text;
            var login = tx1.Text;
            var email = tx1.Text;
            var password = tx2.Text;
            var context = new AppDbContext();
            var user = context.Users.SingleOrDefault(x => (x.Login == login  || x.Email == email) && (x.Password == password));
            if (user is null)
            {
                MessageBox.Show("Вы идиот или же ввели неправильный логин или пароль");
                return;

            }
            MessageBox.Show("Вы лучшие и вошли в свой акк");
            int id = user.Id;
            Window2 w2 = new Window2(id);
            w2.Show();
            this.Hide();
            

        }
        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; }

            public string Email { get; set; }    
            public string Password { get; set; }
        }

        public class AppDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=chugunovDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
            
        }

        private void tx1_TextChanged(object sender, TextChangedEventArgs e)
        {         

            if (tx1.Text != "")
            {
                txtSearchPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                txtSearchPlaceholder.Visibility = Visibility.Visible;

            }
            if (ps1 != null) { b1.IsEnabled = true; } else { b1.IsEnabled = false; }
        }

        private void tx2_TextChanged(object sender, TextChangedEventArgs e)
        {


            if (tx2.Text != "")
            {
                txtSearchPlaceholder_2.Visibility = Visibility.Hidden;
            }
            else
            {
                txtSearchPlaceholder_2.Visibility = Visibility.Visible;

            }
        }
       

        private void glaz_Click(object sender, RoutedEventArgs e)
        {
            var text = ps1.Password;
            ps1.Visibility = Visibility.Collapsed;
            tx2.Visibility = Visibility.Visible;
            tx2.Text = text;
            glaz.Visibility = Visibility.Hidden;
            glaz_2.Visibility = Visibility.Visible;
        }

        private void glaz_2_Click(object sender, RoutedEventArgs e)
        {
            var text = tx2.Text;
            ps1.Visibility = Visibility.Visible;
            tx2.Visibility = Visibility.Collapsed;
            ps1.Password = text;
            glaz_2.Visibility = Visibility.Hidden;
            glaz.Visibility = Visibility.Visible;
        }

        private void g1_Loaded(object sender, RoutedEventArgs e)
        {
            b1.IsEnabled = true;
        }
    }
}
