using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using System;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class MaticnaAddVM
    {
    

        public int studentId { get; set; }
    
        public int evidentiraoId { get; set; }
     
        public int akademskaGodinaId { get; set; }

        public float cijena { get; set; }
        public bool obnova { get; set; }
        public string napomena { get; set; }
        public DateTime datumUpisa { get; set; }

        public int godina { get; set; }
    }
}
