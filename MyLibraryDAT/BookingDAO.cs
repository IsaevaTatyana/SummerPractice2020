using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace PracticeMyLibraryDAT
{
    class BookingDAO : IBookingDAO
    {

        private string connectionstring = @"Persist Security Info=False;Integrated Security=true; Initial Catalog = MyLibrary; Server=DESKTOP-ABF4F6D";

        public IEnumerable<Booking> GetBookings()
        {
            var result = new List<Booking>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetBookings", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  // читаем
                {
                    var booking = new Booking
                    {
                        BookingID = (int)read["BookingID"],
                        BookID = (int)read["BookID"],
                        VisitorID = (int)read["VisitorID"],
                        OrderDate = (DateTime)read["OrderDate"],

                    };
                    result.Add(booking);
                }
                return result;
            }
        }

        public void AddBooking(Booking booking)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddGivenBook", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID", booking.BookID);
                cmd.Parameters.AddWithValue("@VisitorID", booking.VisitorID);
                cmd.Parameters.AddWithValue("@OrderDate", booking.OrderDate);

                connection.Open();
                cmd.ExecuteNonQuery();//выполнить не дожидаясь ответа
            }
        }
        public void RemoveBooking(int BookingID)
        {

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveBooking", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookingID", BookingID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

