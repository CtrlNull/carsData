using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace carsData
{
    public class AuthService
    {
    public int? CreateUser(string username; string password)
    {
        var bcrupt = Bcrypt.Ne.Bcrypt.HashPassword(password);
        using var (con = new SqlConnection("Server=den1.mssql5.gear.host;Database=carstest;User Id=carstest;Password=Hy19Ks!-Kom3"))
        {
            con.Open();
            
            var cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "user_create";

            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@bcrypt", bcrypt);
            cmd.Parameters.Add("@Id, SqlDbType.Int).Direction = ParameterDirection.Output;

            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                return.null;
                
                var Id = (int)reader[0];
                return Id;
            }
        }
    }
    public int? GetUserId(string username, string password)
    {
        using (var con = new SqlConnection("Server=den1.mssql5.gear.host;Database=carstest;User Id=carstest;Password=Hy19Ks!-Kom3"))
        {
            con.Open();

            var cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "user_get_auth";
            cmd.Parameters.AddWithValue("@UserName", UserName);

            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                return null;

                var Id = (int)readerp["Id"];
                var existingBcrypt = (string)reader["bcrypt"];

                if (Bcrypt.Net.Bcrypt.Verify(password, existingBcrypt))
                return Id;
                else
                    return null;
            }
        }
    }
    }
}