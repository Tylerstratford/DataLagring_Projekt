using DataLagring_Projekt.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Data
{
    internal class SqlContext : DbContext
    {
        public SqlContext()
        {

        }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public virtual DbSet<AddressEntity> Addresses { get; set; }
        public virtual DbSet<AdminsEntity> Admins { get; set; }
        public virtual DbSet<CustomerEntity> Customers { get; set; }
        public virtual DbSet<ErrandsEntity> Errands { get; set; }
        public virtual DbSet<StatusEntity> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tyler\Desktop\DataLagring_Projekt\DataLagring_Projekt\Data\Sql_Database.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }
    }
}
