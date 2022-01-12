using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    internal class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength (50)]
        public string LastName { get; set; } =null!;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        public int Telephone { get; set; }

        [Required]
        public int Mobile { get; set; }

        [Required]
        public int AddressEntityId { get; set; }
        public virtual AddressEntity AddressEntity { get; set; } = null!;

        //public virtual ICollection<AddressEntity> Address { get; set; } = null!;

    }
}
