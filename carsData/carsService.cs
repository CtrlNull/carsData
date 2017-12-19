using carsData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace carsData
{
    public class CarsService
    {
        //public static void OpenSqlConnection()
        //{
        //    string connectionString = GetConnectionString();
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();
        //    }
        //}

        //static private string GetConnectionString()
        //{
        //    return "Server=den1.mssql5.gear.host;Database=carstest;User Id=carstest;Password=Hy19Ks!-Kom3";
        //}

        //  ====== Get All ====== //
        public List<Car> GetAllCars()
        {
            using (SqlConnection con = new SqlConnection("Server=den1.mssql5.gear.host;Database=carstest;User Id=carstest;Password=Hy19Ks!-Kom3"))
            {
                //OpenSqlConnection();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "cars_getAll";
                // everytime there is a new row avaliable i will stuff it into that list
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    List<Car> results = new List<Car>();
                    while (dr.Read())
                    {
                        // Create a new Cars object
                        Car car =  new Car();
                        car.Id = dr.GetInt32(0);
                        car.Make = dr.GetString(1);
                        car.Model = dr.GetString(2);
                        car.Year = dr.GetByte(3);
                        car.Color = dr.GetString(4);
                        // Add that object to the list
                        results.Add(car);
                    }
                    return results;
                }
            }
        }
        // ======== Get By id =========//
        // ======== Update ===========//
        // ========= Create =========//
        // ======== Delete ===========//
    }
}
/*
 * left off at 31.32;
*/