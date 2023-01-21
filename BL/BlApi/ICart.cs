using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    /// <summary>
    /// Adding a new product in cart (for catalog screen, product details screen)
    /// </summary>
    /// <param name="Cart"></param>
    /// <param name="ProductID"></param>
    /// <returns></returns>
    public interface ICart
    {
        public Cart? Add(Cart cart, int ProductId);

        /// <summary>
        /// Updating the quantity of a product in the cart
        /// </summary>
        /// <param name="cart"></param>
        public void Update(BO.Cart cart, int productI,int newQuantity=1);
        public void UpdatingSum(BO.Cart cart);
        public bool MailCheck(string email);

        ///<summary>
        ///Confirmation of placing order in the cart
        ///</summary>
        ///<param name="Cart"></param>
        ///
        public void Confirmation(Cart cart, string name, string email, string adress);


    }
}
