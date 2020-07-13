using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace PracticeMyLibraryDAT
{
    public class PublisherDAO : IPublisherDAO
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=MyLibrary;Integrated Security=True";
      
        public IEnumerable<Publisher> GetPublishers()
        {
            var result = new List<Publisher>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetPublishers", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  // читаем
                {
                    var publisher = new Publisher
                    {
                        PublisherID = (int)read["PublisherID"],
                        NameOfPublisher = (string)read["NameOfPublisher"],
                        CityID = (int)read["CityID"],
                    };
                    result.Add(publisher);
                }
                return result;
            }
        }

        public void AddPublisher(Publisher publisher)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddPublisher", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameOfPublisher", publisher.NameOfPublisher);
                cmd.Parameters.AddWithValue("@CityID", publisher.CityID);
                connection.Open();
                cmd.ExecuteNonQuery();//выполнить не дожидаясь ответа
            }
        }
        public void RemovePublisher(int PublisherID)
        {

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemovePublisher", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PublisherID", PublisherID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
