
using api.Data;
using api.Dto.Consumer;
using api.Mapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{

    [Route("api/consumer")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public ConsumerController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult> CreateConsumer([FromBody] CreateConsumerRequestDto consumerDto)
        {
            var consumerModel = consumerDto.ToConsumerFromCreateDto();
            await _context.Consumers.AddAsync(consumerModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = consumerModel.Id }, consumerModel);

        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var consumers = await _context.Consumers.ToListAsync();

            if (consumers == null)
            {
                return NotFound();
            }

            var transformConsumer = consumers.Select(s => s.ToConsumerDto());

            return Ok(transformConsumer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] string id)
        {
            var consumer = await _context.Consumers.FindAsync(id);

            return consumer == null ? NotFound() : Ok(consumer.ToConsumerDto());
        }
    }



}