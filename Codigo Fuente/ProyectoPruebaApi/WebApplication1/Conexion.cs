using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Conexion{

        private readonly SqlConnection SqlConn = null;
        public SqlConnection GetConnection { get { return SqlConn; } }
        public Conexion() {

            if (SqlConn is null)
            {     
                string ConnectionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                SqlConn = new SqlConnection(ConnectionString);
            }
      
        }

    }
}