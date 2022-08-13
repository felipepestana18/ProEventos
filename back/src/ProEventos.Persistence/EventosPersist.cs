using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventosPersist : IGeralPersist, IEventoPersist
    {
        private readonly ProEventosContext _context;

        public EventosPersist(ProEventosContext context)
        {
            this._context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedeSociais);

            query = query.OrderBy(e => e.Id);

            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedeSociais);

            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedeSociais);

            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
