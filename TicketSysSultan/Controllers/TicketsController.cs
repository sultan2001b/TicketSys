using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketSysSultan.Data;
using TicketSysSultan.Models;

namespace TicketSysSultan.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ticket.ToListAsync());
        }
              
        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ExtNum,Issue")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.CreateDateTime = DateTime.Now;
                ticket.Closed = false;
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            var currentMember = _context.Member.FirstOrDefault(x => x.Email == User.Identity.Name);
            if (currentMember.Type ==  MemberTypeEnum.Admin)    
            {
                var ticketMemberViewModel = new TicketMemberViewModel();
                ticketMemberViewModel.Ticket = ticket;
                ticketMemberViewModel.MembersSelectList = new SelectList(_context.Member, "Id", "Email");
                return View("EditAdmin", ticketMemberViewModel);//
            }
            return View(ticket);
        }

       
        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Solution,Closed")] Ticket ticket)
        {
            var orgTicket = _context.Ticket.Find(ticket.Id);

            _context.Entry(ticket).State = EntityState.Detached;

            orgTicket.Solution = ticket.Solution;
            orgTicket.Closed = ticket.Closed;

            if (id != orgTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(orgTicket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); 
            }
            return View(ticket);
        }

        public async Task<IActionResult> EditAdmin(int id, TicketMemberViewModel tmvm)
        {
            var orgTicket = _context.Ticket.Find(tmvm.Ticket.Id);

            _context.Entry(tmvm.Ticket).State = EntityState.Detached;

            orgTicket.Solution = tmvm.Ticket.Solution;
            orgTicket.Closed = tmvm.Ticket.Closed;
            orgTicket.MemberId = tmvm.Ticket.MemberId;


            if (id != orgTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(orgTicket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orgTicket);
        }

        // GET: Tickets/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ticket = await _context.Ticket
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ticket);
        //}

        // POST: Tickets/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ticket = await _context.Ticket.FindAsync(id);
        //    _context.Ticket.Remove(ticket);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
