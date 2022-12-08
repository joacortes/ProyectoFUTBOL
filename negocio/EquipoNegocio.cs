using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class EquipoNegocio
    {
        // Methods
        public List<Equipo> listar()
        {
            List<Equipo> lista = new List<Equipo>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {

                // Set the Query with this method
                acceso.setQuery("SELECT Id, Nombre, logo FROM Equipo");

                // Execute the reader;
                acceso.executeReader();

                while (acceso.Lector.Read())
                {
                    Equipo aux = new Equipo();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Nombre = (string)acceso.Lector["Nombre"];
                    aux.logo = (string)acceso.Lector["logo"];

                    // Add the data in the list
                    lista.Add(aux);
                }

                // Return the list
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                // It check if the lector is null and closed it, and then close the conexion.
                acceso.conexionClose();
            }
        }
    }
}
