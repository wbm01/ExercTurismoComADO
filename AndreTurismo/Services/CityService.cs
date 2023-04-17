using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public bool InsertCity(City city)
        {
            bool status = false;

            try
            {
                string insert = "insert into City(Description) values (@Description)";

                SqlCommand commandInsert = new SqlCommand(insert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
                //commandInsert.Parameters.Add(new SqlParameter("@DataRegister_City", city.DtRegisterCity));

                commandInsert.ExecuteNonQuery();
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

        public List<City> GetCityList()
        {
            List<City> list = new List<City>();

            StringBuilder sb = new StringBuilder();

            sb.Append("select*from City");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn); 
            SqlDataReader reader = commandSelect.ExecuteReader();

            while(reader.Read())
            {
                City city = new City();

                city.Description = (string)reader["Description"];
                //city.DtRegisterCity = (string)reader["DtRegister_City"];

                list.Add(city);
            }
            return list;
        }

        public bool UpdateCity(City city)
        {
            bool status = false;

            try
            {
                string update = "update City set (Description = @Description) where Description = @Description)";

                SqlCommand commandUpdate = new SqlCommand(update, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Description", city.Description));

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
                string delete = "delete from City where (Description = @Description)";

                SqlCommand commandDelete = new SqlCommand(delete, conn);

                commandDelete.Parameters.Remove(city);

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
