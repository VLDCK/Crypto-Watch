using System.Windows;
using System.Windows.Controls;


namespace Crypt_Watch
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        MyDbConnection myDbConnection;

        public SignUp()
        {
            InitializeComponent();
            myDbConnection= new MyDbConnection();
        }
        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            myDbConnection.CloseConnectionDB();
            this.Close();
        }

        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            string checkMail = "SELECT mail FROM users WHERE mail = '" + mailField.Text + "'";

            if (myDbConnection.ReturnSelect(checkMail) == null)
            {
                CheckPass();
            }
            else 
            {
                MessageBox.Show("This Email address is already registered!",
                    "Attention",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }
        }
        
        public void CheckPass()
        {
            if (passwordField1.Password.Equals(passwordField2.Password) && passwordField1.Password.Length >= 6)
            {
                DbCall();
            }
            else
            {
                MessageBox.Show("Your passwords must be equals!\n" +
                                "Enter enter six or more characters!",
                    "Attention",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }
        }
        
        public void DbCall() 
        {
            
            string query = "INSERT INTO users (name, mail, password) VALUES" +
                                " ('" + nameField.Text + "'," +
                                " '" + mailField.Text + "','" +
                                myDbConnection.MD5Crypto(passwordField2.Password) + "')";
            myDbConnection.QueryDb(query);
            this.Close();
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
