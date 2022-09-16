using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManager.Shared
{
    public static class TicketCommands
    {
        public class PurchaseTicketCommand : ICommand
        {
            public PurchaseTicketCommand()
            {
            }

            public PurchaseTicketCommand(string ticketId)
            {
                TicketId = ticketId;
            }

            public string? TicketId { get; set; }
        }
    }
}
