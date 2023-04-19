using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class PackageController
    {
        public bool InsertPackage(Package package)
        {
            hotel.AddressHotel = new AddressService().InsertAddress(hotel.AddressHotel);
            return new HotelService().InsertHotel(hotel);
        }

        public bool DeleteHotel(Hotel hotel)
        {
            return new HotelService().DeleteHotel(hotel);
        }

        public List<Hotel> GetHotelList()
        {
            return new HotelService().GetHotelList();
        }

        public bool UpdateHotel(Hotel hotel)
        {
            return new HotelService().UpdateHotel(hotel);
        }
    }
}
