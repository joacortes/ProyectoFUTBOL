﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Equipo
    {
        // Properties
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string logo { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
