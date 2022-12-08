using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Jugador
    {
        // Properties
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Altura { get; set; }
        public int Edad { get; set; }
        [DisplayName("Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; }
        public Posicion Posicion { get; set; }
        public Equipo Equipo { get; set; }
        public Nacionalidad Nacionalidad { get; set; }
        public Torneo Torneo { get; set; }
        public int Activo { get; set; }
    }
}
