using System.Linq;
using System.Collections.Generic;
using System.Collections;



namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void IncluirUsuario(Usuario user)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(user);
                bc.SaveChanges();

            }
        }

         public void EditarUsuario(Usuario user)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario u = bc.Usuarios.Find(user.Id);
               
                u.Login = user.Login;
                u.Nome = user.Nome;
                u.Senha = user.Senha;
                u.Tipo = user.Tipo;
                                
                bc.SaveChanges();
            }
        }

        public void ExcluirUsuario(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
               bc.Usuarios.Remove(bc.Usuarios.Find(id));
               bc.SaveChanges();
            }
        }

        public Usuario Listar(int Id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
               return bc.Usuarios.Find(Id);
               
            }
        }

        public List<Usuario> Listar()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
               return bc.Usuarios.ToList();
                              
            }
        }

    }

}