using BlApi;
using Dal;
using DalApi;

namespace BlImplementation
{
    internal class Cart:ICart
    {
        private IDal Dal = new DalList();

        public BO.Cart? Add(BO.Cart cart, int productId)
        {
            BO.Product? product;
            BO.OrderItem? orderItem;
            orderItem= cart.Items?.FirstOrDefault(item => item.ProductID == productId);

            if (orderItem == null) 
            {
                //product = Dal.Product.GetOne(item => item?.ID == productID)?.ConvertProduct_DO_to_BO() ?? throw new BO.NotValidAddToCartException($"Impossible to add this product because the product with id {productID} doesn't exist ");
                DO.Product? doProd = Dal.Product.Get(productId);
                if (doProd == null)
                    throw new BO.Exceptions.DoesnotExistException($"Impossible to add this product because the product with id {productId} doesn't exist ");
                else
                {
                    product=new BO.Product();
                    product.ID=doProd.Value.ID;
                    product.Name=doProd.Value.Name;
                    product.Price=doProd.Value.Price;
                    product.Furniture = (BO.Furniture)doProd.Value.Furniture;
                    if (product.InStock<=0)
                    {
                        throw new BO.Exceptions.NotEnoughInStock($"Cannot add this {product.Name} in the cart: out of stock");
                    }
                    
                    

                    List<BO.OrderItem> myOrderItems = cart.Items?.ToList() ?? new List<BO.OrderItem>();
                    myOrderItems.Add(orderItem);
                    cart.Items = myOrderItems;
                    Update(cart);

                }
            }
            else
            {
                DO.Product? doProd = Dal.Product.Get(productId);
                
                if (doProd == null)
                    throw new BO.Exceptions.DoesnotExistException($"Impossible to add this product because the product with id {productId} doesn't exist ");
                product = new BO.Product();
                product.ID = doProd.Value.ID;
                product.Name = doProd.Value.Name;
                product.Price = doProd.Value.Price;
                product.Furniture = (BO.Furniture)doProd.Value.Furniture;
                if (product.InStock <= 0)
                {
                    throw new BO.Exceptions.NotEnoughInStock($"Cannot add this {product.Name} in the cart: out of stock");
                }

                orderItem.Amount++;
                orderItem.TotalPrice+=product.Price;
                Update(cart);

            }
            return cart;
        }

        public void Confirmation(BO.Cart cart)
        {
            throw new NotImplementedException();
        }

        public void Update(BO.Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
