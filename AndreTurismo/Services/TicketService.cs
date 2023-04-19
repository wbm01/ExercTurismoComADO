using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismo.Services
{
    public class TicketService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\ProjAulaADO\Banco de Dados\turismo2.mdf;";
        readonly SqlConnection conn;

        public TicketService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool InsertTicket(Ticket ticket)
        {
            bool status = false;

            try
            { 
                string insert = "insert into Ticket (Id_Address_Origin, Id_Address_Destiny, Id_Client_Ticket, Ticket_Value) values (@Id_Address_Origin, @Id_Address_Destiny," +
                    "@Id_Client_Ticket, @Ticket_Value); Select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(insert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Id_Address_Origin", ticket.Origin.IdAddress));
                commandInsert.Parameters.Add(new SqlParameter("@Id_Address_Destiny", ticket.Destiny.IdAddress));
                commandInsert.Parameters.Add(new SqlParameter("@Id_Client_Ticket", ticket.ClientTicket.IdClient));
                commandInsert.Parameters.Add(new SqlParameter("@Ticket_Value", ticket.ValueTicket));

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

        public bool UpdateTicket(Ticket ticket)
        {
            bool status = false;

            try
            {
                string update = "update Ticket set Ticket_Value = @Ticket_Value where Id_Ticket = @Id_Ticket";

                SqlCommand commandUpdate = new SqlCommand(update, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Ticket_Value", ticket.ValueTicket));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Ticket", ticket.IdTicket));

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

        public bool DeleteTicket(Ticket ticket)
        {
            bool status = false;

            try
            {
                string delete = "delete from Ticket where Id_Ticket = @Id_Ticket";

                SqlCommand commandDelete = new SqlCommand(delete, conn);

                commandDelete.Parameters.Add(new SqlParameter("@Id_Ticket", ticket.IdTicket));

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

        public List<Ticket> GetTicketList()
        {
            List<Ticket> list = new List<Ticket>();

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT t.Ticket_Value, c.Name_Client, " +
                "c.Phone, a.Street, a.Number,a.Neighborhood, a.Cep, " +
                "a.Complement, ci.Description, ad.Street, " +
                "ad.Number, ad.Neighborhood, ad.Cep, ad.Complement, " +
                "cid.Description FROM ticket t JOIN Client c on " +
                "t.Id_Client_Ticket = c.Id_Client JOIN Address a on " +
                "t.Id_Address_Origin = a.Id_Address " +
                "JOIN Address ad on t.Id_Address_Destiny = ad.Id_Address");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Ticket ticket = new Ticket();

                ticket.ValueTicket = (decimal)reader["Ticket_Value"];

                ticket.ClientTicket = new Client();
                ticket.ClientTicket.NameClient = (string)reader["Name_Client"];
                ticket.ClientTicket.Phone = (string)reader["Phone"];

                ticket.Origin = new Address();
                ticket.Origin.Street = (string)reader["Street"];
                ticket.Origin.Number = (int)reader["Number"];
                ticket.Origin.Neighborhood = (string)reader["Neighborhood"];
                ticket.Origin.Cep = (string)reader["Cep"];
                ticket.Origin.Complement = (string)reader["Complement"];
                ticket.Origin.City = new City();
                ticket.Origin.City.Description = (string)reader["Description"];

                ticket.Destiny = new Address();
                ticket.Destiny.Street = (string)reader["Street"];
                ticket.Destiny.Number = (int)reader["Number"];
                ticket.Destiny.Neighborhood = (string)reader["Neighborhood"];
                ticket.Destiny.Cep = (string)reader["Cep"];
                ticket.Destiny.Complement = (string)reader["Complement"];
                ticket.Destiny.City = new City();
                ticket.Destiny.City.Description = (string)reader["Description"];

                //city.DtRegisterCity = (string)reader["DtRegister_City"];

                list.Add(ticket);
            }
            return list;
        }
    }
}
