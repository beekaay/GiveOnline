using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveOnline.Models
{
    public class ShoppingcartViewModel
    {
        public virtual Cart Cart { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
        public virtual List<Variant> Variants { get; set; }
    }
}