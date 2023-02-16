using BlApi;
using BO;
using DalApi;
using DO;
using System.Collections.Generic;
using static BO.Exceptions;

namespace BlImplementation
{
    internal class Product : BlApi.IProduct
    {
        DalApi.IDal? dal = DalApi.Factory.Get();
        void BlApi.IProduct.Add(BO.Product product)
        {
            if (product.ID > 0)
            {
                DO.Product prodDO = new DO.Product();
                prodDO.Name = product.Name;
                prodDO.ID = product.ID;
                prodDO.InStock = product.InStock;
                prodDO.Price = product.Price;
                dal.Product.Add(prodDO);
            }
            else
                throw new ErrorDetailsException();
        }

        void BlApi.IProduct.Delete(int id)
        {
            try
            {
                IEnumerable<DO.OrderItem?> orders = dal.OrderItem.GetAll(null);
                foreach (DO.OrderItem order in orders)
                {
                    if (order.ProductID == id)
                        throw new AvailableException();
                }
                dal.Product.Delete(id);
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
                DO.Product? prodDO = new DO.Product();
                prodDO = dal.Product.Get(ID);
                BO.Product prod = new BO.Product();
                prod.Name = prodDO?.Name;
                prod.ID = (int)prodDO?.ID;
                prod.InStock = (int)prodDO?.InStock;
                prod.Price = (double)prodDO?.Price;
                prod.Furniture = (BO.Furniture)prodDO?.Furniture;
                return prod;
            }
            else
                throw new ErrorDetailsException();
        }

        ProductItem BlApi.IProduct.Get(int id, BO.Cart cart)
        {
            ProductItem pi = new ProductItem();
            DO.Product prodDO = new DO.Product();
            int count = 0;
            if (id > 0)
            {
                prodDO = dal.Product.Get(id);
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

        IEnumerable<ProductItem?> BlApi.IProduct.GetProductCatalog(BO.Cart cart)
        {
            List<ProductItem?> list = new List<ProductItem?>();
            List<DO.Product> products = new List<DO.Product>(); 
            foreach(DO.Product product in dal.Product.GetAll(null))
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

        IEnumerable<ProductForList?> BlApi.IProduct.GetProductForLists()
        {
            List<ProductForList> productForLists=new List<ProductForList>();
            foreach (DO.Product item in dal.Product.GetAll())//converting from product to product for list
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
          
                if (product.ID > 0 && product.Name != "" && product.Price > 0 && product.InStock >= 0)
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
                    dal.Product.Update(_product);
                }
                catch (DoesntExistException ex)
                {
                    Console.WriteLine(ex);
                }
            }
           
            else
                throw new ErrorDetailsException();
        }
        public IEnumerable<BO.ProductForList?> GetSomeProduct(BO.Furniture? category) // function useful for stage 3 in ComboBox
        {
            return from product in dal.Product.GetAll() // stage 5 
                   where product?.Furniture== (DO.Furniture?)category
                   select new BO.ProductForList
                   {
                       ID = product?.ID ?? throw new NullReferenceException("Missing ID"),
                       Name = product?.Name + ' ' ?? throw new NullReferenceException("Missing Name"),
                       Furniture = (BO.Furniture?)product?.Furniture ?? throw new NullReferenceException("Missing product category"),
                       Price = product?.Price ?? 0d
                   };
        }
    }
}

