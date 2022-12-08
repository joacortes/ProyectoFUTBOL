using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class AccesoDatos
    {
        // Variables
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        // Constructor
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=FUTBOL; integrated security=true");
            comando = new SqlCommand();
        }

        // Properties
        public SqlDataReader Lector
        {
            get
            {
                return lector;
            }
        }
        
        // Functions
        public void setQuery(string query)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
        }
        public void executeNonQuery()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void executeReader()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void setParameter(string name, object value)
        {
            comando.Parameters.AddWithValue(name, value);
        }
        public void conexionClose()
        {
            if (lector != null)
                lector.Close();

            conexion.Close();
        }
    }
}
