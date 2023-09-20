using webapi_event__tarde.Contexts;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;

namespace webapi_event__tarde.Repositories
    {
    public class EventoRepository : IEventoRepository
        {
        private readonly EventContext _eventContext;

        public EventoRepository()
            {
            _eventContext = new EventContext();
            }
        public void Atualizar(Guid id, Evento evento)
            {
            Evento eventoBuscado = BuscarPorId(id);

            if (eventoBuscado != null)
                {
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.IdInstituicao = evento.IdInstituicao;
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                eventoBuscado.NomeEvento = evento.NomeEvento;

                _eventContext.Evento.Update(eventoBuscado);

                _eventContext.SaveChanges();
                }
            else
                return;
            }

        public Evento BuscarPorId(Guid id)
            {
            try
                {
                return _eventContext.Evento.Find(id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Evento evento)
            {
            try
                {
                _eventContext.Evento.Add(evento);
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
                _eventContext.Evento.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Evento> Listar()
            {
            try
                {
                return _eventContext.Evento.ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
