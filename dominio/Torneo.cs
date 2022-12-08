using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Torneo
    {

        // Properties
        public int Id { get; set; }
        public string Nombre { get; set; }

        // ToString method override
        public override string ToString()
        {
            return Nombre;
        }
    }
}
