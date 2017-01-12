using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveOnline.Models
{
    public class PostViewModel
    {
        public virtual List<Category> Categories { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Variant> Variants { get; set; }
        public virtual Cart Cart { get; set; }
    }

    public class HomeIndexViewModel
    {
        public virtual List<MenuBox> MenuBoxs { get; set; }
        public virtual List<Carousel> Carousels { get; set; }
        public virtual List<Event> Events { get; set; }
        public virtual List<About> Abouts { get; set; }
    }

    public class EventViewModel
    {
        public virtual List<Event> Events { get; set; }
        public virtual List<Story> Stories { get; set; }
    }

    public class SearchViewModel
    {
        public virtual List<Event> Events { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}