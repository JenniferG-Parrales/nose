using AppCore.Processses.Payroll;
using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Factories
{
    public static class SalaryCalcultorFactory
    {
        public static ISalaryC CreateInstance(Empleado e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
           
            if (e is Docente)
            {
                return new DocenteSalaryCalculator();
            }
            else if (e is Administrativo)
            {
                return new AdmiSalaryC();
            }
            else
            {
                throw new Exception(nameof(e));
            }
        }
    }
}