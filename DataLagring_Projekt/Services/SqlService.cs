using DataLagring_Projekt.Data;
using DataLagring_Projekt.Models;
using DataLagring_Projekt.Models.Entities;
using Microsoft.EntityFrameworkCore;
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


        #region Create
        //Create Address
        public int CreateAddress(Address address)
        {
            var _address = _context.Addresses.Where(x => x.StreetName == address.StreetName && x.PostalCode == address.PostalCode && x.City == address.City && x.Country == address.Country).FirstOrDefault();

            if(_address == null)
            {
                var addressEntity = new AddressEntity { StreetName = address.StreetName, PostalCode = address.PostalCode, City = address.City, Country = address.Country };
                
                _context.Addresses.Add(addressEntity);
                _context.SaveChanges();
                return addressEntity.Id;
            }
            return _address.Id;
        }


        //Create Customer
        public int CreateCustomer(Customer customer)
        {
            var _customer = _context.Customers.Where(x => x.Email == customer.Email).FirstOrDefault();

            if (_customer == null)
            {
                var CustomerEntity = new CustomerEntity();

                CustomerEntity.FirstName = customer.FirstName;
                CustomerEntity.LastName = customer.LastName;
                CustomerEntity.Email = customer.Email;
                CustomerEntity.Telephone = customer.Telephone;
                CustomerEntity.AddressId = CreateAddress(customer.Address);

                _context.Customers.Add(CustomerEntity);
                _context.SaveChanges();
                return CustomerEntity.Id;
            }
            return -1;
        }

        //Create Admin
        public int CreateAdmin(Admins admin)
        {
            var _admin = _context.Admins.Where(x => x.AdminName == admin.AdminName).FirstOrDefault();
            if(_admin == null)
            {
                var AdminsEntity = new AdminsEntity { AdminName = admin.AdminName};
                AdminsEntity.AdminName = admin.AdminName;

                _context.Admins.Add(AdminsEntity);
                _context.SaveChanges();
                return AdminsEntity.Id;
            }
            return _admin.Id;
        }

        //Create Errand
        public int CreateErrand(Errands errand)
        {
            var _errand = _context.Errands.Where(x => x.Subject == errand.Subject).FirstOrDefault();
            if (_errand == null)
            {
                var ErrandsEntity = new ErrandsEntity();

                ErrandsEntity.Subject = errand.Subject;
                ErrandsEntity.CustomerId = errand.CustomerId;
                //ErrandsEntity.StatusId = errand.StatusId;
                ErrandsEntity.Status = errand.Status.ToString();
                ErrandsEntity.Description = errand.Description;
                ErrandsEntity.AdminId = errand.AdminId;

                _context.Errands.Add(ErrandsEntity);
                _context.SaveChanges();
                return ErrandsEntity.Id;
            }
            return -1;
        }


        #endregion Create

        //Read
        public IEnumerable<CustomerEntity>GetAll()
        {
            return _context.Customers.Include(x => x.Address);
        }

        public IEnumerable<ErrandsEntity>GetErrandList()
        {
            //return _context.Errands.Include(x => x.CustomerId);
            return _context.Errands.Include(x => x.Admin).Include(x => x.Customer);

        }

        public IEnumerable<AdminsEntity>GetAdminList()
        {
            return _context.Admins;
        }

       
    }


}
