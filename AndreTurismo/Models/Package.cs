using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class Package
    {
        public int IdPackage { get; set; }
        public Hotel HotelPackage { get; set; }
        public Ticket TicketPackage { get; set; }
        public DateTime DtRegisterPackage { get; set; }
        public decimal ValuePackage { get; set; }

        public Client ClientPackage { get; set; }

        public override string ToString()
        {
            return "Hotel Reservado: " + HotelPackage + "\n\n" + TicketPackage +
                ClientPackage + "\nValor do Pacote: " + ValuePackage;
        }
    }
}
