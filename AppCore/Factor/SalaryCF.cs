using AppCore.Processses.Payroll;
using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Factor
{
    public static class SalaryCF
    {
        public static ISalaryCalculator CreateInstance(Empleado e)
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
                return new AdministrativoSalaryCalculator();
            }
            else
            {
                throw new Exception(nameof(e));
            }
        }
    }
}
