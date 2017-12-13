using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testsite.Models;

namespace testsite.Controllers
{
    public class SampleController : Controller
    {
        private readonly AcceptContext _context;

        public SampleController(AcceptContext context)
        {
            _context = context;    
        }

        // GET: Sample
        public async Task<IActionResult> Index()
        {
            var acceptContext = _context.Members.Include(m => m.JobType);
            return View(await acceptContext.ToListAsync());
        }

        // GET: Sample/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.JobType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Sample/Create
        public IActionResult Create()
        {
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "Id", "Id");
            return View();
        }

        // POST: Sample/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NameKana,MailAddress,PostNo,Address1,Address2,AgreePolicy,Twitter,BirthDay,Office,JobTypeId,Yakushoku,RepeatCount,Issue,UserNotes,FamousPoint,SkillPoint,IsAccept,IsVip,WacateNotes")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "Id", "Id", member.JobTypeId);
            return View(member);
        }

        // GET: Sample/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.SingleOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "Id", "Id", member.JobTypeId);
            return View(member);
        }

        // POST: Sample/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NameKana,MailAddress,PostNo,Address1,Address2,AgreePolicy,Twitter,BirthDay,Office,JobTypeId,Yakushoku,RepeatCount,Issue,UserNotes,FamousPoint,SkillPoint,IsAccept,IsVip,WacateNotes")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "Id", "Id", member.JobTypeId);
            return View(member);
        }

        // GET: Sample/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.JobType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Sample/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.SingleOrDefaultAsync(m => m.Id == id);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
