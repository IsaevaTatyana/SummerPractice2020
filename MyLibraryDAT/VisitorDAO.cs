using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace PracticeMyLibraryDAT
{
    public class VisitorDAO : IVisitorDAO
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=MyLibrary;Integrated Security=True";

        public IEnumerable<Visitor> GetVisitors()
        {
            var result = new List<Visitor>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetVisitors", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  // читаем
                {
                    var visitor = new Visitor
                    {
                        VisitorID = (int)read["VisitorID"],
                        FirstName = (string)read["FirstName"],
                        LastName = (string)read["LastName"],
                        MiddleName = (string)read["MiddleName"],
                        AccountID = (int)read["AccountID"],
                        Phone = (string)read["Phone"],
                        Adress = (string)read["Adress"],
                    };
                    result.Add(visitor);
                }
                return result;
            }
        }

        public void AddVisitor(Visitor visitor)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddBook", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", visitor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", visitor.LastName);
                cmd.Parameters.AddWithValue("@MiddleName", visitor.MiddleName);
                cmd.Parameters.AddWithValue("@ AccountID", visitor.AccountID);
                cmd.Parameters.AddWithValue("@ Phone", visitor.Phone);
                cmd.Parameters.AddWithValue("@Adress", visitor.Adress);
                connection.Open();
                cmd.ExecuteNonQuery();//выполнить не дожидаясь ответа
            }
        }
        public void RemoveVisitor(int VisitorID)
        {

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveVisitor", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VisitorID", VisitorID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }

    }
}
