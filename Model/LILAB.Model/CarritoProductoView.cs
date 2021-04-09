﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LILAB.Model
{
   public class CarritoProductoView
    {
        public int CarritoItemId { get; set; }
        public int ProductoId { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal { get; set; }

    }
}
