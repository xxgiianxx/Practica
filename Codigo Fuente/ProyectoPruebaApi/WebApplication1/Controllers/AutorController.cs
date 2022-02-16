using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Bussinnes;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/autor")]
    public class AutorController : ApiController
    {

        [Route("ListarTodos")]
        [HttpGet]
        public IEnumerable<Autor> ListaAurores()
        {
            try
            {
                DAOAutor objCrd = new DAOAutor();
                List<Autor> modelCust = objCrd.ListaAutores();
                return modelCust;
            }
            catch
            {
                throw;
            }
        }

        [Route("Crear")]
        [HttpPost]
        [ResponseType(typeof(Autor))]
        public string Create(Autor objAutor)
        {
            try
            {
                DAOAutor objCrd = new DAOAutor();
                Int32 message = 0;

                if ((objAutor.CodigoAutor != null) ) message = objCrd.InsertaAutores(objAutor);
                else message = -1;
                return message.ToString();
            }
            catch
            {
                throw;
            }
        }

        [Route("ListaPaginacion")]
        [HttpGet]
        public  IEnumerable<Autor> ListaAutoresPaginacion(int NroPagina, int CantidadRegistros)
        {
            try
            {
                DAOAutor objCrd = new DAOAutor();
                  List<Autor> modelCust = objCrd.ListaAutoresPaginacion(NroPagina, CantidadRegistros);
                return modelCust;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("Modificar")]
        [HttpPost]
        [ResponseType(typeof(Autor))]
        public string ModificarAutor(Autor objCust){
            try{
                DAOAutor objCrd = new DAOAutor();
                Int32 message = 0;
                message = objCrd.ActualizacionAutor(objCust);
                return message.ToString();
            }catch{
                throw;
            }
        }
        [Route("Eliminar")]

        [HttpDelete]
        public string EliminaAutor(int id)
        {
            try
            {
                DAOAutor objCrd = new DAOAutor();
                Int32 message = 0;
                message = objCrd.EliminaAutor(id);
                return message.ToString();
            }
            catch
            {
                throw;
            }
        }
        [Route("CambiEstado")]

        [HttpPost]
        public string CambiaEstadoAutor(int id){
            try {
                DAOAutor objCrd = new DAOAutor();
                Int32 message = 0;
                message = objCrd.DesactivaAutor(id);
                return message.ToString();
            }
            catch
            {
                throw;
            }
        }

    }
}
