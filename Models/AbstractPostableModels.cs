using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveOnline.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime LastEdited { get; set; }

        public BaseModel()
        {
            CreateDate = DateTime.Now;
            LastEdited = DateTime.Now;
        }
    }
    public abstract class BaseWithTitle : BaseModel
    {
        public string Title { get; set; }
    }

    public abstract class UserOwnedModel : BaseWithTitle
    {
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }

    public abstract class ContentModel : UserOwnedModel
    {
        public string Content { get; set; }
    }

    public abstract class ContentImageModel : BaseWithTitle
    {
        public string ImageUrl { get; set; }
        public string Content { get; set; }
    }

    public abstract class TitleImageModel : BaseWithTitle
    {
        public string ImageUrl { get; set; }
    }


}