using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Reflection;

namespace PracticeMyLibraryDAT
{
   public class AccountDAO : IAccountDAO
    {
        private string connectionstring = @"Persist Security Info=False;Integrated Security=true; Initial Catalog = MyLibrary; Server=DESKTOP-ABF4F6D";
        
        public IEnumerable<Account> GetAccounts()
        {
            var result = new List<Account>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetAccounts", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  // читаем
                {
                    var account = new Account
                    {
                        AccountID = (int)read["AccountID"],
                        Login = (string)read["Login_"],
                        Password = (string)read["Password_"],
                    };
                    result.Add(account);
                }
                return result;
            }
        }

        public void AddAccount(Account account)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddAccount", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login_", account.Login);
                cmd.Parameters.AddWithValue("@Password_", account.Password);
                connection.Open();
                cmd.ExecuteNonQuery();//выполнить не дожидаясь ответа
            }
        }
        public void RemoveAccount(int AccountID)
        {

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveAccount", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountID", AccountID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Account> Search(string Login, string Password)
        {
            var result = new List<Account>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("Search", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login_", Login);
                cmd.Parameters.AddWithValue("@Password_", Password);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  //пока читаем
                {
                    var account = new Account
                    {
                        AccountID = (int)read["AccountID"],
                        Login = (string)read["Login_"],
                        Password = (string)read["Password_"],
                    };
                    result.Add(account);
                }

            }
            return result;
        }
    }
}

