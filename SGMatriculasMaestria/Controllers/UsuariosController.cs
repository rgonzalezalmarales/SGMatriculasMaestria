using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGMatriculasMaestria.DTOs;
using SGMatriculasMaestria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<AplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UsuariosController(UserManager<AplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
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

            foreach(AplicationUser user in users)
            {
                
                userDtos.Add(new UserDto
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    LastNameTwo = user.LastNameTwo,
                    CI = user.CI,
                    ProfilePicture = user.ProfilePicture,
                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
                });                
            }

            return View(userDtos);
        }

        // GET: UsersController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var userDto = new UserDto
            {
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                LastNameTwo = user.LastNameTwo,
                CI = user.CI,
                ProfilePicture = user.ProfilePicture,
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
            };
            //ViewBag.Roles = await _roleManager.Roles.ToListAsync();

            return View(userDto);
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

                var user = new AplicationUser { 
                    UserName = userDto.Email, 
                    Email = userDto.Email,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    LastNameTwo = userDto.LastNameTwo,
                    CI = userDto.CI,
                    ProfilePicture = userDto.ProfilePicture,
                    //UserName = userDto.Email,
                    //Email = userDto.Email
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
                var defaulUser = new AplicationUser
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
                ViewBag.Roles = _roleManager.Roles.ToList();
                return View(userDto);
            }
        }

        private async Task<string> GetIdRoleByUserAsync(AplicationUser user)
        {
            string roleId = "";
            var roleName = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (roleName is not null)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role is not null)
                    roleId = role.Id;
            }

            return roleId;
        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user is not null)
            {
                var userDto = new UserDto
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    LastNameTwo = user.LastNameTwo,
                    CI = user.CI,
                    ProfilePicture = user.ProfilePicture,
                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
                    //Role = await GetIdRoleByUserAsync(user)
                };
                ViewBag.Roles = await _roleManager.Roles.ToListAsync();

                return View(userDto);

            }

            return View();
            
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();
                    
                    if (user is null)
                        throw new Exception(string.Format("No se econtró ningún usuario con el código {0}", id));

                    var a = (await _userManager.GetRolesAsync(user)).ToList();
                    var oldRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                    /*if (!string.IsNullOrEmpty(userDto.UserName))
                        user.UserName = userDto.UserName;*/
                    if (!string.IsNullOrEmpty(userDto.Email))
                        user.Email = userDto.Email;
                    if (!string.IsNullOrEmpty(userDto.FirstName))
                        user.FirstName = userDto.FirstName;
                    if (!string.IsNullOrEmpty(userDto.LastName))
                        user.LastName = userDto.LastName;
                    if (!string.IsNullOrEmpty(userDto.LastNameTwo))
                        user.LastNameTwo = userDto.LastNameTwo;
                    if (!string.IsNullOrEmpty(userDto.CI))
                        user.CI = userDto.CI;
                    if (!string.IsNullOrEmpty(userDto.FirstName))
                        user.FirstName = userDto.FirstName;
                    if (!string.IsNullOrEmpty(userDto.Role) && oldRole != userDto.Role)
                    {
                        var roles = new List<string> {
                               Enums.Roles.Administrador.ToString(),
                               Enums.Roles.Especialista.ToString(),
                               Enums.Roles.Tecnico.ToString(),
                        };
                        foreach (var r in roles)
                        {
                            await _userManager.RemoveFromRoleAsync(user, r);
                        }
                        await _userManager.AddToRoleAsync(user, userDto.Role);
                    }

                    await _userManager.UpdateAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception exp)
                {
                    ViewBag.ErrorMessage = exp.Message;
                }
            }



            ViewBag.Roles = _roleManager.Roles.ToList();
            return View(userDto);
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userDto = new UserDto
            {
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                LastNameTwo = user.LastNameTwo,
                CI = user.CI,
                ProfilePicture = user.ProfilePicture,
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
            };

            return View(userDto);
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
