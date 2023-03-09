using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class CartItem
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
