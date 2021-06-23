using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Crypt_Watch
{
    /// <summary>
    /// Логика взаимодействия для DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
       public static string UserMail { get; set; }
        public DataWindow()
        {
            InitializeComponent();
            SetData();
            Timer();
            DateTimer();
            SetDate();
            ShowName();
        }
              
        void SetData() 
        {
             labelData.Content = new HttpDataAccess().GetResponce();
        }

        public void labelData_Tick(object sender, EventArgs e)
        {
            SetData();
        }
                     
        public void DateTimer()
        {
            DispatcherTimer ReloadDataTimer = new DispatcherTimer();
            ReloadDataTimer.Interval = TimeSpan.FromSeconds(3);
            ReloadDataTimer.Tick += labelData_Tick;
            ReloadDataTimer.Start();
        }

        public void labelTime_Tick(object sender, EventArgs e)
        {
            labelTime.Content = DateTime.Now.ToLongTimeString();
        }
        public void Timer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += labelTime_Tick;
            timer.Start();
        }
        void SetDate() { labelDate.Content = DateTime.Today.ToString("d"); }
       
        private void Field_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox text = sender as TextBox;
           
            if (text != null)
            {
                text.Text = "";
            }

        }
        public void ShowName() 
        {
            MyDbConnection myDB = new MyDbConnection();
            string query = "SELECT name FROM users WHERE mail = '" + UserMail + "'";
           
            nickName.Content = myDB.ReturnSelect(query);
            myDB.CloseConnectionDB();

            
        }

        //это ужасно но я не знаю как создать экземпялр класса с нужным мне именем, так что пусть остаеться как есть((((
        //тоже самое при выводе данных курса на экран
        private void reloadButton_Click(object sender, RoutedEventArgs e)
        {
            NameCrypt current = JsonConvert.DeserializeObject<NameCrypt>(HttpDataAccess.Responce);

            if (value1.Text != "" && IsCorrectString() == true)
            {
                switch (cryptoCurrencyList.SelectedIndex)
                {
                    case 0:
                        { 
                            if (currentCheck())
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.BTC.USD);
                            else
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.BTC.UAH);
                        }
                        break;
                    case 1:
                        {
                            if (currentCheck())
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.ETH.USD);
                            else
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.ETH.UAH);
                        }
                        break;
                    case 2:
                        {
                            if (currentCheck())
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.DOGE.USD);
                            else
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.DOGE.UAH);
                        }
                        break;
                    case 3:
                        {
                            if (currentCheck())
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.LTC.USD);
                            else
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.LTC.UAH);
                        }
                        break;
                    case 4:
                        {
                            if (currentCheck())
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.SHIB.USD);
                            else
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.SHIB.UAH);
                        }
                        break;
                    case 5:
                        {
                            if (currentCheck())
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.XRP.USD);
                            else
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.XRP.UAH);
                        }
                        break;
                    case 6:
                        {
                            if (currentCheck())
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.MATIC.USD);
                            else
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.MATIC.UAH);
                        }
                        break;
                    case 7:
                        {
                            if (currentCheck())
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.ADA.USD);
                            else
                                res.Content = RoundPrice(Convert.ToDouble(value1.Text) * current.ADA.UAH);
                        }
                        break;
                }
            }
            else 
            {
                MessageBox.Show("Please, enter the correct value",
                   "Attention",
                  MessageBoxButton.OK,
                  MessageBoxImage.Error);
            }
        }
        bool IsCorrectString() 
        {
            double value;
            bool isNum = double.TryParse(value1.Text, out value);
            return isNum;
        }

        bool currentCheck() 
        {
            return currencyList.SelectedIndex == 0 ? true : false;
        }

        public double RoundPrice(double price)
        {
            if (price < 0.10 || Convert.ToString(price).Length >= 8)
            {
                price = Math.Round(price, 6);
            }
            return price;
        }

       
    }
}
