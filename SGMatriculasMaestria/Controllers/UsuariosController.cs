using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UsuariosController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = new List<UserDto>();

            foreach(IdentityUser user in users)
            {
                var first = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                userDtos.Add(new UserDto
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = "First",
                    LastName ="last",
                    Id = user.Id,
                    Role = first is not null? first: ""
                });
            }

            return View(userDtos);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {//Id, Name, NormalizedName
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View();
        }

        //IFormCollection collection => parámetros originales
        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserDto userDto)
        {
            try
            {
                var useName = userDto.Email.Split("@")[0];

                var user = new IdentityUser { 
                    UserName = userDto.Email, 
                    Email = userDto.Email,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                if (_userManager.Users.All(u => u.Id != user.Id))
                {
                    var userDb = await _userManager.FindByEmailAsync(user.Email);
                    if(userDb is null)
                    {

                        var result = await _userManager.CreateAsync(user, userDto.Password);

                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, (await _roleManager.FindByIdAsync(userDto.Role)).ToString());
                        }
                    }
                }
                    

                

                /*var email = "administrador@gmail.com";
                var defaulUser = new IdentityUser
                {
                    Email = email,
                    UserName = email,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                if (userManager.Users.All(u => u.Id != defaulUser.Id))
                {
                    var user = await userManager.FindByEmailAsync(defaulUser.Email);
                    if (user is null)
                    {
                        await userManager.CreateAsync(defaulUser, "Tesis2021+.");
                        await userManager.AddToRoleAsync(defaulUser, Enums.Roles.Administrador.ToString());
                    }
                }*/


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(new UserDto { 
                Email = user.Email,
                UserName = user.UserName,
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
            });
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, UserDto userDto)
        {

            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                    throw new Exception("No se encontró ningun usuario con el código proporcionado");
                    //return NotFound();

                var isAdmin = await _userManager.IsInRoleAsync(user, Enums.Roles.Administrador.ToString());
                if (isAdmin)
                {
                    var adminList = await _userManager.GetUsersInRoleAsync(Enums.Roles.Administrador.ToString());
                    if (adminList.Count == 1)
                        throw new Exception(string.Format("No se puede eliminar al usuario '{0}' porque es el único {1}.", user.UserName, Enums.Roles.Administrador));
                }

                await _userManager.DeleteAsync(user);
                
                //_userManager.DeleteAsync()
                return RedirectToAction(nameof(Index));
            }
            catch(Exception exp)
            {
                ViewBag.ErrorMessage = exp.Message;
                return View();
            }
        }
    }
}
