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
    public class ClientService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\ProjAulaADO\Banco de Dados\turismo2.mdf;";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool InsertClient(Client client)
        {
            bool status = false;

            try
            {
                string insert = "insert into Client (Name_Client, Phone, Id_Address_Client) values (@Name_Client," +
                    "@Phone,@Id_Address_Client); Select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(insert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name_Client", client.NameClient));
                commandInsert.Parameters.Add(new SqlParameter("@Phone", client.Phone));
                /*commandInsert.Parameters.Add(new SqlParameter("@Street",client.AddressClient.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", client.AddressClient.Number));
                commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", client.AddressClient.Neighborhood));
                commandInsert.Parameters.Add(new SqlParameter("@Cep", client.AddressClient.Cep));
                commandInsert.Parameters.Add(new SqlParameter("@Complement", client.AddressClient.Complement));*/
                commandInsert.Parameters.Add(new SqlParameter("@Id_City_Address", client.AddressClient.IdAddress));

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

        public bool UpdateClient(Client client)
        {
            bool status = false;

            try
            {
                string update = "update Client set (Name_Client = @Name_Client, Phone = @Phone, Id_Address_Client = @Id_Address_Client) where Name_Client = @Name_Client)";

                SqlCommand commandUpdate = new SqlCommand(update, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Name_Client", client.NameClient));
                commandUpdate.Parameters.Add(new SqlParameter("@Phone", client.Phone));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Address_Client", client.AddressClient.IdAddress));

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

        public bool DeleteClient(Client client)
        {
            bool status = false;

            try
            {
                string delete = "delete from Client where (Name_Client = @Name_Client, " +
                    "Phone = @Phone, Id_Address_Client = @Id_Address_Client)";

                SqlCommand commandDelete = new SqlCommand(delete, conn);

                commandDelete.Parameters.Remove(client);

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

        public List<Client> GetClientList()
        {
            List<Client> list = new List<Client>();

            StringBuilder sb = new StringBuilder();

            sb.Append("select*from Client");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Client client = new Client();

                client.NameClient = (string)reader["Name_Client"];
                client.Phone = (string)reader["Phone"];
                client.AddressClient.IdAddress = (int)reader["Id_Address_Client"];
          
                //city.DtRegisterCity = (string)reader["DtRegister_City"];

                list.Add(client);
            }
            return list;
        }
    }
}
