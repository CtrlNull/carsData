using carsData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace carsData
{
    public class CarsService
    {
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
        public void CarUpdate(CarUpdate request)
        {
            using (SqlConnection con = new SqlConnection("Server=den1.mssql5.gear.host;Database=carstest;User Id=carstest;Password=Hy19Ks!-Kom3"))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "cars_update";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", request.Id);
                cmd.Parameters.AddWithValue("@Make", request.Make);
                cmd.Parameters.AddWithValue("@Model", request.Model);
                cmd.Parameters.AddWithValue("@Year", request.Year);
                cmd.Parameters.AddWithValue("@Color", request.Color);
                cmd.ExecuteNonQuery();
            }
        }
        // ========= Create =========//
        public int CarCreate(CarCreate request)
        {
            using (SqlConnection con = new SqlConnection("Server=den1.mssql5.gear.host;Database=carstest;User Id=carstest;Password=Hy19Ks!-Kom3"))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "cars_create";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Make", request.Make);
                cmd.Parameters.AddWithValue("@Model", request.Model);
                cmd.Parameters.AddWithValue("@Year", request.Year);
                cmd.Parameters.AddWithValue("@Color", request.Color);

                var idParam = cmd.Parameters.Add("@id", SqlDbType.Int);
                idParam.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                return (int)idParam.Value;
            }
        }
        // ======== Delete ===========//
        public void CarDelete(int Id)
        {
            using (SqlConnection con = new SqlConnection("Server=den1.mssql5.gear.host;Database=carstest;User Id=carstest;Password=Hy19Ks!-Kom3"))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "cars_delete";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
            }
        }
        // ======== Get By id =========//
        //public Car GetByIdCars(int Id)
        //{
        //    using (SqlConnection con = new SqlConnection("Server=den1.mssql5.gear.host;Database=carstest;User Id=carstest;Password=Hy19Ks!-Kom3"))
        //    {
        //        //OpenSqlConnection();
        //        con.Open();
        //        SqlCommand cmd = con.CreateCommand();
        //        cmd.CommandText = "cars_getById";
        //        cmd.
        //        // everytime there is a new row avaliable i will stuff it into that list
        //        using (SqlDataReader dr = cmd.ExecuteReader())
        //        {
        //            List<Car> results = new List<Car>();
        //            while (dr.Read())
        //            {
        //                // Create a new Cars object
        //                Car car = new Car();
        //                car.Id = dr.GetInt32(0);
        //                car.Make = dr.GetString(1);
        //                car.Model = dr.GetString(2);
        //                car.Year = dr.GetByte(3);
        //                car.Color = dr.GetString(4);
        //                // Add that object to the list
        //                results.Add(car);
        //            }
        //            return 
        //        }
        //    }
        //}
        // ======== Update ===========//

    }
}
/*
 * left off at 31.32;
*/