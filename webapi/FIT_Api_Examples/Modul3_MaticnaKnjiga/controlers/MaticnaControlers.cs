using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.controlers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class MaticnaControlers : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public MaticnaControlers(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult<Maticna> Add([FromBody] MaticnaAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("korisnik nije logiran");
            if (!x.obnova && _dbContext.Maticna.Count(y => y.studentId == x.studentId && y.godina == x.godina) > 0)
                return BadRequest("korisnik vec upisao ovu godinu");
            var maticna = new Maticna
            {
                datumUpisa = x.datumUpisa,
                obnova = x.obnova,
                napomena = x.napomena,
                studentId = x.studentId,
                akademskaGodinaId = x.akademskaGodinaId,
                cijena = x.cijena,
                godina = x.godina,
                evidentiraoId = HttpContext.GetLoginInfo().korisnickiNalog.id,
            };
            _dbContext.Add(maticna);
            _dbContext.SaveChanges();
            return maticna;

        }

        [HttpPost]
        public ActionResult<Maticna> Ovjeri([FromBody] MaticnaOvjera x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("korisnik nije logiran");
            var maticna = _dbContext.Maticna.Find(x.id);
            maticna.napomena = x.napomena;
            maticna.datumOvjere = x.datumOvjere;
            _dbContext.SaveChanges();
            return maticna;
        }



        [HttpGet]
        public ActionResult<List<Maticna>> GettAll(int studentId)
        {
            return _dbContext.Maticna.Where(x => x.studentId == studentId).Include(x => x.akademskaGodina)
                .Include(x => x.evidentirao).ToList();
        }

    }
}
