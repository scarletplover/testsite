using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testsite.Models;
using Newtonsoft.Json;
using testsite.Views.Accept;

namespace testsite.Controllers
{
    public class AcceptController : Controller
    {
        private readonly AcceptContext _context;

        public AcceptController(AcceptContext context)
        {
            _context = context;
            JobType.Initialize(_context);
        }

        // GET: Accept
        public async Task<IActionResult> Index()
        {
            return View(await _context.Members.ToListAsync());
        }


        // GET: Accept/Agreement
        public IActionResult Agreement()
        {
            if(TempData.ContainsKey("member")|| TempData.ContainsKey("confilmDate"))
            {
                TempData.Clear();
            }
            return View();
        }

        // POST: Accept/Agreement
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agreement([Bind("AgreePolicy")] AgreementViewModel agreement)
        {
            if (ModelState.IsValid)
            {
                var member = new Member() { AgreePolicy = agreement.AgreePolicy };
                TempData["member"] = JsonConvert.SerializeObject(member, Formatting.Indented);
                return RedirectToAction("Accept1");
            }
            return View(agreement);
        }

        // GET: Accept/Agreement
        public IActionResult Accept1()
        {
            if (TempData.ContainsKey("member"))
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        // POST: Accept/Agreement
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept1([Bind("Name,NameKana,MailAddress,PostNo,Address1,Address2,BirthDay")] Accept1ViewModel viewmodel)
        {
            if (ModelState.IsValid && TempData.ContainsKey("member"))
            {
                var member = JsonConvert.DeserializeObject<Member>(TempData["member"].ToString());

                member.Name = viewmodel.Name;
                member.NameKana = viewmodel.NameKana;
                member.MailAddress = viewmodel.MailAddress;
                member.PostNo = viewmodel.PostNo;
                member.Address1 = viewmodel.Address1;
                member.Address2 = viewmodel.Address2;
                member.BirthDay = viewmodel.BirthDay;

                TempData["member"] = JsonConvert.SerializeObject(member, Formatting.Indented);
                return RedirectToAction("Accept2");
            }
            return RedirectToAction("Index");
        }
        // GET: Accept/Agreement
        public IActionResult Accept2()
        {
            if (TempData.ContainsKey("member"))
            {
                ViewData["JobTypeId"] = new SelectList(_context.JobTypes, "Id", "Type");
                return View();
            }
            return RedirectToAction("Index");
        }
        // POST: Accept/Agreement
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept2([Bind("Office,JobTypeId,Yakushoku")] Accept2ViewModel viewmodel)
        {
            if (ModelState.IsValid && TempData.ContainsKey("member"))
            {
                var member = JsonConvert.DeserializeObject<Member>(TempData["member"].ToString());

                member.Office = viewmodel.Office;
                member.JobTypeId = viewmodel.JobTypeId;
                member.Yakushoku = viewmodel.Yakushoku;

                TempData["member"] = JsonConvert.SerializeObject(member, Formatting.Indented);
                return RedirectToAction("Accept3");
            }
            return RedirectToAction("Index");
        }
        // GET: Accept/Agreement
        public IActionResult Accept3()
        {
            if (TempData.ContainsKey("member"))
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        // POST: Accept/Agreement
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept3([Bind("Twitter,RepeatCount")] Accept3ViewModel viewmodel)
        {
            if (ModelState.IsValid && TempData.ContainsKey("member"))
            {
                var member = JsonConvert.DeserializeObject<Member>(TempData["member"].ToString());

                member.Twitter = viewmodel.Twitter;
                member.RepeatCount = viewmodel.RepeatCount;

                TempData["member"] = JsonConvert.SerializeObject(member, Formatting.Indented);
                return RedirectToAction("Accept4");
            }
            return RedirectToAction("Index");
        }
        // GET: Accept/Agreement
        public IActionResult Accept4()
        {
            if (TempData.ContainsKey("member"))
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        // POST: Accept/Agreement
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept4([Bind("Issue,UserNotes")] Accept4ViewModel viewmodel)
        {
            if (ModelState.IsValid && TempData.ContainsKey("member"))
            {
                var member = JsonConvert.DeserializeObject<Member>(TempData["member"].ToString());

                member.Issue = viewmodel.Issue;
                member.UserNotes = viewmodel.UserNotes;

                TempData["member"] = JsonConvert.SerializeObject(member, Formatting.Indented);
                return RedirectToAction("Confilm");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Confilm()
        {
            if (TempData.ContainsKey("member"))
            {
                var member = JsonConvert.DeserializeObject<Member>(TempData.Peek("member").ToString());
                var confilmDate = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var viewmodel = new ConfilmViewModel()
                {
                    Name = member.Name,
                    NameKana = member.NameKana,
                    MailAddress = member.NameKana,
                    PostNo = member.PostNo,
                    Address1 = member.Address1,
                    Address2 = member.Address2,

                    Twitter = member.Twitter,
                    BirthDay = member.BirthDay,
                    Office = member.Office,
                    JobTypeId = member.JobTypeId,
                    JobType = (from m in _context.JobTypes
                               where m.Id == member.JobTypeId
                               select new JobType { Id = m.Id, Type = m.Type }).FirstOrDefault(),
                    Yakushoku = member.Yakushoku,
                    RepeatCount = member.RepeatCount,
                    Issue = member.Issue,
                    UserNotes = member.UserNotes,
                    ConfilmDate = confilmDate
                };
                TempData["confilmDate"] = confilmDate;
                return View(viewmodel);
            }
           
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confilm([Bind("ConfilmDate")] ConfilmViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if (!TempData.ContainsKey("member") || !TempData.ContainsKey("confilmDate"))
            {
                return RedirectToAction("Index");
            }
            if (TempData["confilmDate"].ToString() != viewModel.ConfilmDate)
            {
                return RedirectToAction("Index");
            }
            var member = JsonConvert.DeserializeObject<Member>(TempData["member"].ToString());
            
            using (var point = new BizLogic.Point(member.Twitter, member.Name, member.Office, member.RepeatCount))
            {
                member.SkillPoint = point.GetSkillPoint();
                member.FamousPoint = point.GetFamousPoint();
            }
            member.ApplicationDate = DateTime.Now;
            _context.Add(member);
            await _context.SaveChangesAsync();
            return RedirectToAction("Thanks");
        }
        public IActionResult Thanks()
        {
            return View();
        }


            private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
