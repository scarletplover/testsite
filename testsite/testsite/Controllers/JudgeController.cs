using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testsite.Models;
using testsite.Views.Judge;
using Newtonsoft.Json;

namespace testsite.Controllers
{
    public class JudgeController : Controller
    {
        private readonly AcceptContext _context;

        public JudgeController(AcceptContext context)
        {
            _context = context;    
        }

        // GET: Judge
        public async Task<IActionResult> Index(string search)
        {
            var acceptContext = from m in _context.Members
                                join j in _context.JobTypes on m.JobTypeId equals j.Id
                                orderby m.IsAccept 
                                select new IndexViewModel{ Id = m.Id, Name = m.Name, NameKana = m.NameKana, JobType = j.Type, Office = m.Office,IsAccept =@m.IsAccept };
            if(!string.IsNullOrEmpty(search))
            {
                acceptContext = acceptContext.Where(b => b.Name.Contains(search));
                ViewData["Search"] = search;
            }
            return View(await acceptContext.ToListAsync());
        }


        // GET: Judge/Details/5
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

        // GET: Judge/Create
        public IActionResult Create()
        {
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "Id", "Id");
            return View();
        }

        // POST: Judge/Create
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

        // GET: Judge/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.Include(b => b.JobType).SingleOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "Id", "Type", member.JobTypeId);
            TempData["member"] = JsonConvert.SerializeObject(member, Formatting.Indented);
            var confilmDate = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var viewmodel = new EditViewModel()
            {
                Id = member.Id,
                Name = member.Name,
                NameKana = member.NameKana,
                MailAddress =member.MailAddress,
                PostNo = member.PostNo,
                Address1= member.Address1,
                Address2 =member.Address2,
                Twitter = member.Twitter,
                BirthDay = member.BirthDay,
                Office = member.Office,
                JobTypeId = member.JobTypeId,
                JobType = member.JobType,
                Yakushoku =member.Yakushoku,
                RepeatCount =member.RepeatCount,
                Issue = member.Issue,
                UserNotes = member.UserNotes,
                ApplicationDate = member.ApplicationDate,
                FamousPoint =member.FamousPoint,
                SkillPoint = member.SkillPoint,
                IsVip =member.IsVip??false,
                WacateNotes = member.WacateNotes,
                ConfilmDate = confilmDate
            };
            TempData["confilmDate"] = confilmDate;
            return View(viewmodel);
        }
        [HttpPost]
        public JsonResult GetPoint(string twitter,string name,string office,int repeatCount)
        {
            int skill;
            int famous;
            using (var point = new BizLogic.Point(twitter, name, office, repeatCount))
            {
                skill = point.GetSkillPoint();
                famous = point.GetFamousPoint();
            }
            return Json(new { skillpoint = skill, famouspoint = famous });
        }

        // POST: Judge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,string accept,string no, [Bind("Id,Name,NameKana,MailAddress,PostNo,Address1,Address2,AgreePolicy,Twitter,BirthDay,Office,JobTypeId,Yakushoku,RepeatCount,Issue,UserNotes,FamousPoint,SkillPoint,IsAccept,IsVip,WacateNotes,ConfilmDate")] EditViewModel viewmodel)
        {
            
            if (id != viewmodel.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if (!TempData.ContainsKey("member") || !TempData.ContainsKey("confilmDate"))
            {
                return RedirectToAction("Index");
            }
            if (TempData["confilmDate"].ToString() != viewmodel.ConfilmDate)
            {
                return RedirectToAction("Index");
            }
            try
            {
                var member = JsonConvert.DeserializeObject<Member>(TempData["member"].ToString());
                if (accept != null)
                {
                    member.IsAccept = true;
                }
                if (no != null)
                {
                    member.IsAccept = false;
                }
                member.IsVip = viewmodel.IsAccept;
                member.WacateNotes = viewmodel.WacateNotes;
                member.SkillPoint = viewmodel.SkillPoint;
                member.FamousPoint = viewmodel.FamousPoint;
                _context.Update(member);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(viewmodel.Id))
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

        // GET: Judge/Delete/5
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

        // POST: Judge/Delete/5
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
