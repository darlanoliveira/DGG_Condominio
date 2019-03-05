using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DGG_Condominio.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using DGG_Condominio.Modulos;

namespace DGG_Condominio.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Login(string email = "", string senha = "")
        {
            LoginViewModelo vm = new LoginViewModelo();
            vm.Email = email;
            vm.Senha = senha;
            var usuario = new List<UsuariosModelos>();


            usuario = HomeModel.BuscaUsuario(vm.Email, vm.Senha);
            if (usuario != null)
            {
              
                Logar(vm);
              
                return RedirectToAction("Condominos");
            }
            else
            {
                return View();
            }
     
        }

        [HttpPost]
        public async Task<IActionResult> Logar(LoginViewModelo vm)
        {       
            if (ModelState.IsValid)
            {
                
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, vm.Email));
                identity.AddClaim(new Claim(ClaimTypes.Name, vm.Email));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = vm.RememberMe });


                return RedirectToAction("Condominos");

            }
            else
            {
                ModelState.AddModelError("", "username or password is blank");
                return RedirectToAction("Login");
            }

           
           
        }



        public IActionResult administracao()
        {
            return View();
        }

        public IActionResult configuracao()
        {
            return View();
        }
        
        public IActionResult configuracaocond()
        {
            return View();
        }
        
        public IActionResult documentos()
        {
            return View();
        }
        
        public IActionResult documentoscond()
        {
            return View();
        }
        
        public IActionResult principal()
        {
            return View();
        }

        public IActionResult condominos()
        {
            UsuariosModelos usuarios = new UsuariosModelos();

            var usuarioCodigo = usuarios.USU_COD;
            var nomeUsuario = "Peter"; //No banco MOR_NOME
            ViewBag.Nome = nomeUsuario;
            ViewBag.AlteraNome = 1;
            return View();
        }

        public IActionResult moradores(string nome)
        {
            
            
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModelo { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
