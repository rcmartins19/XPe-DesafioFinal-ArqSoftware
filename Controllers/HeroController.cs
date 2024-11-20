using DesafioFinalRodrigoMartins.Models.Domains;
using DesafioFinalRodrigoMartins.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFinalRodrigoMartins.Controllers
{
    [ApiController]
    [Route("v1")]

    public class HeroController : ControllerBase
    {
        private readonly IHeroRepository _repository;

            public HeroController(IHeroRepository repository)
        {
            _repository = repository;
        }

        // Create - Criar novo Hero

        [HttpPost("add-new-hero")]
        public async Task<ActionResult<Hero>> CreateNewHero(Hero hero)
        {
            await _repository.Add(hero);
            return CreatedAtAction(nameof(CreateNewHero), new {id = hero.Id, hero});
        }

        // Get All - Buscar todos Heroes
        [HttpGet("get-all-heroes")]
        public async Task<ActionResult<IEnumerable<Hero>>> GetAllHeroes()
        {
            return Ok(await _repository.GetAll());
        }

        // Get - By Id - Busca Hero pelo Id
        [HttpGet("get-hero-by-id/{id}")]
        public async Task<ActionResult<Hero>> GetHeroById(int id)
        {
            var hero = await _repository.GetById(id);
            if (hero == null)
                return NotFound("Id não cadastrado");

            return Ok(hero);
        }

        // Get - By Name - Busca Hero pelo nome
        [HttpGet("search-hero")]
        public async Task<ActionResult<IEnumerable<Hero>>> GetHeroesByName(string name)
        {
            var heroes = await _repository.GetByName(name);
            if (!heroes.Any())
                return NotFound("Não existe hero com este nome");

            return Ok(heroes);
        }

        // Put - Update - Atualizar Hero
        [HttpPut("update-hero/{id}")]

        public async Task<IActionResult> UpdateHero(int id, Hero hero)
        {
            if (id != hero.Id)
                return BadRequest("Não é possível mudar o Id");

            await _repository.Update(hero);
            return Ok(hero);
        }

        // Delete - Deletar Hero
        [HttpDelete("delete-hero/{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await _repository.GetById(id);
            if (hero == null)
                return NotFound("Não existe hero com este Id");

            await _repository.Delete(hero);
            return Ok("Hero deletado com sucesso");
        }

        // Count - Contar a quantidade de Heroes cadastrados
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetHeroCount()
        {
            return Ok(await _repository.Count());
        }

    }
}
