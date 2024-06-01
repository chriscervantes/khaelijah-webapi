
using api.Models;
using api.Dto.Consumer;

namespace api.Interface
{
    public interface IConsumerRepository
    {

        Task<List<Consumer>> GetAllAsync();
        Task<Consumer?> GetByIdAsync(int id);
        Task<Consumer> CreateAsync(Consumer consumerModel);
        Task<Consumer?> UpdateAsync(int id, CreateConsumerRequestDto consumerDto);

        Task<Consumer?> DeleteAsync(int id);
    }
}