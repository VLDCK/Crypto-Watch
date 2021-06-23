using System;
using System.Windows;
using System.Windows.Controls;


namespace Crypt_Watch
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        MyDbConnection myDbConnection;
        public SignIn()
        {
            InitializeComponent();
            myDbConnection = new MyDbConnection();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            myDbConnection.CloseConnectionDB();
            this.Close();
        }

        private void buttonLog_Click(object sender, RoutedEventArgs e)
        {
            string checkMailQuery;
            checkMailQuery = "SELECT mail FROM users WHERE mail = '" + mailField.Text + "'";
            DataWindow.UserMail = mailField.Text;

            if (myDbConnection.ReturnSelect(checkMailQuery) != null)
            {
                CheckPass();
            }
            else
            {
                MessageBox.Show("This Email address is not registered!",
                    "Attention",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }
        }

        public void CheckPass()
        {
            string checkPasswordFromDB = "SELECT password FROM users WHERE mail = '"+ mailField.Text+ "'";

            string passFromForm = myDbConnection.MD5Crypto(passwordField1.Password);

            if (myDbConnection.ReturnSelect(checkPasswordFromDB) == passFromForm)
            {
                MainWindow.isEnterToDataWindow = true;
                myDbConnection.CloseConnectionDB();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password is incorrect, please try again",
                    "Attention",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }
        }

        private void Field_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox text = sender as TextBox;
            PasswordBox password = sender as PasswordBox;

            if (text != null)
            {
                text.Text = "";
            }

            if (password != null)
            {
                password.Password = "";
            }
        }





    }
}

