using BlApi;
using BO;
using Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using static BO.Exceptions;

namespace BlImplementation
{
    internal class Product : BlApi.IProduct
    {
        private IDal Dal = new DalList();

        void BlApi.IProduct.Add(BO.Product product)
        {
            if (product.ID > 0)
            {
                DO.Product prodDO = new DO.Product();
                prodDO.Name = product.Name;
                prodDO.ID = product.ID;
                prodDO.InStock = product.InStock;
                prodDO.Price = product.Price;
                Dal.Product.Add(prodDO);
            }
            else
                throw new ErrorDetailsException();
        }

        void BlApi.IProduct.Delete(int id)
        {
            try
            {
                IEnumerable<DO.OrderItem> orders = Dal.OrderItem.GetAll();
                foreach (DO.OrderItem order in orders)
                {
                    if (order.ProductID == id)
                        throw new AvailableException();
                }
                Dal.Product.Delete(id);
            }
            catch (DoesntExistException ex)//...say it to the user...
            {
                Console.WriteLine(ex);
            }
        }

        BO.Product? BlApi.IProduct.Get(int ID)
        {
            if (ID > 0)
            {
                DO.Product prodDO = new DO.Product();
                prodDO = Dal.Product.Get(ID);
                BO.Product prod = new BO.Product();
                prod.Name = prodDO.Name;
                prod.ID = prodDO.ID;
                prod.InStock = prodDO.InStock;
                prod.Price = prodDO.Price;
                prod.Furniture = (BO.Furniture)prodDO.Furniture;
                return prod;
            }
            else
                throw new ErrorDetailsException();
        }

        ProductItem? BlApi.IProduct.Get(int id, BO.Cart cart)
        {
            ProductItem pi = new ProductItem();
            DO.Product prodDO = new DO.Product();
            int count = 0;
            if (id > 0)
            {
                prodDO = Dal.Product.Get(id);
                pi.ID=prodDO.ID;
                pi.Name = prodDO.Name;
                pi.Furniture = (BO.Furniture)prodDO.Furniture;
                pi.Price = prodDO.Price;
                if (prodDO.InStock != 0)
                    pi.InStock = true;
                else
                    pi.InStock = false;
                foreach (BO.OrderItem item in cart.Items)
                {
                    if (item.Name == prodDO.Name)
                        count++;
                }
                pi.Amount = count;
                return pi;
            }
            else
                throw new ErrorDetailsException();
        }

        IEnumerable<ProductItem?>? BlApi.IProduct.GetProductCatalog(BO.Cart cart)
        {
            List<ProductItem?> list = new List<ProductItem?>();
            List<DO.Product> products = new List<DO.Product>(); 
            foreach(DO.Product product in Dal.Product.GetAll())
            {
                products.Add(product);
            }
            foreach (DO.Product product in products)
            {
                ProductItem pi = new ProductItem();
                int count = 0;
                pi.Name = product.Name;
                pi.ID = product.ID;
                pi.Price = product.Price;
                pi.Furniture = (BO.Furniture)product.Furniture;
                if (product.InStock != 0)
                    pi.InStock = true;
                else
                    pi.InStock = false;
                foreach (BO.OrderItem item in cart.Items)
                {
                    if (item.Name == product.Name&&item.Price==product.Price)
                        count++;
                }
                pi.Amount = count;

                 list.Add(pi);
            }
            
                return list;
        }

        IEnumerable<ProductForList?>? BlApi.IProduct.GetProductForLists()
        {
            List<ProductForList> productForLists=new List<ProductForList>();
            foreach (DO.Product item in Dal.Product.GetAll())//converting from product to product for list
            {
                    BO.ProductForList productForList = new BO.ProductForList();
                    productForList.ID = item.ID;
                    productForList.Name = item.Name;
                    productForList.Price = item.Price;
                    productForList.Furniture = (BO.Furniture)item.Furniture;
                    productForLists.Add(productForList);


                }
            return productForLists;
        }

        void BlApi.IProduct.Update(BO.Product product)
        {
          
                if (product.ID > 0 && product.Name != "" && product.Price > 0 && product.InStock > 0)
                {
                try
                {
                    DO.Product _product = new DO.Product()
                    {
                        ID = product.ID,
                        Name = product.Name,
                        Price = product.Price,
                        InStock = product.InStock,
                        Furniture = (DO.Furniture)product.Furniture
                    };
                    Dal.Product.Update(_product);
                }
                catch (DoesntExistException ex)
                {
                    Console.WriteLine(ex);
                }
            }
           
            else
                throw new ErrorDetailsException();
        }
    }
}

