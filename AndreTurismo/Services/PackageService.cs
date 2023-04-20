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
                string update = "update Package set Dt_Register_Package = @Dt_Register_Package, Package_Value = @Package_Value where Id_Package = @Id_Package)";

                SqlCommand commandUpdate = new SqlCommand(update, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Dt_Register_Package", DateTime.Now));
                commandUpdate.Parameters.Add(new SqlParameter("@Package_Value", package.ValuePackage));
               
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

            sb.Append("select p.Dt_Register_Package as Package, " +
                "p.Package_Value as Package,h.Name_Hotel as Hotel, " +
                "h.DtRegister_Hotel as Hotel, h.Hotel_Value as Hotel, " +
                "ha.Street as Hotel,ha.Number as Hotel, " +
                "ha.Neighborhood as Hotel, ha.CEP as Hotel, " +
                "ha.Id_Address as Hotel,hci.Description as Hotel," +
                "t.DtTicket as Ticket, t.Ticket_Value as Ticket, " +
                "tsa.Street as Ticket, tsa.Number as Ticket," +
                "tsa.Neighborhood as Ticket, tsa.CEP as Ticket, " +
                "tsa.Id_Address as Ticket,tsci.Description as Ticket," +
                "tda.Street as Ticket, tda.Number as Ticket, " +
                "tda.Neighborhood as Ticket,tda.CEP as Ticket, " +
                "tda.Id_Address as Ticket, " +
                "tdci.Description as Ticket," +
                "c.Name_Client as Client, c.Phone as Client, " +
                "c.DtRegister_Client as Client, " +
                "ca.Street as Client," +
                "ca.Number as Client, ca.Neighborhood as Client, " +
                "ca.CEP as Client, ca.Id_Address as Client," +
                "cci.Description as Client from Package p " +
                "join Hotel h on p.Id_Hotel_Package=h.Id_Hotel " +
                "join Address ha on h.Id_Address_Hotel=ha.Id_Address " +
                "join City hci on ha.Id_City_Address=hci.Id_City " +
                "join Ticket t on p.Id_Ticket_Package=t.Id_Ticket " +
                "join Address tsa on t.Id_Address_Destiny=tsa.Id_Address " +
                "join City tsci on tsa.Id_City_Address=tsci.Id_City " +
                "join Address tda on t.Id_Address_Destiny=tda.Id_Address " +
                "join City tdci on tda.Id_City_Address=tdci.Id_City " +
                "join Client c on p.Id_Client_Package=c.Id_Client " +
                "join Address ca on c.Id_Address_Client=ca.Id_Address " +
                "join City cci on ca.Id_City_Address=cci.Id_City");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Package package = new Package();

                /*hotel.NameHotel = (string)reader["Name_Hotel"];
                hotel.AddressHotel.IdAddress = (int)reader["Id_Address_Hotel"];
                hotel.ValueHotel = (decimal)reader["Hotel_Value"];*/

               

                list.Add(package);
            }
            return list;
        }
    }
}
