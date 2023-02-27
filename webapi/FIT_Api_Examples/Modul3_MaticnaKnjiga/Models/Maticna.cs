using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    public class Maticna
    {
        [Key]
        public int id { get; set; }
        public Student student { get; set; }
        public int studentId { get; set; }
        public KorisnickiNalog  evidentirao { get; set; }
        public int evidentiraoId { get; set; }
        public AkademskaGodina  akademskaGodina { get; set; }
        public int akademskaGodinaId { get; set; }

        public float cijena { get; set; }
        public bool obnova { get; set; }
        public string napomena { get; set; }
        public DateTime datumUpisa { get; set; }
        public DateTime? datumOvjere { get; set; }
        public int godina { get; set; }

    }
}
