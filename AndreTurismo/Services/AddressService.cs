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

        public Address InsertAddress(Address address)
        {
            bool status = false;
            int id = 0;

            try
            {
                string insert = "insert into Address (Street, Number, Neighborhood," +
                    "Cep, Complement, Id_City_Address, DtRegister_Address) values (@Street, @Number, @Neighborhood," +
                    "@Cep, @Complement, @Id_City_Address, @DtRegister_Address); Select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(insert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
                commandInsert.Parameters.Add(new SqlParameter("@Cep", address.Cep));
                commandInsert.Parameters.Add(new SqlParameter("@Complement", address.Complement));
                commandInsert.Parameters.Add(new SqlParameter("@Id_City_Address", InsertCity(address)));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegisterAddress", DateTime.Now));

                id = (int) commandInsert.ExecuteScalar();
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
            address.IdAddress = id;
            return address;
        }

        public int InsertCity(Address address)
        { 
                string insert = "insert into City(Description, DtRegister_City) values (@Description, @DtRegisterCity); Select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(insert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Description", address.City.Description));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegisterCity", DateTime.Now));

                return (int) commandInsert.ExecuteScalar();  
        }

        public bool UpdateAddress(Address address)
        {
            bool status = false;

            try
            {
                string update = "update Address set Street = @Street, Number = @Number, Neighborhood = @Neighborhood," +
                    "Cep = @Cep, Complement = @Complement, DtRegister_Address = @DtRegister_Address  where Id_Address = @Id_Address";

                SqlCommand commandUpdate = new SqlCommand(update, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandUpdate.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandUpdate.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
                commandUpdate.Parameters.Add(new SqlParameter("@Cep", address.Cep));
                commandUpdate.Parameters.Add(new SqlParameter("@Complement", address.Complement));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Address", address.IdAddress));
                commandUpdate.Parameters.Add(new SqlParameter("@DtRegister_Address", DateTime.Now));

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
                string delete = "delete from Address where Id_Address = @Id_Address)";

                SqlCommand commandDelete = new SqlCommand(delete, conn);

                commandDelete.Parameters.Add(new SqlParameter("@Id_Address", address.IdAddress));

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

            sb.Append("Select a.Street, a.Number,a.Neighborhood, a.Cep, a.Complement a.DtRegister_Address, ci.Description FROM Address a JOIN City ci on a.Id_City_Address = ci.Id_City");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Address address = new Address();

                address.Street = (string)reader["Street"];
                address.Number = (int)reader["Number"];
                address.Neighborhood = (string)reader["Neighborhood"];
                address.Cep = (string)reader["Cep"];
                address.Complement = (string)reader["Complement"];
                address.DtRegisterAddress = (DateTime)reader["DtRegister_Address"];
                address.City = new City();
                address.City.Description = (string)reader["Description"];
                

                //city.DtRegisterCity = (string)reader["DtRegister_City"];

                list.Add(address);
            }
            return list;
        }
    }
}
