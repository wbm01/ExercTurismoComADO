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
                string insert = "insert into Ticket (Id_Address_Origin, Id_Address_Destiny, Id_Client_Ticket, DtTicket, Ticket_Value) values (@Id_Address_Origin, @Id_Address_Destiny," +
                    "@Id_Client_Ticket, @DtTicket, @Ticket_Value); Select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(insert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Id_Address_Origin", ticket.Origin.IdAddress));
                commandInsert.Parameters.Add(new SqlParameter("@Id_Address_Destiny", ticket.Destiny.IdAddress));
                commandInsert.Parameters.Add(new SqlParameter("@Id_Client_Ticket", ticket.ClientTicket.IdClient));
                commandInsert.Parameters.Add(new SqlParameter("@DtTicket", DateTime.Now));
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
                string update = "update Ticket set Ticket_Value = @Ticket_Value, DtTicket = @DtTicket, Id_Address_Origin = @Id_Address_Origin, Id_Address_Destiny = @Id_Address_Destiny, Id_Client_Ticket = @Id_Client_Ticket where Id_Ticket = @Id_Ticket";

                SqlCommand commandUpdate = new SqlCommand(update, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Ticket_Value", ticket.ValueTicket));
                commandUpdate.Parameters.Add(new SqlParameter("@DtTicket", DateTime.Now));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Ticket", ticket.IdTicket));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Address_Origin", ticket.IdTicket));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Address_Destiny", ticket.IdTicket));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Client_Ticket", ticket.IdTicket));

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

            sb.Append("select t.Id_Ticket as [Ticket],t.DtTicket as [DateTicket],a.Street as [AOrigin], a.Number as [ANumber],a.Neighborhood as [ANeighborhood], a.Cep as [ACep],a.Complement as [AComplement],c.Description as [CityO],ad.Street as [DStreet],ad.Number as [DNumber],ad.Neighborhood as [DNeighborhood],ad.Cep as [DCep],ad.Complement as [DComplement], cd.Description as [CityD],cl.Name_Client as [ClientName],cl.Phone as [ClientPhone],t.Ticket_Value as [TicketValue] FROM Ticket t JOIN Address a on t.Id_Address_Origin = a.Id_Address JOIN City c on a.Id_City_Address = c.Id_City JOIN Address ad on t.Id_Address_Destiny = ad.Id_Address JOIN City cd on ad.Id_City_Address = cd.Id_City JOIN Client cl on t.Id_Client_Ticket = cl.Id_Client");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Ticket ticket = new Ticket();

                ticket.IdTicket = (int)reader["Ticket"];
                //ticket.DateTicket = (DateTime)reader["DateTicket"];
                ticket.ValueTicket = (decimal)reader["TicketValue"];
                

                ticket.Origin = new Address();
                ticket.Origin.Street = (string)reader["AOrigin"];
                ticket.Origin.Number = (int)reader["ANumber"];
                ticket.Origin.Neighborhood = (string)reader["ANeighborhood"];
                ticket.Origin.Cep = (string)reader["ACep"];
                ticket.Origin.Complement = (string)reader["AComplement"];
                ticket.Origin.City = new City();
                ticket.Origin.City.Description = (string)reader["CityO"];

                ticket.Destiny = new Address();
                ticket.Destiny.Street = (string)reader["DStreet"];
                ticket.Destiny.Number = (int)reader["DNumber"];
                ticket.Destiny.Neighborhood = (string)reader["DNeighborhood"];
                ticket.Destiny.Cep = (string)reader["DCep"];
                ticket.Destiny.Complement = (string)reader["DComplement"];
                ticket.Destiny.City = new City();
                ticket.Destiny.City.Description = (string)reader["CityD"];

                ticket.ClientTicket = new Client();
                ticket.ClientTicket.NameClient = (string)reader["ClientName"];
                ticket.ClientTicket.Phone = (string)reader["ClientPhone"];

                list.Add(ticket);
            }
            return list;
        }
    }
}
