using Filmes.Data;
using Filmes.Data.DTO;
using Filmes.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Filmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _filmeContext;
        private static int id = 1;


        public FilmeController(FilmeContext filmeContext)
        {
            _filmeContext = filmeContext;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            Filme filme = Filme.BuildFilmeByDto(filmeDto);
            _filmeContext.Add(filme);
            _filmeContext.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id}, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _filmeContext.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme filme = _filmeContext.Filmes.FirstOrDefault(i => id.Equals(i.Id));
            return null == filme ? NotFound() : Ok(filme);
        }
    }
}
