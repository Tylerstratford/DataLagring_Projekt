using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Models
{
    internal class Address
    {
        public string StreetName { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

    }
}
