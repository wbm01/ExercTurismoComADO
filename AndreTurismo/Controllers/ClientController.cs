using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismo.Controllers
{
    public class ClientController
    {
        public bool InsertClient(Client client)
        {
            return new ClientController().InsertClient(client);
        }

        public bool DeleteClient(Client client)
        {
            return new ClientController().DeleteClient(client);
        }

        public List<Client> GetClientList()
        {
            return new ClientController().GetClientList();
        }

        public bool UpdateClient(Client client)
        {
            return new ClientController().UpdateClient(client);
        }
    }
}
