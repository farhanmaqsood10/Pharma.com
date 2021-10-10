using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmaDotCom.Models;

namespace PharmaDotCom.Controllers
{
    public class MailingController : Controller
    {
        private readonly PharmaDotComContext _context;
        private readonly IWebHostEnvironment _env;



        public MailingController(IWebHostEnvironment env, PharmaDotComContext context)
        {
            this._env = env;
            _context = context;
        }
        // GET: Mailing
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mailing.ToListAsync());
        }

        // GET: Mailing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailing = await _context.Mailing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mailing == null)
            {
                return NotFound();
            }

            return View(mailing);
        }
        // GET: Mailing/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Mailing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
    Create([Bind("Id,To,Subject,Text")] Mailing mailing)
        {

            if (ModelState.IsValid)
            {
                this.SendMail(mailing);

                _context.Add(mailing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(mailing);
        }
        private void SendMail(Mailing mailing)
        {
            string To = mailing.To;
            string subject = mailing.Subject;
            string Body = mailing.Text;
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(To);
            mailMessage.Subject = subject;
            mailMessage.From = new MailAddress("farhanmaqsood.ssmw@gmail.com");
            mailMessage.Body = mailing.Text;

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.UseDefaultCredentials = true;    
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("farhanmaqsood.ssmw@gmail.com", "IphoneX123,.");
            client.Send(mailMessage);

            {
                ModelState.Clear();
            }
        }

        

        // GET: Mailing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailing = await _context.Mailing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mailing == null)
            {
                return NotFound();
            }

            return View(mailing);
        }

        // POST: Mailing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mailing = await _context.Mailing.FindAsync(id);
            _context.Mailing.Remove(mailing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MailingExists(int id)
        {
            return _context.Mailing.Any(e => e.Id == id);
        }
    }
}
