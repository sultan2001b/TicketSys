using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSysSultan.Models
{
    public class TicketMemberViewModel
    {
        public Ticket Ticket { get; set; }
        public SelectList MembersSelectList { get; set; }

    }
}
