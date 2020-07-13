using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace PracticeMyLibraryDAT
{
    public class GivenBookDAO : IGivenBookDAO
    { 
        private string connectionstring = @"Persist Security Info=False;Integrated Security=true; Initial Catalog = MyLibrary; Server=DESKTOP-ABF4F6D";

        public IEnumerable<GivenBook> GetGivenBooks()
        {
            var result = new List<GivenBook>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetGivenBooks", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  // читаем
                {
                    var givenBook = new GivenBook
                    {
                        GiveID = (int)read["GiveID"],
                        BookID = (int)read["BookID"],
                        VisitorID = (int)read["VisitorID"],
                        GivenDate = (DateTime)read["GivenDate"],
                        ReturnDate = (DateTime)read["ReturnDate"],

                    };
                    result.Add(givenBook);
                }
                return result;
            }
        }

        public void AddGivenBook(GivenBook givenBook)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddGivenBook", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookID", givenBook.BookID);
                    cmd.Parameters.AddWithValue("@VisitorID", givenBook.VisitorID);
                    cmd.Parameters.AddWithValue("@GivenDate", givenBook.GivenDate);
                    cmd.Parameters.AddWithValue("@ReturnDate", givenBook.ReturnDate);

                    connection.Open();
                cmd.ExecuteNonQuery();//выполнить не дожидаясь ответа
            }
        }
        public void RemoveGivenBook(int GiveID)
        {

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveGivenBook", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GiveID", GiveID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }   
}
