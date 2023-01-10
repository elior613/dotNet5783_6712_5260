using BlApi;
using BO;
using Dal;
using DalApi;

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
            return prod;
        }

        ProductItem? BlApi.IProduct.Get(int id, BO.Cart cart)
        {
            
        }

        IEnumerable<ProductItem?>? BlApi.IProduct.GetProductCatalog()
        {
            throw new NotImplementedException();
        }

        IEnumerable<ProductForList?>? BlApi.IProduct.GetProductForLists(Func<DO.Product?, bool>? filter)
        {
            
        }

        void BlApi.IProduct.Update(BlApi.IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}