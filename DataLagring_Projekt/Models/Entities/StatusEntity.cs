using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Models.Entities
{
    internal class StatusEntity
    {
        [Key]
        public int Id { get; set; }

        public enum Satuses
        {
            Registered = 1,
            Investigating = 2,
            Closed = 3
        }

        [Required]
        public Satuses Status { get; set; }
    }
}
