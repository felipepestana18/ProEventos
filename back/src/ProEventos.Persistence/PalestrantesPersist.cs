using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantesPersist : IPalestrantePersist
    {

        private readonly ProEventosContext _context;


        public PalestrantesPersist(ProEventosContext context)
        {
            this._context = context;

        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.PalestranteEventos)
                .ThenInclude(pe => pe.Evento);
            }
            query = query.OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSociais);
            if (includeEventos)
            {
                query = query.Include(p => p.PalestranteEventos)
                .ThenInclude(p => p.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedeSociais);
            if (includeEventos)
            {
                query = query.Include(p => p.PalestranteEventos)
                .ThenInclude(p => p.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Id == PalestranteId);
            return await query.FirstOrDefaultAsync();
        }
    }
}