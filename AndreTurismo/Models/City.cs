using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class City
    {
        public int IdCity { get; set; }

        public string Description { get; set; }

        public DateTime DtRegisterCity { get; set; }

        public override string ToString()
        {
            return "\nCidade: " + Description;
        }
    }
}
