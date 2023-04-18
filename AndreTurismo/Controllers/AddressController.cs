using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class AddressController
    {
        public bool InsertAddress(Address address)
        {
            return new AddressController().InsertAddress(address);
        }

        public bool DeleteAddress(Address address)
        {
            return new AddressController().DeleteAddress(address);
        }

        public List<Address> GetAddressList()
        {
            return new AddressService().GetAddressList();
        }

        public bool UpdateAddress(Address address)
        {
            return new AddressService().UpdateAddress(address);
        }
    }
}
