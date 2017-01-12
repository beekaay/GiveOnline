using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveOnline.Models
{
    public class MetaViewModels
    {
        public MetaDescription MetaDescription { get; set; }
        public MetaTag MetaTag { get; set; }
    }

    public class StoryEventViewModels
    {
        public List<Story> Stories { get; set; }
        public List<Event> Events { get; set; }
    }

    public class StoryViewModels
    {
        public Story Story { get; set; }
        public List<Event> Events { get; set; }
    }

    public class AdminIndexViewModel
    {
        public List<Product> Products { get; set; }
        public List<Variant> Variants { get; set; }
    }

    public class AdminCreateViewModel
    {
        public List<Product> Products { get; set; }
        public List<Variant> Variants { get; set; }
        public List<Category> Categories { get; set; }
        public List<Color> Color { get; set; }
        public List<Size> Size { get; set; }
    }

    public class AdminEditViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<Color> Color { get; set; }
        public List<Size> Size { get; set; }
    }

    public class VariantModel
    {
        public List<Size> Sizes { get; set; }
        public List<Color> Colores { get; set; }
    }



}