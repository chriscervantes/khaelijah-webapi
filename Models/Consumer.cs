
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace api.Models
{
    [Table("consumer")]
    public class Consumer
    {
        [Column("id")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("accountName")]
        [MaxLength(11)]
        public string AccountName { get; set; }

        [Column("firstName")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column("lastName")]
        [MaxLength(50)]
        public string LastName { get; set; }


        [Column("birthDate", TypeName = ("timestamp"))]
        public DateTime BirthDate { get; set; }
        [Column("mobile")]

        public string? Mobile { get; set; }

        public List<Address> Address { get; set; }

    }
}