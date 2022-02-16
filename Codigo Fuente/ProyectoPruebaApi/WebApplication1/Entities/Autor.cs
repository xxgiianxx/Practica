using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class Autor
    {
        [Required]
        public int Id { get; set; }

        [Required]

        public string CodigoAutor { get; set; }

        [Required]
        public string Nombres { get; set; }
        
        [Required]
        public string ApellidoMaterno { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }

        public string ResumenContribucion { get; set; }

        [Range(18,50)]
        public int Edad { get; set; }

 
         




    }
}