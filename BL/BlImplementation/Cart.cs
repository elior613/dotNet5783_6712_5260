using BlApi;

using DalApi;
using DO;
using System.ComponentModel;
using System.Xml.Linq;

namespace BlImplementation
{
    internal class Cart: ICart
    {
        DalApi.IDal? dal = DalApi.Factory.Get();
        Random rand = new Random();
        public BO.Cart? Add(BO.Cart? cart, int productId)
        {
            BO.Product product;
            BO.OrderItem orderItem;
            orderItem= cart.Items.FirstOrDefault(item => item.ProductID == productId);

            if (orderItem == null)
            {
                //product = Dal.Product.GetOne(item => item?.ID == productID)?.ConvertProduct_DO_to_BO() ?? throw new BO.NotValidAddToCartException($"Impossible to add this product because the product with id {productID} doesn't exist ");
                try
                {
                    DO.Product? doProd = dal.Product.Get(productId);


                    if (doProd == null)
                        throw new BO.Exceptions.DoesnotExistException($"Impossible to add this product because the product with id {productId} doesn't exist ");
                    else
                    {
                        product = new BO.Product();
                        product.ID = doProd.Value.ID;
                        product.Name = doProd.Value.Name;
                        product.Price = doProd.Value.Price;
                        product.Furniture = (BO.Furniture)doProd.Value.Furniture;
                        product.InStock = doProd.Value.InStock;
                        if (product.InStock <= 0)
                        {
                            throw new BO.Exceptions.NotEnoughInStock($"Cannot add this {product.Name} in the cart: out of stock");
                        }


                        orderItem = new BO.OrderItem()
                        {
                            ID = rand.Next(),
                            ProductID = product.ID,
                            Name = product.Name,
                            Price = product.Price,
                            Amount = 1,
                            TotalPrice = product.Price
                        };
                        List<BO.OrderItem> myOrderItems = cart.Items?.ToList() ?? new List<BO.OrderItem>();
                    myOrderItems.Add(orderItem);
                    cart.Items = myOrderItems;
                    UpdatingSum(cart);

                }
            }

                catch (DO.DoesntExistException ex)
                {
                    throw new BO.Exceptions.DoesnotExistException();
                }
            }
            else
            {
                DO.Product? doProd = dal.Product.Get(productId);
                
                if (doProd == null)
                    throw new BO.Exceptions.DoesnotExistException($"Impossible to add this product because the product with id {productId} doesn't exist ");
                product = new BO.Product();
                product.ID = doProd.Value.ID;
                product.Name = doProd.Value.Name;
                product.Price = doProd.Value.Price;
                product.Furniture = (BO.Furniture)doProd.Value.Furniture;
                foreach(DO.Product prod in dal.Product.GetAll())
                {
                    if (prod.ID == product.ID)
                        product.InStock = prod.InStock;
                }
                if (product.InStock <= 0)
                {
                    throw new BO.Exceptions.NotEnoughInStock($"Cannot add this {product.Name} in the cart: out of stock");
                }

                orderItem.Amount++;
                orderItem.TotalPrice+=product.Price;
                UpdatingSum(cart);

            }
            return cart;
        }

        public void Confirmation(BO.Cart cart,string name, string email, string adress)
        {
            DO.Product doProduct;
            BO.Product product;
            foreach (var item in cart.Items??throw new BO.Exceptions.DoesnotExistException("cannot confirm the order") )
            {
                product = new BO.Product();
                doProduct = dal.Product.Get(item.ProductID);
                product.Furniture = (BO.Furniture)doProduct.Furniture;
                product.Name = doProduct.Name;
                product.Price=doProduct.Price;
                product.ID = doProduct.ID;
                product.InStock=doProduct.InStock;

                if (product.InStock < item.Amount)
                    throw new BO.Exceptions.NotEnoughInStock();
                if (name == "") 
                    throw new BO.Exceptions.DoesnotExistException("Missing Name ");
                if (adress == "") 
                    throw new BO.Exceptions.DoesnotExistException("Missing Adress");
                if (MailCheck(email)==false)
                    throw new BO.Exceptions.DoesnotExistException("Email isn't correct");
            }
            
            int totalQuantity = (from item in cart.Items
                                     select item.Amount).Sum();

            if (totalQuantity==0)
                throw new BO.Exceptions.DoesnotExistException("The cart is Empty.");

            DO.Order newOrder = new DO.Order()
            {
                totalAmount = totalQuantity,
                CostumerAddress = adress,
                CostumerEmail = email,
                CostumerName = name,
                OrderDate = DateTime.Now,
                ID = 0,
            };
            int orderId = dal!.Order.Add(newOrder); 
            DO.OrderItem DOoi = new DO.OrderItem();
            foreach (var item in cart.Items) // add to the list of orderItem (data) 
            {
                DOoi.Amount = item.Amount;
                DOoi.ProductID = item.ProductID;
                DOoi.Price=item.Price;
                DOoi.OrderID = 0;
                DOoi.OrderID = orderId;
                item.ID = dal.OrderItem.Add(DOoi);
            }
            cart.CostumerName = name;
            cart.CostumerAddress = adress;
            cart.CostumerEmail = email;


            
                foreach (var item in cart.Items)
                {
                try
                {
                    DO.Product DoProduct = dal.Product.Get(item.ProductID);
                    DoProduct.InStock -= item.Amount;
                    dal.Product.Update(DoProduct);
                }
                catch (Exception)
                {
                    throw new DoesntExistException("This Product doesn't exist");
                }
                }
            }
        
       

        public bool MailCheck(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);

                return mail.Address == email;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public BO.Cart? Update(BO.Cart cart, int productId, int newQuantity=1)
        {
            try
            {
                DO.Product? doProd = dal.Product.Get(productId);
                BO.OrderItem? orderItem = cart.Items?.FirstOrDefault(item => item.ProductID == productId);

                if (orderItem?.Amount < newQuantity && newQuantity > 0)
                    for (int i = newQuantity - orderItem.Amount; i > 0; i--)
                        cart = Add(cart, productId) ?? throw new BO.Exceptions.DoesnotExistException();

                else if (orderItem?.Amount > newQuantity && newQuantity > 0)
                {

                    List<BO.OrderItem> newOI = cart.Items?.ToList() ?? new List<BO.OrderItem>();
                    BO.OrderItem? UpdatingOrder = newOI.Find(item => item.ProductID == productId) ?? throw new BO.Exceptions.DoesnotExistException("This OrderItem doesn't exist in the cart");
                    UpdatingOrder.TotalPrice = (double)UpdatingOrder.Price * newQuantity;
                    UpdatingOrder.Amount = newQuantity;
                    cart.Items = newOI;//switching the old non-update list whith the new Update List
                    UpdatingSum(cart);

                }
                else if (orderItem?.Amount == 0)
                {
                    List<BO.OrderItem> newOI = cart.Items?.ToList() ?? new List<BO.OrderItem>();
                    newOI.Remove(orderItem);
                    cart.Items = newOI;
                    UpdatingSum(cart);
                }
                return cart;
            }
            catch (DO.DoesntExistException ex)
            {
                throw new BO.Exceptions.DoesnotExistException();
            }
        }
        public void UpdatingSum(BO.Cart cart)
        {
            cart.TotalPrice = cart.Items?.Sum(amount => amount.Price * amount.Amount) ?? 0;

        }
        public IEnumerable<BO.OrderItem?> getAllOrderItemInCart(BO.Cart cart)
        {
            List<BO.OrderItem> items = new List<BO.OrderItem>();
            if (cart.Items != null)
            {
                foreach (BO.OrderItem item in cart.Items)
                {
                    items.Add(item);
                }
                return items;
            }
            else
                throw new Exception("the cart is empty");
        }
    }
  
}
