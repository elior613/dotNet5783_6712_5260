using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;

namespace BlImplementation
{
    sealed internal class BL:IBL
    {
        public IProduct Product { get; }= new BlImplementation.Product();
        public IOrder Order { get; } = new BlImplementation.Order();
        public ICart Cart { get; } = new BlImplementation.Cart();
    }
}
