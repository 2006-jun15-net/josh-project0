using Project0.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    /// <summary>
    /// Static Mapper object translates objects to entries in the database and entries in the database to objects
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Maps a Customer from the Database to a Customer object
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Maps a Customer object to an entry in the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Model.Customer MapCustomerToDbEntry(Library.Customer customer)
        {
            return new Model.Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }
        /// <summary>
        /// Maps a Store entry from the database to a StoreLocation object
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Maps a Product database entry to a Product object
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
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