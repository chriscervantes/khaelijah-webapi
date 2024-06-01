using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dto.Consumer
{
    public class ConsumerDto
    {

        public int Id { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string? Mobile { get; set; }
        public List<AddressDto> Addresses { get; set; }

    }
}