using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Models
{
    internal class Customer
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Telephone { get; set; }
        public int Mobile { get; set; }

        public virtual Address Address { get; set; } = null!;
    }
}
