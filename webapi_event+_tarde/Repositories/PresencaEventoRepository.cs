using webapi_event__tarde.Contexts;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;

namespace webapi_event__tarde.Repositories
    {
    public class PresencaEventoRepository : IPresencaEventoRepository
        {
        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
            {
            _eventContext = new EventContext();
            }
        public void Atualizar(Guid id, PresencaEvento presencaEvento)
            {
            PresencaEvento presencaEventoBuscado = BuscarPorId(id);

            if (presencaEventoBuscado != null)
                {
                presencaEventoBuscado.Titulo = presencaEvento.Titulo;

                _eventContext.PresencaEvento.Update(presencaEventoBuscado);

                _eventContext.SaveChanges();
                }
            else
                return;
            }

        public PresencaEvento BuscarPorId(Guid id)
            {
            try
                {
                return _eventContext.PresencaEvento.Find(id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(PresencaEvento presencaEvento)
            {
            try
                {
                _eventContext.PresencaEvento.Add(presencaEvento);
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
                _eventContext.PresencaEvento.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<PresencaEvento> Listar()
            {
            try
                {
                return _eventContext.PresencaEvento.ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
