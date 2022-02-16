using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

 namespace WebApplication1.Bussinnes
{
    public class DAOAutor
    {

        public Int32 InsertaAutores(Autor autor)
        {
            Conexion objConn = new Conexion();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();
            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("spInsertaAutor", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@vCodigoAutor", autor.CodigoAutor);
                objCommand.Parameters.AddWithValue("@vNombre", autor.Nombres);
                objCommand.Parameters.AddWithValue("@nApellidoPaterno", autor.ApellidoPaterno);
                objCommand.Parameters.AddWithValue("@nApellidoMaterno", autor.ApellidoMaterno);
                objCommand.Parameters.AddWithValue("@iEdad", autor.Edad);
                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }


        public List<Autor> ListaAutores(){
            Conexion objConn = new Conexion();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            try
            {
                List<Autor> listaAutor = new List<Autor>();

                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand sqlCommand = new SqlCommand("spListaAutores", Conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0
                };
                SqlCommand objCommand = sqlCommand;
                SqlDataReader reader = objCommand.ExecuteReader();

                while (reader.Read())
                {
                    Autor objAutor = new Autor
                    {
                        Id = Convert.ToInt32(reader["IdAutor"]),
                        CodigoAutor = reader["vCodigoAutor"].ToString(),
                        Nombres = reader["nNombre"].ToString(),
                        ApellidoPaterno = reader["nApellidoPaterno"].ToString(),
                        ApellidoMaterno = reader["nApellidoMaterno"].ToString()
                    };
                    listaAutor.Add(objAutor);
                }

                return listaAutor;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public List<Autor> ListaAutoresPaginacion(int NroPagina, int CantidadRegistros){
            Conexion objConn = new Conexion();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            try
            {
                List<Autor> listaAutor = new List<Autor>();

                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("spListaAutoresPaginacion", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@NroPagina", NroPagina);
                objCommand.Parameters.AddWithValue("@CantidadRegistros", CantidadRegistros);

                SqlDataReader reader = objCommand.ExecuteReader();

                while (reader.Read())
                {
                    Autor objAutor = new Autor
                    {
                        Id = Convert.ToInt32(reader["IdAutor"]),
                        CodigoAutor = reader["vCodigoAutor"].ToString(),
                        Nombres = reader["nNombre"].ToString(),
                        ApellidoPaterno = reader["nApellidoPaterno"].ToString(),
                        ApellidoMaterno = reader["nApellidoMaterno"].ToString()
                    };
                    listaAutor.Add(objAutor);
                }

                return listaAutor;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Int32 ActualizacionAutor(Autor objCust){
            Conexion objConn = new Conexion();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();
            int result = 0;
            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("spModificaAutores", Conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0
                    
                };
                objCommand.Parameters.AddWithValue("@iIdAutor", objCust.Id);
                objCommand.Parameters.AddWithValue("@vNombre", objCust.Nombres);
                objCommand.Parameters.AddWithValue("@nApellidoPaterno", objCust.ApellidoPaterno);
                objCommand.Parameters.AddWithValue("@nApellidoMaterno", objCust.ApellidoMaterno);
                objCommand.Parameters.AddWithValue("@iEdad", objCust.Edad);
                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }


        public Int32 EliminaAutor(int id)
        {
            Conexion objConn = new Conexion();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("spEliminaAutor", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@iIdAutor", id);
                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Int32 DesactivaAutor(int id)
        {
            Conexion objConn = new Conexion();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("spEliminaLAutor", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@iIdAutor", id);
                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }



    }



}