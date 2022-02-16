using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class Libro
    {

        [Required]
        public int Id { get; set; } 
        
        [Required]
        public string Titulo { get; set; }


        [Required]
        public Autor AutorPrincipal { get; set; }

        public List<Autor> AutorSecundario { get; set; }
    }
}
