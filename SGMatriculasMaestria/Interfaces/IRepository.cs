using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Interfaces
{
    public interface IRepository<T> where T : IEntidad
    {
    }
}
