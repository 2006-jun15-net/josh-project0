using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Project0.DataAccess.Model;

namespace Project0.DataAccess
{
    class StoreRepository : IGenericRepository<Store>
    {
        private readonly project0Context _dbContext;
        public StoreRepository(project0Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Store> GetAll()
        {
            IQueryable<Store> items = _dbContext.Store
                .Include(s => s.StoreId);

            return (IEnumerable<Store>)items.Select(Mapper.MapDbEntryToStoreLocation);
        }

        public Store GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Store obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Store obj)
        {
            throw new NotImplementedException();
        }
    }
}
