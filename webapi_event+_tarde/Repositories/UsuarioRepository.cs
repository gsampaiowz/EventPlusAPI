using Microsoft.EntityFrameworkCore;
using webapi_event__tarde.Contexts;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;
using webapi_event__tarde.Utils;

namespace webapi_event__tarde.Repositories
    {
    public class UsuarioRepository : IUsuarioRepository
        {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
            {
            _eventContext = new EventContext();
            }
        public void Atualizar(Guid id, Usuario usuario)
            {
            Usuario usuarioBuscado = BuscarPorId(id);

            if (usuarioBuscado != null)
                {
                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Nome = usuario.Nome;

                _eventContext.Usuario.Update(usuarioBuscado);

                _eventContext.SaveChanges();
                }
            else
                return;
            }

        public Usuario BuscarPorEmailESenha(string email, string senha)
            {
            try
                {
                Usuario usuarioBuscado = _eventContext.Usuario.Include(u => u.TipoUsuario).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                    {
                    if (Criptografia.CompararHash(senha, usuarioBuscado.Senha!))
                        {
                        return usuarioBuscado;
                        }
                    return null!;
                    }
                return null!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public Usuario BuscarPorId(Guid id)
            {
            try
                {
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                        {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,

                        TipoUsuario = new TipoUsuario
                            {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario!.Titulo
                            }
                        }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Usuario usuario)
            {
            try
                {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Usuario.Add(usuario);

                _eventContext.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Deletar(Guid id)
            {
            try
                {
                _eventContext.Usuario.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Usuario> Listar()
            {
            try
                {
                return _eventContext.Usuario.ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
