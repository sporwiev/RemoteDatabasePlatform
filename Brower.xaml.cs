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
using System.Windows.Threading;

namespace Seva
{
    /// <summary>
    /// Логика взаимодействия для Brower.xaml
    /// </summary>
    public partial class Brower : Window
    {
        public Brower()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
