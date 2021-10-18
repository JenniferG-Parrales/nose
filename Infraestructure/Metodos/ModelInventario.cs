using Domain.Entities;
using Domain.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Inventario
{
    public abstract class ModelIventario
    {
        protected Registro[] inventario;

        public void Create(Registro e)
        {
            Add(e, inventario);
        }

        private void Add(Registro e, Registro[] arr)
        {
            if (arr == null)
            {
                arr = new Registro[1];
                arr[0] = e;
                return;
            }

            Registro[] tmp = new Registro[arr.Length + 1];
            Array.Copy(arr, tmp, arr.Length);
            tmp[arr.Length + 1] = e;
            arr = tmp;

        }

        public void OrdenarPorFecha(Registro[] arr, int n)
        {
            DateTime valorC;
            int posicion;

            for (int i = 0; i < n; i++)
            {
                valorC = arr[i].FechaRegistro;
                posicion = i;

                while (posicion > 0 && arr[posicion - 1].FechaRegistro > valorC)
                {
                    arr[posicion] = arr[posicion - 1];
                    posicion = posicion - 1;
                }

                arr[posicion] = arr[i];
            }
        }

        protected (Registro[], Registro[]) GetEntradasSalidas()
        {
            Registro[] entradas = new Registro[0];
            Registro[] salidas = new Registro[0];

            foreach (Registro e in inventario)
            {
                if (e.Especie == Domain.Enums.CuentaE.Entrada)
                {
                    Add(e, entradas);
                }
                else if (e.Especie == Domain.Enums.CuentaE.Salida)
                {

                    Add(e, salidas);
                }
            }

            return (entradas, salidas);
        }

        public decimal CalcularSaldo()
        {
            decimal totalEntradas = 0, totalSalidas = 0;
            CalcularValores();
            Registro[] entradas, salidas;
            (entradas, salidas) = GetEntradasSalidas();

            foreach (Registro e in entradas)
            {
                totalEntradas += e.ValorTotal;
            }

            foreach (Registro e in salidas)
            {
                totalSalidas += e.ValorTotal;
            }

            return totalEntradas - totalSalidas;
        }

        public int CalcularExistencias()
        {
            int totalEntradas = 0, totalSalidas = 0;
            Registro[] entradas, salidas;
            (entradas, salidas) = GetEntradasSalidas();

            foreach (Registro e in entradas)
            {
                totalEntradas += e.Existencia;
            }

            foreach (Registro e in salidas)
            {
                totalSalidas += e.Existencia;
            }

            return totalEntradas - totalSalidas;
        }

        public abstract void CalcularValores();
    }
}