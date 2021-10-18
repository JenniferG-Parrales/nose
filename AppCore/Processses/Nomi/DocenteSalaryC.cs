using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Empleados;

namespace AppCore.Processses.Nomi
{
    public class DocenteSalaryC : BaseSalaryC, ISalaryC
    {
        public decimal CalculateSalary(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado));
            }

            decimal inss = CalculateInss(empleado.Salario);
            decimal annualSalary = CalculateAnnualSalary(empleado.Salario - inss);
            decimal ir = CalculateIr(annualSalary);

            return empleado.Salario - inss - ir;
        }
    }
}
