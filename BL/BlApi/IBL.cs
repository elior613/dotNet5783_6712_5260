using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    /// <summary>
    /// interface IBL
    /// </summary>
     public interface IBL
    {
        /// <summary>
        /// Product interface
        /// </summary>
        public IProduct Product { get;}


        /// <summary>
        /// Order Interface
        /// </summary>
        public IOrder Order { get;}

        /// <summary>
        /// Cart inteface
        /// </summary>
        public ICart Cart { get;}

        
    }
}
