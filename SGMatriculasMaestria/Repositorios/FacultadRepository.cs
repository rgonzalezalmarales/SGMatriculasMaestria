using SGMatriculasMaestria.Interfaces;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Repositorios
{
    public class FacultadRepository: IFacultadRepository
    {
        public IQueryable<Facultad> Facultades()
        {
            throw new Exception("Not Implemented");
        }
    }
}
