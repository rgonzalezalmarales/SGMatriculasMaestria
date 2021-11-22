using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SGMatriculasMaestria.Models
{
    public class AplicationUser: IdentityUser
    {       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastNameTwo { get; set; }
        public string CI { get; set; }
        public byte[] ProfilePicture { get; set; }

        public DateTime Creatat { get; set; }
        public DateTime Modifiat { get; set; }
    }
}
