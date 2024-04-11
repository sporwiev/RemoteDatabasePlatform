using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для InputBox.xaml
    /// </summary>
    public partial class InputBox : Window
    {
        public string value;
        public InputBox(string messages)
        {
            InitializeComponent();
            message.Text = messages; 
        }
        private void ok_click(object sender, RoutedEventArgs e)
        {
            value = input.Text;
           Close();
        }
        private void cancel_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
