using DataLagring_Projekt.Data;
using DataLagring_Projekt.Models;
using DataLagring_Projekt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Services
{

    internal class SqlService
    {
        private readonly SqlContext _context = new SqlContext();

        public int Create(Address address)
        {
            var _address = _context.Addresses.Where(x => x.StreetName == address.StreetName 
            && x.PostalCode == address.PostalCode 
            && x.City == address.City 
            && x.Country == address.Country).FirstOrDefault();

            if(address == null)
            {
                var addressEntity = new AddressEntity { StreetName = address.StreetName, PostalCode = address.PostalCode, City=address.City, Country=address.Country };
                
                _context.Addresses.Add(addressEntity);
                _context.SaveChanges();
                return addressEntity.Id;
            }
            return _address.Id;
        }


        //Create Customer
        public int Create(Customer customer)
        {
            var _customer = _context.Customers.Where(x => x.Email == customer.Email).FirstOrDefault();

            if (_customer == null)
            {
                var CustomerEntity = new CustomerEntity();

                CustomerEntity.FirstName = customer.FirstName;
                CustomerEntity.LastName = customer.LastName;
                CustomerEntity.Email = customer.Email;
                CustomerEntity.Telephone = customer.Telephone;
                CustomerEntity.Mobile = customer.Mobile;
                CustomerEntity.AddressId = Create(customer.Address);
                _context.Customers.Add(CustomerEntity);
                _context.SaveChanges();
                return CustomerEntity.Id;
            }
            return _customer.Id;
        }
    }
}
