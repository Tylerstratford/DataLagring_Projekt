using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Models
{
    internal class Errands
    {
        public string Subject { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int CustomerId { get; set; }
        public int AdminId { get; set; }

        public int StatusId { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }

    }
}
