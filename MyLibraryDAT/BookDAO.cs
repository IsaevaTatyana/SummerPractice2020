using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace PracticeMyLibraryDAT
{
    public class BookDAO : IBookDAO
    {
        private string connectionstring = @"Persist Security Info=False;Integrated Security=true; Initial Catalog = MyLibrary; Server=DESKTOP-ABF4F6D";

        public IEnumerable<Book> GetBooks()
        {
            var result = new List<Book>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetBooks", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  // читаем
                {
                    var book = new Book
                    {
                        BookID = (int)read["BookID"],
                        Name = (string)read["Names"],
                        PublicYear = (int)read["PublicYear"],
                        Publisher = (string)read["Publisher"],
                        CountOfPages = (int)read["CountOfPages"],
                        Price = (int)read["Price"],
                        CountCopy = (int)read["CountCopy"],
                        StatusBook = (string)read["StatusBook"],
                    };
                    result.Add(book);
                }
                return result;
            }
        }

        public void AddBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddBook", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Names", book.Name);
                cmd.Parameters.AddWithValue("@PublicYear ", book.PublicYear);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@CountOfPages", book.CountOfPages);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@CountCopy", book.CountCopy);
                cmd.Parameters.AddWithValue("@StatusBook", book.StatusBook);
                connection.Open();
                cmd.ExecuteNonQuery();//выполнить не дожидаясь ответа
            }
        }
        public void RemoveBook(int BookID)
        {
         
               using (SqlConnection connection = new SqlConnection(connectionstring))
               {
                   SqlCommand cmd = new SqlCommand("RemoveBook", connection);  //SQL-команда
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@BookID", BookID);
                   connection.Open();
                   cmd.ExecuteNonQuery();
               }
        }
    }
}
