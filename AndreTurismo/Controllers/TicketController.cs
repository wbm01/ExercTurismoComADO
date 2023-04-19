using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class TicketController
    {
        public bool InsertTicket(Ticket ticket)
        {
            //ticket.Origin = new AddressService().InsertAddress(ticket.Origin);
            //ticket.Destiny = new AddressService().InsertAddress(ticket.Destiny);
            

            return new TicketService().InsertTicket(ticket);
        }

        public bool DeleteTicket(Ticket ticket)
        {
            return new TicketService().DeleteTicket(ticket);
        }

        public List<Ticket> GetTicketList()
        {
            return new TicketService().GetTicketList();
        }

        public bool UpdateTicket(Ticket ticket)
        {
            return new TicketService().UpdateTicket(ticket);
        }
    }
}
