using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismo.Services
{
    public class HotelService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\ProjAulaADO\Banco de Dados\turismo2.mdf;";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool InsertHotel(Hotel hotel)
        {
            bool status = false;

            try
            {
                string insert = "insert into Hotel (Name_Hotel, Id_Address_Hotel, DtRegister_Hotel, Hotel_Value) values (@Name_Hotel," +
                    "@Id_Address_Hotel, @DtRegister_Hotel, @Hotel_Value); Select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(insert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name_Hotel", hotel.NameHotel));
                commandInsert.Parameters.Add(new SqlParameter("@Id_Address_Hotel", hotel.AddressHotel.IdAddress));
                commandInsert.Parameters.Add(new SqlParameter("@Hotel_Value", hotel.ValueHotel));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegister_Hotel", DateTime.Now));

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

        public bool UpdateHotel(Hotel hotel)
        {
            bool status = false;

            try
            {
                string update = "update Hotel set Name_Hotel = @Name_Hotel, DtRegister_Hotel = @DtRegister_Hotel, Hotel_Value = @Hotel_Value, Id_Address_Hotel = @Id_Address_Hotel where Id_Hotel = @Id_Hotel";

                SqlCommand commandUpdate = new SqlCommand(update, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Name_Hotel", hotel.NameHotel));
                commandUpdate.Parameters.Add(new SqlParameter("@Hotel_Value", hotel.ValueHotel));
                commandUpdate.Parameters.Add(new SqlParameter("@DtRegister_Hotel", DateTime.Now));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Hotel", hotel.IdHotel));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Address_Hotel", hotel.AddressHotel.IdAddress));

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

        public bool DeleteHotel(Hotel hotel)
        {
            bool status = false;

            try
            {
                string delete = "delete from Hotel where Id_Hotel = @Id_Hotel";

                SqlCommand commandDelete = new SqlCommand(delete, conn);

                commandDelete.Parameters.Add(new SqlParameter("@Id_Hotel", hotel.IdHotel));

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

        public List<Hotel> GetHotelList()
        {
            List<Hotel> list = new List<Hotel>();

            StringBuilder sb = new StringBuilder();

            sb.Append("select h.Name_Hotel, h.Hotel_Value, a.Street, a.Number, a.Neighborhood, a.Cep, a.Complement, h.DtRegister_Hotel ci.Description FROM Hotel h JOIN Address a on h.Id_Address_Hotel = a.Id_Address join City ci on ci.Id_City = a.Id_City_Address");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Hotel hotel = new Hotel();

                hotel.NameHotel = (string)reader["Name_Hotel"];
                hotel.ValueHotel = (decimal)reader["Hotel_Value"];
                hotel.DtRegisterHotel = (DateTime)reader["DtRegister_Hotel"];
                hotel.AddressHotel = new Address();
                hotel.AddressHotel.Street = (string)reader["Street"];
                hotel.AddressHotel.Number = (int)reader["Number"];
                hotel.AddressHotel.Neighborhood = (string)reader["Neighborhood"];
                hotel.AddressHotel.Cep = (string)reader["Cep"];
                hotel.AddressHotel.Complement = (string)reader["Complement"];
                hotel.AddressHotel.City = new City();
                hotel.AddressHotel.City.Description = (string)reader["Description"];


                list.Add(hotel);
            }
            return list;
        }
    }
}
