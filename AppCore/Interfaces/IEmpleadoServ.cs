using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Interfaces
{
    public interface IEmpleadoServ : IService<Empleado>
    {
        Empleado FindById(int id);
        int GetLastEmpleadoId();
    }
}
