using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmaDotCom.Models;

namespace PharmaDotCom.Controllers
{
    public class CareerController : Controller
    {
        private readonly PharmaDotComContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CareerController(PharmaDotComContext context ,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this._webHostEnvironment = webHostEnvironment;
            
        }

        // GET: career
        public async Task<IActionResult> Index()
        {
            return View(await _context.Career.ToListAsync());
        }

        // GET: career/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Career
                .FirstOrDefaultAsync(m => m.Id == id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }

        // GET: career/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: career/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,PhoneNumber,EmailAddress,CompanyName,CurrentPost,JobField,Address,Country,State,City,PostalCode,Degree,University,College,ChooseFile,Resume")] Career career)
        {
            if (ModelState.IsValid)
            {
                career.ChooseFile = this.UploadResume(career);
                _context.Add(career);
                await _context.SaveChangesAsync();
                ModelState.Clear();
                
            }
            return View();
        }

        private string UploadResume(Career career)
        {
           string folder = "Files/Resume/";
           folder+= Guid.NewGuid().ToString()+career.Resume.FileName;
           string myvar = this._webHostEnvironment.WebRootPath;
           string[] myArr = { myvar, folder };
           string server = Path.Combine(myArr);
           career.Resume.CopyTo(new FileStream(server, FileMode.Create));

           return folder;
        }
         
        // GET: career/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Career
                .FirstOrDefaultAsync(m => m.Id == id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }
         
        // POST: career/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var career = await _context.Career.FindAsync(id);
            _context.Career.Remove(career);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerExists(int id)
        {
            return _context.Career.Any(e => e.Id == id);
        }
    }
}
       


     

       
   
