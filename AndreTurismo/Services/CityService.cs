using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismo.Services
{
    public class CityService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\ProjAulaADO\Banco de Dados\turismo2.mdf;";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        //

        public List<City> GetCityList()
        {
            List<City> list = new List<City>();

            StringBuilder sb = new StringBuilder();

            sb.Append("select description from city");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn); 
            SqlDataReader reader = commandSelect.ExecuteReader();

            while(reader.Read())
            {
                City city = new City();

                city.Description = (string)reader["Description"];
                city.DtRegisterCity = (DateTime)reader["DtRegister_City"];

                list.Add(city);
            }
            return list;
        }

        public bool UpdateCity(City city)
        {
            bool status = false;

            try
            {
                string update = "update City set Description = @Description, DtRegister_City = @DtRegister_City where Id_City = @Id_City";

                SqlCommand commandUpdate = new SqlCommand(update, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Description", city.Description));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_City", city.IdCity));
                commandUpdate.Parameters.Add(new SqlParameter("@DtRegister_City", DateTime.Now));

                commandUpdate.ExecuteNonQuery();
                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public bool DeleteCity(City city) 
        {
            bool status = false;

            try
            {
                string delete = "delete from City where Id_City = @Id_City";

                SqlCommand commandDelete = new SqlCommand(delete, conn);

                commandDelete.Parameters.Add(new SqlParameter("@Id_City", city.IdCity));

                commandDelete.ExecuteNonQuery();
                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }
    }

    
}
