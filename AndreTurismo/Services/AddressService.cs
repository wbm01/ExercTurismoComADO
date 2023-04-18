using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismo.Services
{
    public class AddressService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\ProjAulaADO\Banco de Dados\turismo2.mdf;";
        readonly SqlConnection conn;

        public AddressService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool InsertAddress(Address address)
        {
            bool status = false;

            try
            {
                string insert = "insert into Address (Street, Number, Neighborhood," +
                    "Cep, Complement, Id_City_Address) values (@Street, @Number, @Neighborhood," +
                    "@Cep, @Complement, @Id_City_Address); Select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(insert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
                commandInsert.Parameters.Add(new SqlParameter("@Cep", address.Cep));
                commandInsert.Parameters.Add(new SqlParameter("@Complement", address.Complement));
                commandInsert.Parameters.Add(new SqlParameter("@Id_City_Address", InsertCity(address)));

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

        public int InsertCity(Address address)
        { 
                string insert = "insert into City(Description) values (@Description); Select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(insert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Description", address.City.Description));
                //commandInsert.Parameters.Add(new SqlParameter("@DataRegister_City", city.DtRegisterCity));

                return (int) commandInsert.ExecuteScalar();  
        }

        public bool UpdateAddress(Address address)
        {
            bool status = false;

            try
            {
                string update = "update Address set (Street = @Street, Number = @Number, Neighborhood = @Neighborhood," +
                    "Cep = @Cep, Complement = @Complement, Id_City_Address = @Id_City_Address) where Street = @Street)";

                SqlCommand commandUpdate = new SqlCommand(update, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandUpdate.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandUpdate.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
                commandUpdate.Parameters.Add(new SqlParameter("@Cep", address.Cep));
                commandUpdate.Parameters.Add(new SqlParameter("@Complement", address.Complement));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_City_Address", InsertCity(address)));

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

        public bool DeleteAddress(Address address)
        {
            bool status = false;

            try
            {
                string delete = "delete from Address where (Street = @Street, Number = @Number, Neighborhood = @Neighborhood," +
                    "Cep = @Cep, Complement = @Complement, Id_City_Address = @Id_City_Address)";

                SqlCommand commandDelete = new SqlCommand(delete, conn);

                commandDelete.Parameters.Remove(address);

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

        public List<Address> GetAddressList()
        {
            List<Address> list = new List<Address>();

            StringBuilder sb = new StringBuilder();

            sb.Append("select*from Address");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Address address = new Address();

                address.Street = (string)reader["Street"];
                address.Number = (int)reader["Number"];
                address.Neighborhood = (string)reader["Neighborhood"];
                address.Cep = (string)reader["Street"];
                address.Complement = (string)reader["Street"];
                address.City.IdCity = (int)reader["Id_City_Address"];
                //city.DtRegisterCity = (string)reader["DtRegister_City"];

                list.Add(address);
            }
            return list;
        }
    }
}
