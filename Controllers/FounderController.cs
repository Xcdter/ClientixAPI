using ClientixAPI.Models;
using ClientixAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientixAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FounderController : ControllerBase
    {
        private readonly IFounderService _founderService;

        public FounderController(IFounderService founderService)
        {
            _founderService = founderService;
        }

        // Получить всех учредителей
        [HttpGet]
        public async Task<IActionResult> GetAllFounders()
        {
            var founders = await _founderService.GetAllFoundersAsync();
            return Ok(founders);
        }

        // Получить учредителя по ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFounderById(int id)
        {
            var founder = await _founderService.GetFounderByIdAsync(id);
            if (founder == null)
                return NotFound();
            return Ok(founder);
        }

        // Добавить нового учредителя
        [HttpPost]
        public async Task<IActionResult> AddFounder([FromBody] Founder founder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdFounder = await _founderService.AddFounderAsync(founder);
            return CreatedAtAction(nameof(GetFounderById), new { id = createdFounder.Id }, createdFounder);
        }

        // Обновить данные учредителя
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFounder(int id, [FromBody] Founder founder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedFounder = await _founderService.UpdateFounderAsync(id, founder);
            if (updatedFounder == null)
                return NotFound();

            return Ok(updatedFounder);
        }

        // Удалить учредителя по ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFounder(int id)
        {
            var success = await _founderService.DeleteFounderAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
