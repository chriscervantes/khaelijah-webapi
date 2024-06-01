using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class AddressDto
    {

        public int Id { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string BarangayId { get; set; }
        public string MunicipalId { get; set; }
        public string ProvinceId { get; set; }
    }
}