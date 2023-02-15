using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi
{
    public interface IProduct
    {
        /// <summary>
        /// Return the list of the product
        /// </summary>
        /// <returns></returns>
        /// 
        IEnumerable<ProductForList?>? GetProductForLists();

        /// <summary>
        /// return the list of catalog of the products
        /// </summary>
        /// <returns></returns>
        /// 
        IEnumerable<ProductItem?>? GetProductCatalog(BO.Cart cart);

        /// <summary>
        /// Return a specific product depending of the ID only for the admins
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        Product Get(int ID);

        /// <summary>
        /// Customers screen 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cart"></param>
        /// <returns></returns>
        /// 
        ProductItem Get(int id,Cart cart);

        /// <summary>
        /// Only admin screen :adding product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public void Add(Product product);

        /// <summary>
        /// Only for admin : Deleting a product
        /// </summary>
        /// <param name="id"></param>
        ///
        public void Delete(int id);

        /// <summary>
        /// Only for admin: Updating product
        /// </summary>
        /// <param name="product"></param>
         public void Update(BO.Product product);
    }
}
