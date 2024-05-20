using abra_test.Models;
using abra_test.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace abra_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class petController : ControllerBase
    {

        private readonly PetService _petsService;

        public petController(PetService petsService) =>
            _petsService = petsService;

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Pet>> Get(string id)
        {
            var pet = await _petsService.GetAsync(id);

            if (pet is null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpGet]
        public async Task<List<Pet>> Get() =>
            await _petsService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Pet newPet)
        {
            await _petsService.CreateAsync(newPet);

            return CreatedAtAction(nameof(Get), new { id = newPet.Id }, newPet);
        }
    }
}
