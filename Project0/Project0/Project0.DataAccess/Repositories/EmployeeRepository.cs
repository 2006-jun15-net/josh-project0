using System.Collections.Generic;
using Project0.Library;

namespace Project0.DataAccess
{
    public class EmployeeRepository : IGenericRepository<Customer>
    {

        public EmployeeRepository()
        {
        }

        public void Delete(object id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Customer GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Customer obj)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Customer obj)
        {
            throw new System.NotImplementedException();
        }
    }
}