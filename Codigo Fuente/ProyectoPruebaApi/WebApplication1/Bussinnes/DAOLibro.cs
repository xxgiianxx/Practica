using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Bussinnes
{
    public class DAOLibro
    {
        public Int32 InsertaLibro(Libro libro)
        {

            Conexion objConn = new Conexion();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();
            int result = 0;
            SqlTransaction transaction;
            try
            {

                
                transaction = Conn.BeginTransaction();
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("spInsertaLibro", Conn)
                {
                    Transaction = transaction,
                    CommandType = CommandType.StoredProcedure
                };
                int Id = 0;
                objCommand.Parameters.AddWithValue("@vTitulo", libro.Titulo);
                objCommand.Parameters.AddWithValue("@iIdAutor", libro.AutorPrincipal.Id);
                Id = Convert.ToInt32(objCommand.ExecuteScalar());

                foreach (var coautor in libro.AutorSecundario)
                {
                    objCommand = new SqlCommand("spInsertaAutorSecundario", Conn)
                    {
                        Transaction = transaction,
                        CommandType = CommandType.StoredProcedure
                    };
                     objCommand.Parameters.AddWithValue("@iIdLibro", Id);
                     objCommand.Parameters.AddWithValue("@iIdAutor", coautor.Id);
                     objCommand.Parameters.AddWithValue("@vResumen", coautor.ResumenContribucion);
                     result = Convert.ToInt32(objCommand.ExecuteNonQuery());
                   

                }


                if (Id > 0) {  
                    transaction.Commit();
                    return result;
                }
                else
                {
                    transaction.Rollback();
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


        //public List<Autor> ListaAutores()
        //{
        //    Conexion objConn = new Conexion();
        //    SqlConnection Conn = objConn.GetConnection;
        //    Conn.Open();

        //    try
        //    {
        //        List<Autor> listaAutor = new List<Autor>();

        //        if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

        //        SqlCommand sqlCommand = new SqlCommand("spListaAutores", Conn)
        //        {
        //            CommandType = CommandType.StoredProcedure,
        //            CommandTimeout = 0
        //        };
        //        SqlCommand objCommand = sqlCommand;
        //        SqlDataReader reader = objCommand.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Autor objAutor = new Autor
        //            {
        //                Id = Convert.ToInt32(reader["IdAutor"]),
        //                CodigoAutor = reader["vCodigoAutor"].ToString(),
        //                Nombres = reader["nNombre"].ToString(),
        //                ApellidoPaterno = reader["nApellidoPaterno"].ToString(),
        //                ApellidoMaterno = reader["nApellidoMaterno"].ToString()
        //            };
        //            listaAutor.Add(objAutor);
        //        }

        //        return listaAutor;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (Conn != null)
        //        {
        //            if (Conn.State == ConnectionState.Open)
        //            {
        //                Conn.Close();
        //                Conn.Dispose();
        //            }
        //        }
        //    }
        //}

        //public List<Autor> ListaAutoresPaginacion(int NroPagina, int CantidadRegistros)
        //{
        //    Conexion objConn = new Conexion();
        //    SqlConnection Conn = objConn.GetConnection;
        //    Conn.Open();

        //    try
        //    {
        //        List<Autor> listaAutor = new List<Autor>();

        //        if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

        //        SqlCommand objCommand = new SqlCommand("spListaAutoresPaginacion", Conn);
        //        objCommand.CommandType = CommandType.StoredProcedure;
        //        objCommand.Parameters.AddWithValue("@NroPagina", NroPagina);
        //        objCommand.Parameters.AddWithValue("@CantidadRegistros", CantidadRegistros);

        //        SqlDataReader reader = objCommand.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Autor objAutor = new Autor
        //            {
        //                Id = Convert.ToInt32(reader["IdAutor"]),
        //                CodigoAutor = reader["vCodigoAutor"].ToString(),
        //                Nombres = reader["nNombre"].ToString(),
        //                ApellidoPaterno = reader["nApellidoPaterno"].ToString(),
        //                ApellidoMaterno = reader["nApellidoMaterno"].ToString()
        //            };
        //            listaAutor.Add(objAutor);
        //        }

        //        return listaAutor;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (Conn != null)
        //        {
        //            if (Conn.State == ConnectionState.Open)
        //            {
        //                Conn.Close();
        //                Conn.Dispose();
        //            }
        //        }
        //    }
        //}

        public Int32 ActualizaLibro(Libro libro)
        {
            Conexion objConn = new Conexion();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();
            int result = 0;
            SqlTransaction transaction;
            try
            {
                transaction = Conn.BeginTransaction();
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("spModificaLibro", Conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = transaction,
                    CommandTimeout = 0

                };
                objCommand.Parameters.AddWithValue("@vTitulo", libro.Titulo);
                objCommand.Parameters.AddWithValue("@iIdAutor", libro.AutorPrincipal.Id);
                objCommand.Parameters.AddWithValue("@iIdlibro", libro.Id);
                result = Convert.ToInt32(objCommand.ExecuteNonQuery());

                objCommand = new SqlCommand("spEliminaAutorSecundario", Conn)
                {
                    Transaction = transaction,
                    CommandType = CommandType.StoredProcedure
                };
                objCommand.Parameters.AddWithValue("@iIdLibro", libro.Id);
                result = Convert.ToInt32(objCommand.ExecuteNonQuery());

                foreach (var coautor in libro.AutorSecundario)
                {
                    objCommand = new SqlCommand("spInsertaAutorSecundario", Conn)
                    {
                        Transaction = transaction,
                        CommandType = CommandType.StoredProcedure
                    };
                     objCommand.Parameters.AddWithValue("@iIdLibro", libro.Id);
                     objCommand.Parameters.AddWithValue("@iIdAutor", coautor.Id);
                     objCommand.Parameters.AddWithValue("@vResumen", coautor.ResumenContribucion);
                     result = Convert.ToInt32(objCommand.ExecuteNonQuery());
                   

                }
                transaction.Commit();
                return result;
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

        public Int32 EliminarLibro(int id)
        {
            Conexion objConn = new Conexion();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();
            int result = 0;
            SqlTransaction transaction;
            try
            {
                transaction = Conn.BeginTransaction();
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("spEliminaAutorSecundario", Conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = transaction,
                    CommandTimeout = 0

                };
                objCommand.Parameters.AddWithValue("@iIdLibro", id);
                result = Convert.ToInt32(objCommand.ExecuteNonQuery());

                objCommand = new SqlCommand("spEliminaLibro", Conn)
                {
                    Transaction = transaction,
                    CommandType = CommandType.StoredProcedure
                };
                objCommand.Parameters.AddWithValue("@iIdLibro", id);
                result = Convert.ToInt32(objCommand.ExecuteNonQuery());

                transaction.Commit();
                return result;
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
        //public Int32 EliminaAutor(int id)
        //{
        //    Conexion objConn = new Conexion();
        //    SqlConnection Conn = objConn.GetConnection;
        //    Conn.Open();

        //    int result = 0;

        //    try
        //    {
        //        if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

        //        SqlCommand objCommand = new SqlCommand("spEliminaAutor", Conn);
        //        objCommand.CommandType = CommandType.StoredProcedure;
        //        objCommand.Parameters.AddWithValue("@iIdAutor", id);
        //        result = Convert.ToInt32(objCommand.ExecuteScalar());

        //        if (result > 0)
        //        {
        //            return result;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (Conn != null)
        //        {
        //            if (Conn.State == ConnectionState.Open)
        //            {
        //                Conn.Close();
        //                Conn.Dispose();
        //            }
        //        }
        //    }
        //}

        //public Int32 DesactivaAutor(int id)
        //{
        //    Conexion objConn = new Conexion();
        //    SqlConnection Conn = objConn.GetConnection;
        //    Conn.Open();

        //    int result = 0;

        //    try
        //    {
        //        if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

        //        SqlCommand objCommand = new SqlCommand("spEliminaLAutor", Conn);
        //        objCommand.CommandType = CommandType.StoredProcedure;
        //        objCommand.Parameters.AddWithValue("@iIdAutor", id);
        //        result = Convert.ToInt32(objCommand.ExecuteScalar());

        //        if (result > 0)
        //        {
        //            return result;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (Conn != null)
        //        {
        //            if (Conn.State == ConnectionState.Open)
        //            {
        //                Conn.Close();
        //                Conn.Dispose();
        //            }
        //        }
        //    }
        //}
        //public List<Autor> ListaAutores()
        //{
        //    Conexion objConn = new Conexion();
        //    SqlConnection Conn = objConn.GetConnection;
        //    Conn.Open();

        //    try
        //    {
        //        List<Autor> listaAutor = new List<Autor>();

        //        if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

        //        SqlCommand sqlCommand = new SqlCommand("spListaAutores", Conn)
        //        {
        //            CommandType = CommandType.StoredProcedure,
        //            CommandTimeout = 0
        //        };
        //        SqlCommand objCommand = sqlCommand;
        //        SqlDataReader reader = objCommand.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Autor objAutor = new Autor
        //            {
        //                Id = Convert.ToInt32(reader["IdAutor"]),
        //                CodigoAutor = reader["vCodigoAutor"].ToString(),
        //                Nombres = reader["nNombre"].ToString(),
        //                ApellidoPaterno = reader["nApellidoPaterno"].ToString(),
        //                ApellidoMaterno = reader["nApellidoMaterno"].ToString()
        //            };
        //            listaAutor.Add(objAutor);
        //        }

        //        return listaAutor;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (Conn != null)
        //        {
        //            if (Conn.State == ConnectionState.Open)
        //            {
        //                Conn.Close();
        //                Conn.Dispose();
        //            }
        //        }
        //    }
        //}

        //public List<Autor> ListaAutoresPaginacion(int NroPagina, int CantidadRegistros)
        //{
        //    Conexion objConn = new Conexion();
        //    SqlConnection Conn = objConn.GetConnection;
        //    Conn.Open();

        //    try
        //    {
        //        List<Autor> listaAutor = new List<Autor>();

        //        if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

        //        SqlCommand objCommand = new SqlCommand("spListaAutoresPaginacion", Conn);
        //        objCommand.CommandType = CommandType.StoredProcedure;
        //        objCommand.Parameters.AddWithValue("@NroPagina", NroPagina);
        //        objCommand.Parameters.AddWithValue("@CantidadRegistros", CantidadRegistros);

        //        SqlDataReader reader = objCommand.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Autor objAutor = new Autor
        //            {
        //                Id = Convert.ToInt32(reader["IdAutor"]),
        //                CodigoAutor = reader["vCodigoAutor"].ToString(),
        //                Nombres = reader["nNombre"].ToString(),
        //                ApellidoPaterno = reader["nApellidoPaterno"].ToString(),
        //                ApellidoMaterno = reader["nApellidoMaterno"].ToString()
        //            };
        //            listaAutor.Add(objAutor);
        //        }

        //        return listaAutor;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (Conn != null)
        //        {
        //            if (Conn.State == ConnectionState.Open)
        //            {
        //                Conn.Close();
        //                Conn.Dispose();
        //            }
        //        }
        //    }
        //}

        //public Int32 ActualizacionAutor(Autor objCust)
        //{
        //    Conexion objConn = new Conexion();
        //    SqlConnection Conn = objConn.GetConnection;
        //    Conn.Open();
        //    int result = 0;
        //    try
        //    {
        //        if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

        //        SqlCommand objCommand = new SqlCommand("spModificaAutores", Conn)
        //        {
        //            CommandType = CommandType.StoredProcedure,
        //            CommandTimeout = 0

        //        };
        //        objCommand.Parameters.AddWithValue("@iIdAutor", objCust.Id);
        //        objCommand.Parameters.AddWithValue("@vNombre", objCust.Nombres);
        //        objCommand.Parameters.AddWithValue("@nApellidoPaterno", objCust.ApellidoPaterno);
        //        objCommand.Parameters.AddWithValue("@nApellidoMaterno", objCust.ApellidoMaterno);
        //        objCommand.Parameters.AddWithValue("@iEdad", objCust.Edad);
        //        result = Convert.ToInt32(objCommand.ExecuteScalar());

        //        if (result > 0)
        //        {
        //            return result;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (Conn != null)
        //        {
        //            if (Conn.State == ConnectionState.Open)
        //            {
        //                Conn.Close();
        //                Conn.Dispose();
        //            }
        //        }
        //    }
        //}


        //public Int32 EliminaAutor(int id)
        //{
        //    Conexion objConn = new Conexion();
        //    SqlConnection Conn = objConn.GetConnection;
        //    Conn.Open();

        //    int result = 0;

        //    try
        //    {
        //        if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

        //        SqlCommand objCommand = new SqlCommand("spEliminaAutor", Conn);
        //        objCommand.CommandType = CommandType.StoredProcedure;
        //        objCommand.Parameters.AddWithValue("@iIdAutor", id);
        //        result = Convert.ToInt32(objCommand.ExecuteScalar());

        //        if (result > 0)
        //        {
        //            return result;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (Conn != null)
        //        {
        //            if (Conn.State == ConnectionState.Open)
        //            {
        //                Conn.Close();
        //                Conn.Dispose();
        //            }
        //        }
        //    }
        //}

        //public Int32 DesactivaAutor(int id)
        //{
        //    Conexion objConn = new Conexion();
        //    SqlConnection Conn = objConn.GetConnection;
        //    Conn.Open();

        //    int result = 0;

        //    try
        //    {
        //        if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

        //        SqlCommand objCommand = new SqlCommand("spEliminaLAutor", Conn);
        //        objCommand.CommandType = CommandType.StoredProcedure;
        //        objCommand.Parameters.AddWithValue("@iIdAutor", id);
        //        result = Convert.ToInt32(objCommand.ExecuteScalar());

        //        if (result > 0)
        //        {
        //            return result;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (Conn != null)
        //        {
        //            if (Conn.State == ConnectionState.Open)
        //            {
        //                Conn.Close();
        //                Conn.Dispose();
        //            }
        //        }
        //    }
        //}



    }
}