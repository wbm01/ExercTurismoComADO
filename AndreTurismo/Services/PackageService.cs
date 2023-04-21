using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismo.Services
{
    public class PackageService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\ProjAulaADO\Banco de Dados\turismo2.mdf;";
        readonly SqlConnection conn;

        public PackageService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool InsertPackage(Package package)
        {
            bool status = false;

            try
            { 
                string insert = "insert into Package (Id_Hotel_Package, Id_Ticket_Package, Dt_Register_Package, Package_Value, Id_Client_Package) values (@Id_Hotel_Package, @Id_Ticket_Package," +
                    "@Dt_Register_Package, @Package_Value, @Id_Client_Package); Select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(insert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Id_Hotel_Package", package.HotelPackage.IdHotel));
                commandInsert.Parameters.Add(new SqlParameter("@Id_Ticket_Package", package.TicketPackage.IdTicket));
                commandInsert.Parameters.Add(new SqlParameter("@Dt_Register_Package", DateTime.Now));
                commandInsert.Parameters.Add(new SqlParameter("@Package_Value", package.ValuePackage));
                commandInsert.Parameters.Add(new SqlParameter("@Id_Client_Package", package.ClientPackage.IdClient));

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

        public bool UpdatePackage(Package package)
        {
            bool status = false;

            try
            {
                string update = "update Package set Dt_Register_Package = @Dt_Register_Package, Package_Value = @Package_Value, Id_Hotel_Package = @Id_Hotel_Package, Id_Ticket_Package = @Id_Ticket_Package, Id_Client_Package = @Id_Client_Package where Id_Package = @Id_Package)";

                SqlCommand commandUpdate = new SqlCommand(update, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Dt_Register_Package", DateTime.Now));
                commandUpdate.Parameters.Add(new SqlParameter("@Package_Value", package.ValuePackage));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Hotel_Package", package.HotelPackage.IdHotel));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Ticket_Package", package.TicketPackage.IdTicket));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Client_Package", package.ClientPackage.IdClient));

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

        public bool DeletePackage(Package package)
        {
            bool status = false;

            try
            {
                string delete = "delete from Package where Id_Package = @Id_Package";

                SqlCommand commandDelete = new SqlCommand(delete, conn);

                commandDelete.Parameters.Add(new SqlParameter("@Id_Package", package.IdPackage));

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

        public List<Package> GetPackageList()
        {
            List<Package> list = new List<Package>();

            StringBuilder sb = new StringBuilder();

            sb.Append("select h.Name_Hotel as [HotelName], h.Hotel_Value as [HotelValue], ah.Street as [HotelStreet], ah.Number as [HotelNumber],ah.Neighborhood as [HotelNeighborhood], ah.Cep as [HotelCep],ah.Complement as [HotelComplement],ch.Description as [CityH],p.Id_Ticket_Package as [Ticket], p.Dt_Register_Package as [DatePackage],a.Street as [AOrigin], a.Number as [ANumber],a.Neighborhood as [ANeighborhood], a.Cep as [ACep],a.Complement as [AComplement],c.Description as [CityO],ad.Street as [DStreet],ad.Number as [DNumber],ad.Neighborhood as [DNeighborhood],ad.Cep as [DCep],ad.Complement as [DComplement], cd.Description as [CityD],cl.Name_Client as [ClientName],cl.Phone as [ClientPhone],p.Package_Value as [PackageValue], t.Ticket_Value as [TicketValue] FROM Package p JOIN Address a on p.Id_Ticket_Package = a.Id_Address JOIN City c on a.Id_City_Address = c.Id_City JOIN Address ad on p.Id_Ticket_Package = ad.Id_Address JOIN City cd on ad.Id_City_Address = cd.Id_City JOIN Client cl on p.Id_Client_Package = cl.Id_Client JOIN Hotel h on p.Id_Hotel_Package = h.Id_Hotel JOIN Address ah on p.Id_Hotel_Package = ah.Id_Address JOIN City ch on ah.Id_City_Address = ch.Id_City JOIN Ticket t on p.Id_Ticket_Package = t.Id_Ticket");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Package package = new Package();

                //package.DtRegisterPackage = (DateTime)reader["Dt_Register_Package"];
                package.ValuePackage = (decimal)reader["PackageValue"];

                package.HotelPackage = new Hotel();
                package.HotelPackage.NameHotel = (string)reader["HotelName"];
                package.HotelPackage.ValueHotel = (decimal)reader["HotelValue"];

                package.HotelPackage.AddressHotel = new Address();
                package.HotelPackage.AddressHotel.Street = (string)reader["HotelStreet"];
                package.HotelPackage.AddressHotel.Number = (int)reader["HotelNumber"];
                package.HotelPackage.AddressHotel.Neighborhood = (string)reader["HotelNeighborhood"];
                package.HotelPackage.AddressHotel.Cep = (string)reader["HotelCep"];
                package.HotelPackage.AddressHotel.Complement = (string)reader["HotelComplement"];

                package.HotelPackage.AddressHotel.City = new City();
                package.HotelPackage.AddressHotel.City.Description = (string)reader["CityH"];

                package.TicketPackage = new Ticket();
                package.TicketPackage.IdTicket = (int)reader["Ticket"];
                package.TicketPackage.ValueTicket = (decimal)reader["TicketValue"];


                package.TicketPackage.Origin = new Address();
                package.TicketPackage.Origin.Street = (string)reader["AOrigin"];
                package.TicketPackage.Origin.Number = (int)reader["ANumber"];
                package.TicketPackage.Origin.Neighborhood = (string)reader["ANeighborhood"];
                package.TicketPackage.Origin.Cep = (string)reader["ACep"];
                package.TicketPackage.Origin.Complement = (string)reader["AComplement"];
                package.TicketPackage.Origin.City = new City();
                package.TicketPackage.Origin.City.Description = (string)reader["CityO"];

                package.TicketPackage.Destiny = new Address();
                package.TicketPackage.Destiny.Street = (string)reader["DStreet"];
                package.TicketPackage.Destiny.Number = (int)reader["DNumber"];
                package.TicketPackage.Destiny.Neighborhood = (string)reader["DNeighborhood"];
                package.TicketPackage.Destiny.Cep = (string)reader["DCep"];
                package.TicketPackage.Destiny.Complement = (string)reader["DComplement"];
                package.TicketPackage.Destiny.City = new City();
                package.TicketPackage.Destiny.City.Description = (string)reader["CityD"];

                package.ClientPackage = new Client();
                package.ClientPackage.NameClient = (string)reader["ClientName"];
                package.ClientPackage.Phone = (string)reader["ClientPhone"];

                

                list.Add(package);
            }
            return list;
        }
    }
}
