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
        public virtual CustomerEntity CustomerEntity { get; set; } = null!;
        public int StatusId { get; set; }
        public virtual StatusEntity StatusEntity { get; set; } = null!;
        public int AdminId { get; set; }
        public virtual AdminsEntity AdminsEntity { get; set; } = null!;


    }
}
