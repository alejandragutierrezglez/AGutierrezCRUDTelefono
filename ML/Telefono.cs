﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Telefono
    {
        public int? IdTelefono { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumSerie { get; set; }
        public List<object> Telefonos { get; set; }
    }
}
