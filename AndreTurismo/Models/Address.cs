using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class Address
    {
        public int IdAddress { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string Neighborhood { get; set; }

        public string Cep { get; set; }

        public string Complement { get; set; }

        public City City { get; set; }

        public DateTime DtRegisterAddress { get; set; }

        public override string ToString()
        {
            return "\nEndereço: " + Street + "\nNúmero: " + Number + "\nBairro: "
                + Neighborhood + "\nCep: " + Cep + "\nComplemento: " + Complement + City;
        }
    }
}
