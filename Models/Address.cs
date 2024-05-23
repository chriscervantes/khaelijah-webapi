using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    [Table("address")]
    public class Address
    {
        [Column("id", TypeName = "varchar(36)")]
        public int Id { get; set; }

        [Column("address1", TypeName = "varchar(50)")]
        [MaxLength(100)]
        public string Address1 { get; set; }
        [Column("address2", TypeName = "varchar(50)")]
        [MaxLength(100)]
        public string? Address2 { get; set; }
        [Column("barangay_id", TypeName = "varchar(36)")]
        public string BarangayId { get; set; }
        [Column("municipal_id", TypeName = "varchar(36)")]
        public string MunicipalId { get; set; }
        [Column("province_id", TypeName = "varchar(36)")]
        public string ProvinceId { get; set; }
    }
}