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

namespace Crypt_Watch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isEnterToDataWindow = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUpWindow = new SignUp();
            signUpWindow.ShowDialog();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            SignIn signInWindow = new SignIn();

            signInWindow.ShowDialog();
            if (isEnterToDataWindow)
                ShowDataWindow();
        }

       public void ShowDataWindow() 
       {
            DataWindow dataW = new DataWindow();
            this.Close();
            dataW.Show();
       }

    }
}
