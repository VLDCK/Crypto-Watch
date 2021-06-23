using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Crypt_Watch
{
    class MyDbConnection
    {
        string connectionLink = "server=localhost;user=mysql;database=cryptowatch;password=mysql;";
        MySqlConnection connection;
        MySqlCommand command;
               
        public MyDbConnection()
        {
            connection = new MySqlConnection(connectionLink);
            connection.Open();
        }

        public void CloseConnectionDB()
        {
            connection.Close();
        }

        public void QueryDb(string query)
        {
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public string ReturnSelect(string query) 
        {
            string result = null;
            command = new MySqlCommand(query, connection);
            try
            {
                if (command.ExecuteScalar().ToString() != null)
                {
                    result = command.ExecuteScalar().ToString();
                }
            }
            catch (Exception exp) { }
            
            return result;
        }

        public string MD5Crypto(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }
}
