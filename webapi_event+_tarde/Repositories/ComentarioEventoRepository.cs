﻿using webapi_event__tarde.Contexts;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;

namespace webapi_event__tarde.Repositories
    {
    public class ComentarioEventoRepository : IComentarioEventoRepository
        {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
            {
            _eventContext = new EventContext();
            }
        public void Atualizar(Guid id, ComentarioEvento comentarioEvento)
            {
            ComentarioEvento comentarioEventoBuscado = BuscarPorId(id);

            if (comentarioEventoBuscado != null)
                {
                comentarioEventoBuscado.Titulo = comentarioEvento.Titulo;

                _eventContext.ComentarioEvento.Update(comentarioEventoBuscado);

                _eventContext.SaveChanges();
                }
            else
                return;
            }

        public ComentarioEvento BuscarPorId(Guid id)
            {
            try
                {
                return _eventContext.ComentarioEvento.Find(id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(ComentarioEvento comentarioEvento)
            {
            try
                {
                _eventContext.ComentarioEvento.Add(comentarioEvento);
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
                _eventContext.ComentarioEvento.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<ComentarioEvento> Listar()
            {
            try
                {
                return _eventContext.ComentarioEvento.ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }