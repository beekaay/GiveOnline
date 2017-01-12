using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveOnline.Models
{
    public class Category : BaseWithTitle
    {
        public virtual List<Product> Products { get; set; }
    }

    public class Carousel : TitleImageModel
    {
        public bool IsActive { get; set; }
    }

    public class Story : BaseWithTitle
    {
        public int EventId { get; set; }
        public virtual Event Events { get; set; }
    }

    public class DonateOnline : ContentImageModel
    {
        public decimal Price { get; set; }
        public DateTime IsActive { get; set; }
    }

    public class Event : ContentImageModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public virtual List<Story> Stories { get; set; }
    }

    public class About : BaseWithTitle
    {
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }

    public class AboutTimeline : BaseWithTitle
    {
        public int Year { get; set; }
    }

    public class Product : BaseWithTitle
    {
        public decimal Price { get; set; }
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<Variant> Variants { get; set; }
    }

    public class Variant : BaseModel
    {
        public int SizeId { get; set; }
        public virtual Size Sizes { get; set; }

        public int ColorId { get; set; }
        public virtual Color Colors { get; set; }

        public int Stock { get; set; }

        public string ImageUrl { get; set; }

        public virtual List<Product> Products { get; set; }

    }

    public class Size : BaseWithTitle
    {

    }

    public class Color : BaseWithTitle
    {

    }

    public class Cart : BaseModel
    {
        public virtual List<CartItem> CartItem { get; set; }

        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }

    public class CartItem : BaseModel
    {
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get { return (this.Quantity * this.Product.Price); } }
    }

    public class MetaDescription : BaseWithTitle
    {

    }

    public class MetaTag : BaseWithTitle
    {

    }

    public class Contact
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class NewsLetter
    {
        public string Subject { get; set; }
        public string Body { get; set; }

    }

    public class NewsReceiver : BaseModel
    {
        public string Email { get; set; }
    }

    public class MenuBox : BaseWithTitle
    {
        public string ImageUrl { get; set; }
        public string Headline { get; set; }
        public string Color { get; set; }
    }
}
