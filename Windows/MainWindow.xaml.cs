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
            var login = tx1.Text;
            var password = tx2.Text;
            var context = new AppDbContext();
            var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user is null) 
            {
                MessageBox.Show("Вы идиот или же ввели неправильный логин или пароль");
                return;
            
            }
           else MessageBox.Show("Вы лучшие и вошли в свой акк");
            Window2 w2 = new Window2();
            w2.Show();
            this.Hide();
        }
        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
        }

        public class AppDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }

        }
    }
}
