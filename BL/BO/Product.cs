using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BOProduct
    {
        public int ID { get; set; }
        public int InStock { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Furniture Furniture { get; set; }


        //to show all the details of the product
        public override string ToString() => $@"
    Product ID: {ID}, Name: {Name}, Category: {Furniture}
    Price: {Price}, Amount in stock: {InStock}
    ";
    }
}
