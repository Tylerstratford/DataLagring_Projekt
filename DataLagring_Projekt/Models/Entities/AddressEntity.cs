using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Models.Entities
{
    internal class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string StreetName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string PostalCode { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Country { get; set; } = null!;

        public virtual ICollection<CustomerEntity> Customers { get; set; } = new List<CustomerEntity>();
    }
}
