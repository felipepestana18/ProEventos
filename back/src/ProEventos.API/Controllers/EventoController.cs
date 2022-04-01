using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[] {
                new Evento() {
                    EventoId = 1,
                    Local = "São Mateus",
                    DataEvento = DateTime.Now.ToString("dd/MM/yyyy"),
                    QtdPessoas = 100000,
                    Lote = "1 - Promo",
                    ImagemURL = null
                },
                new Evento() {
                    EventoId = 2,
                    Local = "Jardim Santo André",
                    DataEvento = DateTime.Now.ToString("dd/MM/yyyy"),
                    QtdPessoas = 100000,
                    Lote = "2 - Promo",
                    ImagemURL = null
                }
            };
        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }
        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
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
