using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Models;

namespace api.Mapper
{
    public static class AddressMapper
    {
        public static AddressDto ToAddressDto(this Address addressModel)
        {
            return new AddressDto
            {
                Id = addressModel.Id,
                Address1 = addressModel.Address1,
                Address2 = addressModel.Address2,
                BarangayId = addressModel.BarangayId,
                MunicipalId = addressModel.MunicipalId,
                ProvinceId = addressModel.ProvinceId
            };
        }
    }
}