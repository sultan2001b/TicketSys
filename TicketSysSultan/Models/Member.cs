using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSysSultan.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public MemberTypeEnum Type { get; set; }
        public List<Ticket> Tickets { get; set; }
    }

    public enum MemberTypeEnum { 
    Admin,
    Tech
    }
}
