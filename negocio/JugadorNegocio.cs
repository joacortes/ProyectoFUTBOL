using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class JugadorNegocio
    {

        // Methods
        public List<Jugador> listar()
        { 
            List<Jugador> lista = new List<Jugador>();
            AccesoDatos acceso = new AccesoDatos();
            
        
            try
            {
                acceso.setQuery("SELECT J.Id, J.Nombre, J.Apellido, J.Altura, J.Edad, J.FechaNacimiento, J.Foto, N.Nombre Nacionalidad, P.Nombre Posicion, E.Nombre Equipo, T.Nombre Torneo, J.IdEquipo, J.IdNacionalidad, J.IdPosicion, J.IdTorneo FROM Jugador J JOIN Equipo E ON J.IdEquipo = E.Id JOIN Torneo T ON J.IdTorneo = T.Id JOIN Nacionalidad N ON J.IdNacionalidad = N.Id JOIN Posicion P ON J.IdPosicion = P.Id WHERE Activo = 1");
                acceso.executeReader();

                while (acceso.Lector.Read())
                {
                    Jugador aux = new Jugador();
                    aux.Id = (int)acceso.Lector.GetInt32(0);
                    aux.Nombre = acceso.Lector.GetString(1);
                    aux.Apellido = acceso.Lector.GetString(2);
                    aux.Altura = acceso.Lector.GetInt32(3);
                    aux.Edad = acceso.Lector.GetInt32(4);
                    aux.FechaNacimiento = acceso.Lector.GetDateTime(5);

                    if (!(acceso.Lector["Foto"] is DBNull))
                       aux.Foto = (string)acceso.Lector["Foto"];

                    aux.Nacionalidad = new Nacionalidad();
                    aux.Nacionalidad.Id = (int)acceso.Lector["IdNacionalidad"];
                    aux.Nacionalidad.Nombre = acceso.Lector.GetString(7);
                    
                    
                    aux.Posicion = new Posicion();
                    aux.Posicion.Id = (int)acceso.Lector["IdPosicion"];
                    aux.Posicion.Nombre = acceso.Lector.GetString(8);
                    

                    aux.Equipo = new Equipo();
                    aux.Equipo.Id = (int)acceso.Lector["IdEquipo"];
                    aux.Equipo.Nombre = acceso.Lector.GetString(9);


                    aux.Torneo = new Torneo();
                    aux.Torneo.Id = (int)acceso.Lector["IdTorneo"];
                    aux.Torneo.Nombre = acceso.Lector.GetString(10);

                    aux.Activo = acceso.Lector.GetInt32(12);

                    lista.Add(aux);
                }

                acceso.conexionClose();
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public List<Jugador> filtrar(string campo, string criterio, string filtro)
        {
            List<Jugador> lista = new List<Jugador>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT J.Id, J.Nombre, J.Apellido, J.Altura, J.Edad, J.FechaNacimiento, J.Foto, N.Nombre Nacionalidad, P.Nombre Posicion, E.Nombre Equipo, T.Nombre Torneo, J.IdEquipo, J.IdNacionalidad, J.IdPosicion, J.IdTorneo FROM Jugador J JOIN Equipo E ON J.IdEquipo = E.Id JOIN Torneo T ON J.IdTorneo = T.Id JOIN Nacionalidad N ON J.IdNacionalidad = N.Id JOIN Posicion P ON J.IdPosicion = P.Id WHERE Activo = 1 and";
                switch (campo)
                {
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += " J.Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += " J.Nombre like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += " J.Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Apellido":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += " Apellido like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += " Apellido like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += " Apellido like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Equipo":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += " E.Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += " E.Nombre like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += " E.Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }

                datos.setQuery(consulta);
                datos.executeReader();

                while (datos.Lector.Read())
                {
                    Jugador aux = new Jugador();
                    aux.Id = (int)datos.Lector.GetInt32(0);
                    aux.Nombre = datos.Lector.GetString(1);
                    aux.Apellido = datos.Lector.GetString(2);
                    aux.Altura = datos.Lector.GetInt32(3);
                    aux.Edad = datos.Lector.GetInt32(4);
                    aux.FechaNacimiento = datos.Lector.GetDateTime(5);

                    if (!(datos.Lector["Foto"] is DBNull))
                        aux.Foto = (string)datos.Lector["Foto"];

                    aux.Nacionalidad = new Nacionalidad();
                    aux.Nacionalidad.Id = (int)datos.Lector["IdNacionalidad"];
                    aux.Nacionalidad.Nombre = datos.Lector.GetString(7);


                    aux.Posicion = new Posicion();
                    aux.Posicion.Id = (int)datos.Lector["IdPosicion"];
                    aux.Posicion.Nombre = datos.Lector.GetString(8);


                    aux.Equipo = new Equipo();
                    aux.Equipo.Id = (int)datos.Lector["IdEquipo"];
                    aux.Equipo.Nombre = datos.Lector.GetString(9);


                    aux.Torneo = new Torneo();
                    aux.Torneo.Id = (int)datos.Lector["IdTorneo"];
                    aux.Torneo.Nombre = datos.Lector.GetString(10);

                    aux.Activo = datos.Lector.GetInt32(12);

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
        public void addPlayer(Jugador nuevo)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                
                acceso.setQuery("INSERT INTO Jugador (Nombre, Apellido, Altura, Edad, FechaNacimiento, Foto, IdNacionalidad, IdPosicion, IdEquipo, IdTorneo, Activo) VALUES (@nombre, @apellido, @altura, @edad, @fechadenacimiento, @Foto, @IdNacionalidad, @IdPosicion, @IdEquipo, 1, 1)");
                acceso.setParameter("@nombre", nuevo.Nombre);
                acceso.setParameter("@apellido", nuevo.Apellido);
                acceso.setParameter("@altura", nuevo.Altura);
                acceso.setParameter("@edad", nuevo.Edad);
                acceso.setParameter("@fechadenacimiento", nuevo.FechaNacimiento);
                acceso.setParameter("@Foto", nuevo.Foto);
                acceso.setParameter("@IdNacionalidad", nuevo.Nacionalidad.Id);
                acceso.setParameter("@IdPosicion", nuevo.Posicion.Id);
                acceso.setParameter("@IdEquipo", nuevo.Equipo.Id);
                
                acceso.executeNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.conexionClose();
            }
        }
        public void modPlayer(Jugador jugador)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("UPDATE Jugador SET Nombre = @nombre, Apellido = @apellido, Edad = @edad, Altura = @altura, Foto = @foto, FechaNacimiento = @fechanacimiento, IdNacionalidad = @IdNacionalidad, IdEquipo = @IdEquipo, IdPosicion = @IdPosicion WHERE Id = @Id");
                datos.setParameter("@nombre", jugador.Nombre);
                datos.setParameter("@apellido", jugador.Apellido);
                datos.setParameter("@edad", jugador.Edad);
                datos.setParameter("@altura", jugador.Altura);
                datos.setParameter("@foto", jugador.Foto);
                datos.setParameter("@fechanacimiento", jugador.FechaNacimiento);
                datos.setParameter("@IdNacionalidad", jugador.Nacionalidad.Id);
                datos.setParameter("@IdEquipo", jugador.Equipo.Id);
                datos.setParameter("@IdPosicion", jugador.Posicion.Id);
                datos.setParameter("@Id", jugador.Id);

                datos.executeNonQuery();
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
        public void deletePlayer(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                

                datos.setQuery("DELETE FROM Jugador WHERE Id = @Id");
                datos.setParameter("@Id", id);
                datos.executeNonQuery();
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
        public void deleteLogicPlayer(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("UPDATE Jugador SET Activo = 0 WHERE Id = @Id");
                datos.setParameter("@Id", id);
                datos.executeNonQuery();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

    }
}
