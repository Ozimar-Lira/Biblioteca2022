using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult ListaDeUsuarios(){
            
            List<Usuario> Listagem = new UsuarioService().Listar();

            return View();

        }

        public IActionResult EditarUsuario(int id)
        {
            Usuario user = new UsuarioService().Listar(id);
            return View(user);
                        
        }

        [HttpPost]
         public IActionResult EditarUsuario(Usuario userEditado)
        {
            UsuarioService us = new UsuarioService();
            return RedirectToAction("ListaDeUsuarios");
                        
        }

        public IActionResult RegistrarUsuarios()
        {
    
            // autenticação
            return View();
                        
        }

        [HttpPost]
        public IActionResult RegistrarUsuarios(Usuario novoUser)
        {
           
            // autenticação
            // criptografia de senha

            UsuarioService us = new UsuarioService();
            us.IncluirUsuario(novoUser);

            return RedirectToAction("ListaDeUsuarios");
                        
        }

        public IActionResult ExcluirUsuario(int id)
        {
           
            UsuarioService us = new UsuarioService();
            us.ExcluirUsuario(id);

            return RedirectToAction("ListaDeUsuarios");
                        
        }

          public IActionResult Sair()
        {
           
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
                        
        }

           public IActionResult NeedAdmin()
        {
           
           // autenticação
           return View();                
        }

    }
}