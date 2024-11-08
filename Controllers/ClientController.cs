using ClientixAPI.Models;
using ClientixAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace ClientixAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // Получить все клиенты
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }

        // Получить клиента по ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        // Добавить нового клиента
        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdClient = await _clientService.AddClientAsync(client);
            return CreatedAtAction(nameof(GetClientById), new { id = createdClient.Id }, createdClient);
        }

        // Обновить данные клиента
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedClient = await _clientService.UpdateClientAsync(id, client);
            if (updatedClient == null)
                return NotFound();

            return Ok(updatedClient);
        }

        // Удалить клиента по ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var success = await _clientService.DeleteClientAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
