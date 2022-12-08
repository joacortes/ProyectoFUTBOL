using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class PosicionNegocio
    {
        // Methods
        public List<Posicion> listar()
        {
            List<Posicion> lista = new List<Posicion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("SELECT Id, Nombre FROM Posicion");
                datos.executeReader();

                while (datos.Lector.Read())
                {
                    Posicion aux = new Posicion();
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
