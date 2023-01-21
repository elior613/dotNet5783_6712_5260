﻿using BlApi;
using Dal;
using DalApi;
using System.Xml.Linq;

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
                    UpdatingSum(cart);

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
                doProduct = Dal.Product.Get(item.ID);
                product.Furniture = (BO.Furniture)doProduct.Furniture;
                product.Name = doProduct.Name;
                product.Price=doProduct.Price;
                product.ID = doProduct.ID;
                product.InStock=doProduct.InStock;

                if (product.InStock < item.Amount)
                    throw new BO.Exceptions.NotEnoughInStock();
                if (name == "") 
                    throw new BO.Exceptions.DoesnotExistException("Don't know the name of the customer ");
                if (adress == "") 
                    throw new BO.Exceptions.DoesnotExistException("Adress don't known");
                System.Net.Mail.MailAddress
                if (!IsValidEmail(email)) // verify the email 
                    throw new BO.EmailNotValid("the email isn't valid check this out");


            }
            throw new NotImplementedException();
        }

        public bool MailCheck(string email)
        {
            var mail = new System.Net.Mail.MailAddress(email);

            return mail.Address==email;
        }

        public void Update(BO.Cart cart, int productId, int newQuantity=1)
        {
            BO.OrderItem? orderItem = cart.Items?.FirstOrDefault(item => item.ProductID == productId);

            if (orderItem?.Amount < newQuantity && newQuantity > 0) 
                for (int i = newQuantity-orderItem.Amount; i > 0; i--)
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
            
        }
        public void UpdatingSum(BO.Cart cart)
        {
            cart.TotalPrice = cart.Items?.Sum(amount => amount.Price * amount.Amount) ?? 0;

        }
    }
}
