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
using WpfAppPRACTIKA.Classes;
using WpfAppPRACTIKA.Migrations;

namespace WpfAppPRACTIKA.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public int _id;
        public Window2(int id)
        {
            InitializeComponent();
           _id = id;
            int find = id;
            var context = new AppDbContext();
            var user = context.Users.SingleOrDefault(x => x.Id == id);
            string Finde = user.Login;
            tx5.Text = Finde;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ret1_Click(object sender, RoutedEventArgs e)
        {
            Window1 ww = new Window1();
            ww.Show();
            this.Hide();
        }

        private void change1_Click(object sender, RoutedEventArgs e)
        {
            Window3 ee = new Window3();
            ee.Show();
            this.Hide();
        }
    }
}
