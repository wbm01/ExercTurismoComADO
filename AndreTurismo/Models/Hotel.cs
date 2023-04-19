using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class Hotel
    {
        public int IdHotel { get; set; }

        public string NameHotel { get; set; }

        public  Address AddressHotel { get; set; }

        public DateTime DtRegisterHotel { get; set; }

        public decimal ValueHotel { get; set; }

        public override string ToString()
        {
            return "\nNome: " + NameHotel + AddressHotel +
                "\nValor diária: " + ValueHotel;
        }
    }
}
