using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace PracticeMyLibraryDAT
{
    public class AuthorDAO : IAuthorDAO
    {
        private string connectionstring = @"Persist Security Info=False;Integrated Security=true; Initial Catalog = MyLibrary; Server=DESKTOP-ABF4F6D";

        public IEnumerable<Author> GetAuthors()
        {
            var result = new List<Author>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetAuthors", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  // читаем
                {
                    var author = new Author
                    {
                        AuthorID = (int)read["AuthorId"],
                        FirstName = (string)read["FirstName"],
                        LastName = (string)read["LastName"],
                        MiddleName = (string)read["MiddleName"],
                    };
                    result.Add(author);
                }
                return result;
            }
        }

        public void AddAuthor (Author author)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddAuthor", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", author.FirstName);
                cmd.Parameters.AddWithValue("@LastName", author.LastName);
                cmd.Parameters.AddWithValue("@MiddleName", author.MiddleName);
                connection.Open();
                cmd.ExecuteNonQuery();//выполнить не дожидаясь ответа
            }
        }
        public void RemoveAuthor(int AuthorID)
        {

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveAuthor", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AuthorID", AuthorID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
