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
using MySql.Data.MySqlClient;

namespace Seva
{
    /// <summary>
    /// Логика взаимодействия для Connected.xaml
    /// </summary>
    public partial class Connected : Window
    {
        public Connected()
        {
            InitializeComponent();
        }
        public static string server;
        public static string port;
        public static string username;
        public static string password;
        public static string database;

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            server = Server.Text;
            port = Port.Text;
            username = UserName.Text;
            password = Password.Text;
            database = DataBase.Text;
            try
            {
                MySqlConnection conn = new MySqlConnection($"server={server};port={port};username={username};password={password};");
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {

                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Not conntection");
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void remoteConnect_Click(object sender, RoutedEventArgs e)
        {
            remoteConnect remote = new remoteConnect();
            remote.Show();
        }
    }
}
