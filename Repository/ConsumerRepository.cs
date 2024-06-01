
using System.Diagnostics;
using api.Data;
using api.Dto.Consumer;
using api.Interface;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;



namespace api.Repository
{

    public class ConsumerRepository : IConsumerRepository
    {

        private readonly ApplicationDbContext _context;
        public ConsumerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Consumer?> DeleteAsync(int id)
        {

            var consumer = await _context.Consumers.FirstOrDefaultAsync(consumer => consumer.Id == id);

            if (consumer == null)
            {
                return null;
            }

            _context.Consumers.Remove(consumer);

            await _context.SaveChangesAsync();
            return consumer;
        }

        public async Task<List<Consumer>> GetAllAsync()
        {

            return await _context.Consumers.Include(consumer => consumer.Address).ToListAsync();
        }

        public async Task<Consumer> CreateAsync(Consumer consumerModel)
        {
            await _context.Consumers.AddAsync(consumerModel);
            await _context.SaveChangesAsync();
            return consumerModel;
        }

        public async Task<Consumer?> GetByIdAsync(int id)
        {

            return await _context.Consumers.Include(consumer => consumer.Address).FirstOrDefaultAsync(el => el.Id == id);

        }

        public async Task<Consumer?> UpdateAsync(int id, CreateConsumerRequestDto consumerDto)
        {

            var existingConsumer = _context.Consumers.Include(consumer => consumer.Address).FirstOrDefault(s => s.Id == id);

            Trace.Write("test me");
            if (existingConsumer == null)
            {
                return null;
            }


            existingConsumer.AccountName = consumerDto.AccountName;
            existingConsumer.FirstName = consumerDto.FirstName;
            existingConsumer.LastName = consumerDto.LastName;
            existingConsumer.BirthDate = consumerDto.BirthDate.ToLocalTime();
            existingConsumer.Mobile = consumerDto.Mobile;

            await _context.SaveChangesAsync();

            return existingConsumer;

        }
    }
}