using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

      

        [HttpGet]
        public ActionResult<List<Student>> GetAll(string ime_prezime,string opstina)
        {
            var data = _dbContext.Student
                .Include(s => s.opstina_rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime))
                .Where(x=> opstina==null || x.opstina_rodjenja.description.ToLower().StartsWith(opstina.ToLower()))
                .OrderByDescending(s => s.id)
                .AsQueryable();
            return data.Take(100).ToList();
        }
        [HttpPost]
        public ActionResult<Student> Add([FromBody] StudentAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("korisnik nije logiran");
            Student student;
            if (x.id == null)
            {
                student = new Student();
                _dbContext.Add(student);
            }
            else
            {
                student = _dbContext.Student.Where(y => y.id == x.id).FirstOrDefault();
            }
            student.ime = x.ime;
            student.prezime = x.prezime;
            student.broj_indeksa = x.broj_indeksa;
            student.opstina_rodjenja_id = x.opstina_rodjenja_id;
            _dbContext.SaveChanges();
            return student;
            
        }


        [HttpGet]
        public ActionResult<Student> GetById( int studentId)
        {
            return _dbContext.Student.Where(x => x.id == studentId).FirstOrDefault();
        }

    }
}
