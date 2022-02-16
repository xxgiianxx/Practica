using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Bussinnes;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/libro")]

    public class LibroController : ApiController{
    
        [Route("Crear")]
        [HttpPost]
        public string Create(Libro libro)
        {
            try
            {
                DAOLibro objCrd = new DAOLibro();
                Int32 message = 0;

                if ((libro != null)) message = objCrd.InsertaLibro(libro);
                else message = -1;
                return message.ToString();
            }
            catch
            {
                throw;
            }
        }
        [Route("Modificar")]
        [HttpPost]
        public string Modificar(Libro libro)
        {
            try
            {
                DAOLibro objCrd = new DAOLibro();
                Int32 message = 0;

                if ((libro != null)) message = objCrd.ActualizaLibro(libro);
                else message = -1;
                return message.ToString();
            }
            catch
            {
                throw;
            }
        }



        [Route("Eliminar")]
        [HttpDelete]
        public string EliminarLibro(int id)
        {
            try
            {
                DAOLibro objCrd = new DAOLibro();
                Int32 message = 0;

                if ((id!=0)) message = objCrd.EliminarLibro(id);

                return message.ToString();
            }
            catch
            {
                throw;
            }
        }



    }
}