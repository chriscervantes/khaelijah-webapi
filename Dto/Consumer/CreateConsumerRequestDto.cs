
using api.Models;

namespace api.Dto.Consumer
{
    public class CreateConsumerRequestDto
    {
        public string AccountName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string? Mobile { get; set; }
    }
}