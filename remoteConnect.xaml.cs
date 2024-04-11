using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Seva
{
    /// <summary>
    /// Логика взаимодействия для remoteConnect.xaml
    /// </summary>
    public partial class remoteConnect : Window
    {
        public remoteConnect()
        {
            InitializeComponent();
        }

        private void remoteConnect_Click(object sender, RoutedEventArgs e)
        {
            var connectionInfo = new ConnectionInfo($"{server.Text}",
                                        $"{user.Text}",
                                        new PasswordAuthenticationMethod($"{user.Text}", $"{Pass.Text}"),
                                        new PrivateKeyAuthenticationMethod("rsa.key"));
            using (var client = new SftpClient(connectionInfo))
            {
                try
                {
                    client.Connect();
                    MessageBox.Show(client.ConnectionInfo.ChannelRequests.Values.ToString());
                    Process process = new Process();
                    process.StartInfo = new ProcessStartInfo("mysql.exe",$"-u 1375-20_kruglov -p");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
