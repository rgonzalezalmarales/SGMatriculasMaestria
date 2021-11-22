using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El campo 'rol' es obligatorio.")]
        public string Role { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "El campo 'nombre' es obligatorio.")]
        [Display(Name = "Nombre")]
        [RegularExpression("^(([A-Z][a-záéíóúñü]{2,})( [A-Z][a-záéíóúñ]{2,}){0,2})$", ErrorMessage = "El campo 'nombre' no cumple con los requisitos.")]
        public string FirstName { get; set; }
        [Display(Name = "Primer apellido")]
        [RegularExpression("^(([A-Z][a-záéíóúñü]{1,})(( [A-Z][a-záéíóúñ]{0,})*|( [a-z]{2} ([A-Z][a-záéíóúñ]{1,}))))$", ErrorMessage = "El campo 'apellido' no cumple con los requisitos.")]
        [Required(ErrorMessage = "El campo 'primer apellido' es obligatorio.")]
        public string LastName { get; set; }
        [Display(Name = "Segundo apellido")]
        [RegularExpression("^(([A-Z][a-záéíóúñü]{1,})(( [A-Z][a-záéíóúñ]{0,})*|( [a-z]{2} ([A-Z][a-záéíóúñ]{1,}))))$", ErrorMessage = "El campo 'apellido' no cumple con los requisitos.")]
        [Required(ErrorMessage = "El campo 'segundo apellido' es obligatorio.")]
        public string LastNameTwo { get; set; }
        [Display(Name = "Carnet de identidad")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Valor correcto: 11 dígitos")]
        [Required(ErrorMessage = "El campo 'carnet' es obligatorio.")]
        public string CI { get; set; }
        public byte[] ProfilePicture { get; set; }

        [Required(ErrorMessage = "El campo 'Email' es obligatorio.")]
        [EmailAddress(ErrorMessage = "Solo se permiten correos electrónicos")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo 'Contraseña' es obligatorio.")]
        [StringLength(100, ErrorMessage = "La {0} debe tner un minimo de {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y su confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
