using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Project0.DataAccess.Model;

namespace Project0.DataAccess
{
    public class CustomerRepository
    {

        private readonly project0Context _dbContext;//This is the Customer in the Model folder

        /// <summary>
        /// Repository for the Customer object.
        /// </summary>
        /// <param name="dbContext"></param>
        public CustomerRepository(project0Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Delete Customer object from DB.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(object id)
        {
            Customer entity = _dbContext.Customer.Find(id);
            _dbContext.Remove(entity);
            Save();
        }

        /// <summary>
        /// Get all records from Customer table in the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAll()
        {
            IQueryable<Customer> items = _dbContext.Customer
                .Include(c => c.CustomerId);

            return (IEnumerable<Customer>)items.Select(Mapper.MapDbEntryToCustomer);
        }

        public Project0.Library.Customer GetById(object id)
        {
            
            return Mapper.MapDbEntryToCustomer(customer: _dbContext.Customer.Find(id));
        }

        public void Insert(Project0.Library.Customer obj)
        {
            Customer entity = Mapper.MapCustomerToDbEntry(obj);
            _dbContext.Add(entity);
            Save();
        }

        public void Save()
        {
           _dbContext.SaveChanges();
        }

        //public void Update(Customer obj)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}