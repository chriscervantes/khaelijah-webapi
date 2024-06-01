
using api.Data;
using api.Dto.Consumer;
using api.Interface;
using api.Mapper;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{

    [Route("api/consumer")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IConsumerRepository _consumerRepo;
        public ConsumerController(ApplicationDbContext context, IConsumerRepository consumerRepo)
        {
            _context = context;
            _consumerRepo = consumerRepo;

        }


        [HttpPost]
        public async Task<IActionResult> CreateConsumer([FromBody] CreateConsumerRequestDto consumerDto)
        {
            var consumerModel = consumerDto.ToConsumerFromCreateDto();
            consumerModel.BirthDate = consumerModel.BirthDate.ToLocalTime();
            await _consumerRepo.CreateAsync(consumerModel);

            return Created();  // CreatedAtAction(nameof(GetById), new { id = consumerModel.Id }, consumerModel);

        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var consumers = await _consumerRepo.GetAllAsync();

            if (consumers == null)
            {
                return NotFound();
            }

            var transformConsumer = consumers.Select(s => s.ToConsumerDto());

            return Ok(transformConsumer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {

            var consumer = await _consumerRepo.GetByIdAsync(id);

            return consumer == null ? NotFound() : Ok(consumer.ToConsumerDto());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] CreateConsumerRequestDto consumerDto)
        {

            var consumer = await _consumerRepo.UpdateAsync(id, consumerDto);

            if (consumer == null)
            {
                return NotFound();
            }

            return Ok(consumer.ToConsumerDto());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {

            var consumer = await _consumerRepo.DeleteAsync(id);

            if (consumer == null)
            {
                return NotFound();
            }

            return StatusCode(200);
        }
    }
}