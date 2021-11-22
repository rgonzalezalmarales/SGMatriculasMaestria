using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using SGMatriculasMaestria.Models;

namespace SGMatriculasMaestria.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AplicationUser> _signInManager;
        private readonly UserManager<AplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<AplicationUser> userManager,
            SignInManager<AplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;           
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage ="El campo 'nombre' es obligatorio.")]
            [Display(Name = "Nombre")]
            [RegularExpression("^(([A-Z][a-záéíóúñü]{2,})( [A-Z][a-záéíóúñ]{2,}){0,2})$", ErrorMessage ="El campo 'nombre' no cumple con los requisitos.")]
            public string FirstName { get; set; }
            [Display(Name ="Primer apellido")]
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
            [EmailAddress(ErrorMessage ="Solo se permiten correos electrónicos")]
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

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new AplicationUser { 
                    FirstName = Input.FirstName,
                    LastName = Input.LastNameTwo,
                    LastNameTwo = Input.LastNameTwo,
                    CI = Input.CI,
                    ProfilePicture = Input.ProfilePicture,
                    UserName = Input.Email,
                    Email = Input.Email
                };
                var result = await _userManager.CreateAsync(user, Input.Password);


                
                await _signInManager.CreateUserPrincipalAsync(user);


                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //Code modificado para establcer el role por defecto;
                    await _userManager.AddToRoleAsync(user, Enums.Roles.Tecnico.ToString());

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
