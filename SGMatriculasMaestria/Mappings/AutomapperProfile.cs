using Microsoft.AspNetCore.Identity;
using SGMatriculasMaestria.DTOs;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Mappings
{
    public class AutomapperProfil: AutoMapper.Profile 
    { 
        public AutomapperProfil()
        {
            CreateMap<Aspirante, AspiranteDto>();
            CreateMap<AspiranteDto, Aspirante>();
        }
    }
}
