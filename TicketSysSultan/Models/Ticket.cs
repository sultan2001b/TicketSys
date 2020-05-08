using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSysSultan.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExtNum { get; set; }
        public string Issue { get; set; }
        public string Solution { get; set; }
        public DateTime CreateDateTime { get; set; } 
        public DateTime? CloseDateTime { get; set; }
        public bool Closed { get; set; } 
    }
}
