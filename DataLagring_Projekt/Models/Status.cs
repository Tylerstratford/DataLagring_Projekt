using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Models
{
    internal class Status
    {
        public enum Statuses
        {
            Registered = 1,
            Investigating = 2,
            Closed = 3
        }

        public Statuses Status1 { get; set; } 
    }
}
