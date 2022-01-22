using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Models
{

    public enum Statuses
    {
        Registered = 0,
        Investigating = 1,
        Closed = 2,
    }
    internal class Errands
    {
        public string Subject { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int CustomerId { get; set; }
        public int AdminId { get; set; }
        public string AdminName { get; set; } = null!;

        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }

        public Statuses Status { get; set; }

    }
}
