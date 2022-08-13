using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        private readonly ProEventosContext _context;

        public EventosController(ProEventosContext context)
        {
            _context = context;
        }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {

        return _context.Eventos;
    }

    [HttpGet("{id}")]
    public Evento Get(int id)
    {
        return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
    }

    [HttpPost]
    public string Post()
    {
        return "Exemplo com POST";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return "Exemplo com Put";
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return "Exemplo com Delete";
    }
}
}