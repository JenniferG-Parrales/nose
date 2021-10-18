using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventario
{
        public class Registro
        {
            public DateTime FechaRegistro { get; set; }
            public int Existencia { get; set; }
            public decimal ValorUnidad { get; set; }
            public decimal ValorTotal { get; set; }
            public EspecieCuenta Especie { get; set; }

        }
    }
