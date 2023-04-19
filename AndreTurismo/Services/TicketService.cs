﻿using System;
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
                string insert = "insert into Package (Id_Hotel_Package, Id_Ticket_Package, Package_Value, Id_Client_Package) values (@Id_Hotel_Package, @Id_Ticket_Package," +
                    "@Package_Value, @Id_Client_Package); Select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(insert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Id_Hotel_Package", package.HotelPackage.IdHotel));
                commandInsert.Parameters.Add(new SqlParameter("@Id_Ticket_Package", package.TicketPackage.IdTicket));
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

        public bool UpdateTicket(Ticket ticket)
        {
            bool status = false;

            try
            {
                string update = "update Hotel set (Name_Hotel = @Name_Hotel, Id_Address_Hotel = @Id_Address_Hotel, Hotel_Value = @Hotel_Value) where Name_Hotel = @Name_Hotel)";

                SqlCommand commandUpdate = new SqlCommand(update, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Name_Hotel", hotel.NameHotel));
                commandUpdate.Parameters.Add(new SqlParameter("@Id_Address_Hotel", hotel.AddressHotel.IdAddress));
                commandUpdate.Parameters.Add(new SqlParameter("@Hotel_Value", hotel.ValueHotel));

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
                string delete = "delete from Hotel where (Name_Hotel = @Name_Hotel, " +
                    "Id_Address_Hotel = @Id_Address_Hotel, Hotel_Value = @Hotel_Value)";

                SqlCommand commandDelete = new SqlCommand(delete, conn);

                commandDelete.Parameters.Remove(hotel);

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

        public List<Hotel> GetTicketList()
        {
            List<Hotel> list = new List<Hotel>();

            StringBuilder sb = new StringBuilder();

            sb.Append("select*from Hotel");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Hotel hotel = new Hotel();

                hotel.NameHotel = (string)reader["Name_Hotel"];
                hotel.AddressHotel.IdAddress = (int)reader["Id_Address_Hotel"];
                hotel.ValueHotel = (decimal)reader["Hotel_Value"];

                //city.DtRegisterCity = (string)reader["DtRegister_City"];

                list.Add(hotel);
            }
            return list;
        }
    }
}