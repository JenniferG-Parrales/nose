using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Processses
{
    public interface ISalaryC
    {
        decimal CalculateSalary(Empleado empleado);
    }
}