using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Models.Entities
{
    internal class ErrandsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; } = null!;

        [Required]
        [StringLength(150)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        public DateTime DateEdited { get; set; } = DateTime.Now;

        [Required]
        public int CustomerId { get; set; }

        //public virtual ICollection<CustomerEntity> CustomerEntities { get; set; }
        public int AdminId { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        public virtual AdminsEntity Admin { get; set; }

        public virtual CustomerEntity Customer { get; set; }

        
    }
}
