using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketSysSultan.Models;

namespace TicketSysSultan.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TicketSysSultan.Models.Ticket> Ticket { get; set; }
        public DbSet<TicketSysSultan.Models.Member> Member { get; set; }
    }
}
