using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NacionalidadNegocio
    {
        // Methods
        public List<Nacionalidad> listar()
        {
            List<Nacionalidad> lista = new List<Nacionalidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("SELECT Id, Nombre FROM Nacionalidad");
                datos.executeReader();

                while (datos.Lector.Read())
                {
                    Nacionalidad aux = new Nacionalidad();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.conexionClose();
            }
        } 
    }
}
