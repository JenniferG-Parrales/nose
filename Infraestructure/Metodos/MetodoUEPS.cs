using Domain.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Inventario
{
    public class MetodoUEPS : ModelIventario
    {
        public void CalcularValores()
        {
            OrdenarPorFecha(inventario, inventario.Length);

            Registro[] entradas, salidas;
            (entradas, salidas) = GetEntradasSalidas();

            for (int i = 0; i < salidas.Length; i++)
            {
                salidas[i].ValorUnidad = entradas[i].ValorUnidad;
                salidas[i].ValorTotal = salidas[i].ValorUnidad * salidas[i].Existencia;

                for (int j = 0; j < inventario.Length; i++)
                {
                    if (inventario[j] == salidas[i])
                    {
                        inventario[j] = salidas[i];
                        break;
                    }
                }
            }
        }
    }
}
