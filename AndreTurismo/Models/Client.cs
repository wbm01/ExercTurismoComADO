using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class Client
    {
        public int IdClient { get; set; }

        public string NameClient { get; set; }

        public string Phone { get; set; }

        public Address AddressClient { get; set; }

        public DateTime DtRegisterClient { get; set; }

        public override string ToString()
        {
            return "\nNome: " + NameClient + "\nTelefone: " + Phone + AddressClient;
        }
    }
}
