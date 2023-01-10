using BlApi;
using BO;
using Dal;
using DalApi;
using System.Collections.Generic;

namespace BlImplementation
{
    internal class Product : BlApi.IProduct
    {
        private IDal Dal = new DalList();

        void BlApi.IProduct.Add(BO.Product product)
        {
            DO.Product prodDO = new DO.Product();
            prodDO.Name = product.Name;
            prodDO.ID=product.ID;
            prodDO.InStock= product.InStock;
            prodDO.Price= product.Price;
            Dal.Product.Add(prodDO);
        }

        void BlApi.IProduct.Delete(int id)
        {
            Dal.Product.Delete(id);
        }

        BO.Product? BlApi.IProduct.Get(int ID)
        {
            DO.Product prodDO = new DO.Product();
            prodDO=Dal.Product.Get(ID);
            BO.Product prod = new BO.Product();
            prod.Name = prodDO.Name;
            prod.ID = prodDO.ID;
            prod.InStock= prodDO.InStock;
            prod.Price= prodDO.Price;
            prod.Furniture = (BO.Furniture)prodDO.Furniture;
            return prod;
        }

        ProductItem? BlApi.IProduct.Get(int id, BO.Cart cart)
        {
            
        }

        IEnumerable<ProductItem?>? BlApi.IProduct.GetProductCatalog()
        {
            List<ProductItem?> list = new List<ProductItem?>();

        }

        IEnumerable<ProductForList?>? BlApi.IProduct.GetProductForLists(Func<DO.Product?, bool>? filter)
        {
            List<ProductForList> productForLists=new List<ProductForList>();
            foreach (DO.Product item in Dal.Product.GetAll())//converting from product to product for list
            {
                if (filter(item))
                {
                    BO.ProductForList productForList = new BO.ProductForList();
                    productForList.ID = item.ID;
                    productForList.Name = item.Name;
                    productForList.Price = item.Price;
                    productForList.Furniture = (BO.Furniture)item.Furniture;
                    productForLists.Add(productForList); 
                }
               
            }


            return productForLists;
        }

        void BlApi.IProduct.Update(BlApi.IProduct product)
        {
            
        }
    }
}