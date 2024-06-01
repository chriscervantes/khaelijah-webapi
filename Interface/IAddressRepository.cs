using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interface
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAsync();
        Task<Address?> GetAddressByIdAsync(int id);
    }
}