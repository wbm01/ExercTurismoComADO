using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class Ticket
    {
        public Address Origin { get; set; }

        public Address Destiny { get; set; }

        public Client ClientTicket { get; set; }

        public DateTime DateTicket { get; set; }

        public double ValueTicket { get; set; }


    }
}
