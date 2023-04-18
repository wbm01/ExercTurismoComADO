using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class ClientController
    {
        public bool InsertClient(Client client)
        {
            client.AddressClient = new AddressService().InsertAddress(client.AddressClient);
            return new ClientService().InsertClient(client);
        }

        public bool DeleteClient(Client client)
        {
            return new ClientService().DeleteClient(client);
        }

        public List<Client> GetClientList()
        {
            return new ClientService().GetClientList();
        }

        public bool UpdateClient(Client client)
        {
            return new ClientService().UpdateClient(client);
        }
    }
}
