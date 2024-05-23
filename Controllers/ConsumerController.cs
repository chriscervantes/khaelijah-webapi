
using api.Data;
using api.Dto.Consumer;
using api.Mapper;
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
            consumerModel.BirthDate = consumerModel.BirthDate.ToLocalTime();
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
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var consumer = await _context.Consumers.FindAsync(id);

            return consumer == null ? NotFound() : Ok(consumer.ToConsumerDto());
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CreateConsumerRequestDto consumerDto)
        {

            var consumer = _context.Consumers.FirstOrDefault(s => s.Id == id);

            if (consumer == null)
            {
                return NotFound();
            }


            consumer.AccountName = consumerDto.AccountName;
            consumer.FirstName = consumerDto.FirstName;
            consumer.LastName = consumerDto.LastName;
            consumer.BirthDate = consumerDto.BirthDate.ToLocalTime();
            consumer.Mobile = consumerDto.Mobile;

            _context.Update(consumer);
            _context.SaveChanges();

            return Ok(consumer.ToConsumerDto());
        }


    }



}