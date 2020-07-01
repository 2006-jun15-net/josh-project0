using Project0.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    public static class Mapper
    {
        public static Library.Customer MapDbEntryToCustomer(Model.Customer customer)
        {
            int Id;
            string FirstName, LastName;
            return new Project0.Library.Customer
            (
                Id = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            );
        }

        public static Model.Customer MapCustomerToDbEntry(Library.Customer customer)
        {
            return new Model.Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }
        
        public static Library.StoreLocation MapDbEntryToStoreLocation(Model.Store store)
        {
            int storeId;
            string storeName, storeAddress;
            return new Library.StoreLocation
            (
                storeId = store.StoreId,
                storeName = store.StoreName,
                storeAddress = store.StoreAddress
            );
        }

        //public static Model.Store MapStoreLocationToDbEntry(Library.StoreLocation store)
        //{
        //    throw new NotImplementedException();
        //}

        public static Library.Product MapDbEntrytoProduct(Model.Product product)
        {
            int prodId;
            string prodDescription;
            double prodPrice;
            return new Library.Product
            (
                prodId = product.ProductId,
                prodDescription = product.ProductDescription,
                prodPrice = (double)product.ProductPrice
            );
            
        }

        

    }
}