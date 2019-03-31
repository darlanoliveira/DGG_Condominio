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
using Microsoft.AspNetCore.Http;
using System.IO;

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
        
        public IActionResult administracao(string msgenc = "", string bloco = "", string apto = "", int tipo = 0, string rastreio = "", DateTime recebimento = default(DateTime), DateTime retirada = default(DateTime),string msgenv = "",string msgavisos = "")
        {


            //-----------------------Encomendas--------------------------------//
            //ViewBag onde aparece as mensagens da parte de encomendas.
            ViewBag.MsgEnc = msgenc;

            //ViewBags que guardarão os valores dos campos de encomenda
            ViewBag.Bloco = bloco;
            ViewBag.Apto = apto;
            ViewBag.Tipo = tipo;
            ViewBag.Rastreio = rastreio;
            if(recebimento == default(DateTime))
            {
                ViewBag.Recebimento = DateTime.Now;
            }
            else
            {
                ViewBag.Recebimento = recebimento;
            }        
            ViewBag.Retirada = retirada;
            //-----------------------------------------------------------------//

            //-------------Pacotes e Envelopes---------------------------------//
            ViewBag.MsgEnv = msgenv;

            //---------------Aluguel Vagas --------------------------------//

            //--------------Quadro de Avisos------------------------------//
            ViewBag.MsgAvisos = msgavisos;




                   
            return View();
        }
        public IActionResult SalvarBuscarEncomendas(string bloco = "", string apto = "",int tipo = 0,string rastreio = "",DateTime recebimento = default(DateTime), DateTime retirada = default(DateTime),string botao = "")
        {
            if(botao == "Salvar")
            {
                if (bloco == null || apto == null || rastreio == null)
                {
                    return RedirectToAction("administracao", new { msgenc = "Preencha todos os campos!" });
                }
                if (recebimento == default(DateTime))
                {
                    recebimento = DateTime.Now;
                }

                var usuario = HomeModel.DadosUsuario("USU_COD", iduser());

                var retorno = HomeModel.SalvarEncomenda(bloco, apto, tipo, rastreio, recebimento, retirada, usuario);

                return RedirectToAction("administracao", new { msgenc = retorno });
            }

            if (botao == "Buscar")
            {
                var buscar = HomeModel.BuscarEncomendas(rastreio);
                return RedirectToAction("administracao", new { bloco = (buscar[0].ENC_BLOCO).ToString(), apto = (buscar[0].ENC_APTO).ToString(), tipo = buscar[0].ENC_TIPO, rastreio = rastreio, recebimento = buscar[0].ENC_DATA, retirada = buscar[0].ENC_DATARET });
            }

            return null;
        }

        public IActionResult SalvarEnvPac(string nomepac, string bloco = "", string apto = "", DateTime recebimento = default(DateTime))
        {
            if(nomepac == null || bloco == null || apto == null)
            {
                return RedirectToAction("administracao", new { msgenv = "Preencha os campos corretamente!" });
            }
            var usuario = HomeModel.DadosUsuario("USU_COD", iduser());
            var retorno = HomeModel.SalvarEnvPac(bloco, apto, nomepac, recebimento, usuario);


           
            return RedirectToAction("administracao", new { msgenv = retorno });
        }

        public IActionResult SalvarAviso(string aviso, DateTime dataexpira)
        {
            if(aviso == null || dataexpira == null)
            {
                return RedirectToAction("administracao", new { msgavisos = "Preencha todos campos!" });
            }

            var retorno = HomeModel.SalvarAvisoGeral(aviso, dataexpira);

            return RedirectToAction("administracao", new { msgavisos = retorno });
        }

        [HttpPost]
        public IActionResult CadDoc(IFormFile File, string nomedoc,DateTime datacad,string resconteudo)
        {
            
            MemoryStream doc = new MemoryStream();
            File.CopyTo(doc);
            
            HomeModel.SalvarDoc(nomedoc, datacad, doc.ToArray(), resconteudo);

            return RedirectToAction("documentos");
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
            var usuario = new List<UsuariosModelos>();
            usuario = HomeModel.AtualUsuario();

            ViewBag.buscarAreas = HomeModel.BuscaAreasComuns();


            foreach (var item in usuario)
            {
                ViewBag.Nome = item.USU_NOME;
            }
            
            
            return View();
        }

        public IActionResult SalvarMsg(string titulo, string mensagem)
        {
            var usuario = HomeModel.AtualUsuario();
            var usu_cod = 0;
            foreach (var item in usuario)
            {
                usu_cod = item.USU_COD;
            }
            
            HomeModel.SalvarMensagem(titulo, mensagem, usu_cod);

            return RedirectToAction("condominos");
        }

        public IActionResult SalvarRsv(int areaComumCod, DateTime dataDesejada, byte[] lista, string botao)
        {
            if (botao == "Salvar")
            {
                var usuarios = HomeModel.AtualUsuario();
                var usuarioCodigo = 0;
                var usuarioCadastro = 0;
                foreach (var usuario in usuarios)
                {
                    usuarioCodigo = usuario.USU_COD;
                    usuarioCadastro = usuario.USU_COD;
                }

                HomeModel.SalvarReservas(usuarioCodigo, usuarioCadastro, 1, dataDesejada, 1, areaComumCod, lista);

                
                return RedirectToAction("Condominos");
            }

            else
            {
                return null;
            }

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

        public  string iduser() // Busca o login do usuário, nesse caso o email, visto que pessoa se loga pelo email
        {
            var id = User.Identity;
            return id.Name.ToString();
        }



    }
}
