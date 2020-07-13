using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace PracticeMyLibraryDAT
{
    public class CityDAO : ICityDAO
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=MyLibrary;Integrated Security=True";

        public IEnumerable<City> GetCities()
        {
            var result = new List<City>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetCitiess", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())  // читаем
                {
                    var city = new City
                    {
                        CityID = (int)read["CityID"],
                        NameOfCity = (string)read["NameOfCity"],
                    };
                    result.Add(city);
                }
                return result;
            }
        }

        public void AddCity(City city)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddCity", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NameOfCity", city.NameOfCity);
                connection.Open();
                cmd.ExecuteNonQuery();//выполнить не дожидаясь ответа
            }
        }
        public void RemoveCity(int CityID)
        {

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveCity", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CityID", CityID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
