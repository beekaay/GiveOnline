using GiveOnline.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiveOnline.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        #region Category

        public ActionResult Category_Index()
        {
            return View(db.Categories.ToList());
        }

        [HttpPost]
        public ActionResult Category_Create(string title)
        {
            Category NewCategory = new Category
            {
                Title = title
            };

            db.Categories.Add(NewCategory);
            db.SaveChanges();

            return RedirectToAction("Category_Index");
        }

        public ActionResult Category_Create()
        {
            return View(db.Categories.ToList());
        }


        [HttpPost]
        public ActionResult Category_Edit(int Id, string title)
        {
            Category CategoryModel = db.Categories.Find(Id);

            if (CategoryModel != null)
            {
                CategoryModel.Title = title;
            }

            db.SaveChanges();

            return RedirectToAction("Category_Index");
        }

        public ActionResult Category_Edit(int? Id)
        {
            if (Id.HasValue)
            {
                Category CategoryModel = db.Categories.Find(Id.Value);

                if (CategoryModel != null)
                {
                    return View(CategoryModel);
                }
            }

            return RedirectToAction("Category_Index");
        }

        public ActionResult Category_Delete(int? Id)
        {
            if (Id.HasValue)
            {
                Category CategoryModel = db.Categories.Find(Id.Value);

                if (CategoryModel != null)
                {
                    db.Categories.Remove(CategoryModel);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Category_Index");
        }

        #endregion

        #region SEO

        public ActionResult SEO_Index()
        {
            MetaViewModels vm = new MetaViewModels
            {
                MetaTag = db.MetaTags.FirstOrDefault(),
                MetaDescription = db.MetaDescriptions.FirstOrDefault()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult SEO_Edit(int Id, string title)
        {
            MetaDescription MetaDescriptionsModel = db.MetaDescriptions.Find(Id);

            if (MetaDescriptionsModel != null)
            {
                MetaDescriptionsModel.Title = title;
            }

            db.SaveChanges();

            return RedirectToAction("SEO_Index");
        }

        [HttpPost]
        public ActionResult SEOTags_Edit(string tags)
        {
            MetaTag MetaTagsModel = db.MetaTags.FirstOrDefault();
            {
                MetaTagsModel.Title = tags;
            }

            db.SaveChanges();

            return RedirectToAction("SEO_Index");

        }
        #endregion

        #region Carousel

        public ActionResult Carousel_Index()
        {
            return View(db.Carousels.ToList());
        }

        [HttpPost]
        public ActionResult Carousel_Create(string title, HttpPostedFileBase imageURL)
        {
            try
            {
                if (imageURL != null && imageURL.ContentLength > 0)
                {
                    var filename = Path.GetFileName(imageURL.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/Images"), filename);
                    imageURL.SaveAs(path);

                    Carousel NewCarousel = new Carousel
                    {
                        Title = title,
                        ImageUrl = "/Content/Images/" + filename
                    };

                    db.Carousels.Add(NewCarousel);
                    db.SaveChanges();

                    return RedirectToAction("Carousel_Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Carousel_Create()
        {
            return View(db.Carousels.ToList());
        }


        [HttpPost]
        public ActionResult Carousel_Edit(int Id, string title, HttpPostedFileBase imageURL)
        {
            Carousel CarouselModel = db.Carousels.Find(Id);

            try
            {
                if (imageURL != null && imageURL.ContentLength > 0)
                {
                    var filename = Path.GetFileName(imageURL.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/Images"), filename);
                    imageURL.SaveAs(path);

                    if (CarouselModel != null)
                    {
                        CarouselModel.Title = title;
                        CarouselModel.ImageUrl = "/Content/Images/" + filename;
                    }

                    db.SaveChanges();

                    return RedirectToAction("Carousel_Index");
                }
                else
                {
                    if (CarouselModel != null)
                    {
                        CarouselModel.Title = title;
                    }

                    db.SaveChanges();

                    return RedirectToAction("Carousel_Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Carousel_Edit(int? Id)
        {
            if (Id.HasValue)
            {
                Carousel CarouselModel = db.Carousels.Find(Id.Value);

                if (CarouselModel != null)
                {
                    return View(CarouselModel);
                }
            }

            return RedirectToAction("Carousel_Index");
        }

        public ActionResult Carousel_Delete(int? Id)
        {
            if (Id.HasValue)
            {
                Carousel CarouselModel = db.Carousels.Find(Id.Value);

                if (CarouselModel != null)
                {
                    db.Carousels.Remove(CarouselModel);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Carousel_Index");
        }

        #endregion

        #region Event

        public ActionResult Event_Index()
        {
            return View(db.Events.ToList());
        }

        [HttpPost]
        public ActionResult Event_Create(string title, string content, HttpPostedFileBase imageURL, DateTime date)
        {
            try
            {
                if (imageURL != null && imageURL.ContentLength > 0)
                {
                    var filename = Path.GetFileName(imageURL.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/Images"), filename);
                    imageURL.SaveAs(path);

                    Event newEvent = new Event
                    {
                        Title = title,
                        Content = content,
                        ImageUrl = "/Content/Images/" + filename,
                        StartDate = date
                        
                    };

                    db.Events.Add(newEvent);
                    db.SaveChanges();

                    return RedirectToAction("Event_Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
      
        }

        public ActionResult Event_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Event_Edit(int Id, string title, string content, HttpPostedFileBase imageURL, DateTime date)
        {

            try
            {
                if (imageURL != null && imageURL.ContentLength > 0)
                {
                    var filename = Path.GetFileName(imageURL.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/Images"), filename);
                    imageURL.SaveAs(path);

                    Event EventModel = db.Events.Find(Id);

                    if (EventModel != null)
                    {
                        EventModel.Title = title;
                        EventModel.Content = content;
                        EventModel.ImageUrl = "/Content/Images/" + filename;
                        EventModel.StartDate = date;
                    }

                    db.SaveChanges();

                    return RedirectToAction("Event_Edit");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public ActionResult Event_Edit(int? Id)
        {
            if (Id.HasValue)
            {
                Event EventModel = db.Events.Find(Id.Value);

                if (EventModel != null)
                {
                    return View(EventModel);
                }
            }

            return RedirectToAction("Event_Index");
        }

        public ActionResult Event_Delete(int? Id)
        {
            if (Id.HasValue)
            {
                Event EventModel = db.Events.Find(Id.Value);

                if (EventModel != null)
                {
                    db.Events.Remove(EventModel);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Event_Index");
        }
        #endregion

        #region Story

        public ActionResult Story_Collection()
        {
            StoryEventViewModels vm = new StoryEventViewModels()
            {
                Events = db.Events.ToList(),
                Stories = db.Stories.ToList()
            };

            return View(vm);       
        }

        public ActionResult Story_Index()
        {
            StoryEventViewModels vm = new StoryEventViewModels()
            {
                Events = db.Events.ToList(),
                Stories = db.Stories.ToList()
            };

            return View(vm);
        }

        public ActionResult Story_Create()
        {

            return View(db.Events.ToList());
        }

        [HttpPost]
        public ActionResult Story_Create(string title, int eventId)
        {
            Story NewStory = new Story
            {
                Title = title,
                EventId = eventId
            };

            db.Stories.Add(NewStory);
            db.SaveChanges();

            return RedirectToAction("Story_Index");
        }    

        public ActionResult Story_Edit(int? Id)
        {

            if (Id.HasValue)
            {
                Story StoryModel = db.Stories.Find(Id.Value);

                if (StoryModel != null)
                {
                    StoryViewModels vm = new StoryViewModels()
                    {
                        Events = db.Events.ToList(),
                        Story = db.Stories.FirstOrDefault()
                    };

                    return View(vm);
                }
            }

            return RedirectToAction("Story_Index");
        }

        [HttpPost]
        public ActionResult Story_Edit(int Id, string title, int eventId)
        {
            Story StoryModel = db.Stories.Find(Id);

            if (StoryModel != null)
            {
                StoryModel.Title = title;
                StoryModel.EventId = eventId;
            }

            db.SaveChanges();

            return RedirectToAction("Story_Index");
        }

        public ActionResult Story_Delete(int? Id)
        {
            if (Id.HasValue)
            {
                Story StoryModel = db.Stories.Find(Id.Value);

                if (StoryModel != null)
                {
                    db.Stories.Remove(StoryModel);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Story_Index");
        }

        #endregion

        #region DonateOnline

        public ActionResult DonateOnline_Index()
        {
            return View(db.DonateOnlines.ToList());
        }

        [HttpPost]
        public ActionResult DonateOnline_Create(string title, string content, HttpPostedFileBase imageURL, decimal price, DateTime isActive)
        {
            try
            {
                if (imageURL != null && imageURL.ContentLength > 0)
                {
                    var filename = Path.GetFileName(imageURL.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/Images"), filename);
                    imageURL.SaveAs(path);

                    DonateOnline newDonateOnline = new DonateOnline
                    {
                        Title = title,
                        Content = content,
                        ImageUrl = "/Content/Images/" + filename,
                        Price = price,
                        IsActive = isActive

                    };

                    db.DonateOnlines.Add(newDonateOnline);
                    db.SaveChanges();

                    return RedirectToAction("DonateOnline_Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult DonateOnline_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DonateOnline_Edit(int Id, string title, string content, HttpPostedFileBase imageURL, decimal price, DateTime isActive)
        {
            try
            {
                if (imageURL != null && imageURL.ContentLength > 0)
                {
                    var filename = Path.GetFileName(imageURL.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/Images"), filename);
                    imageURL.SaveAs(path);

                    DonateOnline DonateOnlineModel = db.DonateOnlines.Find(Id);

                    if (DonateOnlineModel != null)
                    {
                        DonateOnlineModel.Title = title;
                        DonateOnlineModel.Content = content;
                        DonateOnlineModel.ImageUrl = "/Content/Images/" + filename;
                        DonateOnlineModel.Price = price;
                        DonateOnlineModel.IsActive = isActive;

                    }

                    db.SaveChanges();

                    return RedirectToAction("DonateOnline_Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public ActionResult DonateOnline_Edit(int? Id)
        {
            if (Id.HasValue)
            {
                DonateOnline DonateOnlineModel = db.DonateOnlines.Find(Id.Value);

                if (DonateOnlineModel != null)
                {
                    return View(DonateOnlineModel);
                }
            }

            return RedirectToAction("DonateOnline_Index");
        }

        public ActionResult DonateOnline_Delete(int? Id)
        {
            if (Id.HasValue)
            {
                DonateOnline DonateOnlineModel = db.DonateOnlines.Find(Id.Value);

                if (DonateOnlineModel != null)
                {
                    db.DonateOnlines.Remove(DonateOnlineModel);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("DonateOnline_Index");
        }
        #endregion

        #region About

        public ActionResult About_Index()
        {
            return View(db.Abouts.ToList());
        }

        [HttpPost]
        public ActionResult About_Create(string title, string content)
        {
            About newAbout = new About
            {
                Title = title,
                Content = content
            };

            db.Abouts.Add(newAbout);
            db.SaveChanges();

            return RedirectToAction("About_Index");

        }

        public ActionResult About_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult About_Edit(int Id, string title, string content)
        {

            About AboutModel = db.Abouts.Find(Id);

            if (AboutModel != null)
            {
                AboutModel.Title = title;
                AboutModel.Content = content;

            }

            db.SaveChanges();

            return RedirectToAction("About_Edit");
        }

        public ActionResult About_Edit(int? Id)
        {
            if (Id.HasValue)
            {
                About AboutModel = db.Abouts.Find(Id.Value);

                if (AboutModel != null)
                {
                    return View(AboutModel);
                }
            }

            return RedirectToAction("About_Index");
        }

        public ActionResult About_Delete(int? Id)
        {
            if (Id.HasValue)
            {
                About AboutModel = db.Abouts.Find(Id.Value);

                if (AboutModel != null)
                {
                    db.Abouts.Remove(AboutModel);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("About_Index");
        }
        #endregion

        #region NewsReceiver

        public ActionResult NewsReceiver_Index()
        {
            return View(db.NewsReceivers.ToList());
        }

        [HttpPost]
        public ActionResult NewsReceiver_Create(string email)
        {
            NewsReceiver newNewsReceiver = new NewsReceiver
            {
                Email = email
            };

            db.NewsReceivers.Add(newNewsReceiver);
            db.SaveChanges();

            return RedirectToAction("NewsReceiver_Index");

        }

        public ActionResult NewsReceiver_Create()
        {
            return View();
        }

        public ActionResult NewsReceiver_Delete(int? Id)
        {
            if (Id.HasValue)
            {
                NewsReceiver NewsReceiverModel = db.NewsReceivers.Find(Id.Value);

                if (NewsReceiverModel != null)
                {
                    db.NewsReceivers.Remove(NewsReceiverModel);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("NewsReceiver_Index");
        }
        #endregion

        #region Product

        public ActionResult Product_Index()
        {
            AdminIndexViewModel vm = new AdminIndexViewModel
            {
                Products = db.Products.ToList(),
                Variants = db.Variants.ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Product_Create(string title, int categoryId, string content, int price, int stock, int colorId, int sizeId, HttpPostedFileBase imageURL)
        {
            try
            {
                if (imageURL != null && imageURL.ContentLength > 0)
                {
                    var filename = Path.GetFileName(imageURL.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/Images"), filename);
                    imageURL.SaveAs(path);

                    Product NewProduct = new Product
                    {
                        Title = title,
                        Content = content,
                        CategoryId = categoryId,
                        Price = price
                    };

                    Variant NewVariant = new Variant
                    {
                        Stock = stock,
                        ColorId = colorId,
                        SizeId = sizeId,
                        ImageUrl = "/Content/Images/" + filename,
                        Products = new List<Product> { NewProduct }
                    };

                    db.Products.Add(NewProduct);
                    db.Variants.Add(NewVariant);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        
        }

        public ActionResult Product_Create()
        {
            AdminCreateViewModel vm = new AdminCreateViewModel
            {
                Products = db.Products.ToList(),
                Variants = db.Variants.ToList(),
                Color = db.Colors.ToList(),
                Size = db.Sizes.ToList(),
                Categories = db.Categories.ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Product_Edit(int Id, string title, int categoryId, string content, int price, List<int> variantId, List<int> stock, List<int> colorId, List<int> sizeId, HttpPostedFileBase imageURL)
        {

          try
            {
                if (imageURL != null && imageURL.ContentLength > 0)
                {
                    var filename = Path.GetFileName(imageURL.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/Images"), filename);
                    imageURL.SaveAs(path);

                    Product ProductModel = db.Products.Find(Id);

                    if (ProductModel != null)
                    {
                        ProductModel.Title = title;
                        ProductModel.CategoryId = categoryId;
                        ProductModel.Content = content;
                        ProductModel.Price = price;
                    }

                    for (int i = 0; i < variantId.Count; i++)
                    {
                        Variant VariantModel = db.Variants.Find(variantId[i]);

                        if (VariantModel != null)
                        {
                            VariantModel.Stock = stock[i];
                            VariantModel.ColorId = colorId[i];
                            VariantModel.SizeId = sizeId[i];
                            VariantModel.ImageUrl = "/Content/Images/" + filename;
                        }
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }


          
        }

        public ActionResult Product_Edit(int? id)
        {
            AdminEditViewModel vm = new AdminEditViewModel
            {
                Categories = db.Categories.ToList(),
                Color = db.Colors.ToList(),
                Size = db.Sizes.ToList(),
                Product = db.Products.Find(id.Value)
            };

            if (id.HasValue)
            {
                Product model = db.Products.Find(id.Value);
                if (model != null)
                {
                    return View(vm);
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult Product_Delete(int? id)
        {
            if (id.HasValue)
            {
                Product model = db.Products.Find(id.Value);

                if (model != null)
                {
                    db.Products.Remove(model);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Size

        [HttpPost]
        public ActionResult Size_Create(string title)
        {
            Size size = new Size();

            if (title.Equals(size.Title))
            {
                return View();
            }
            else
            {
                Size newSize = new Size
                {
                    Title = title
                };

                db.Sizes.Add(newSize);
                db.SaveChanges();

                return RedirectToAction("Variants_Index");
            }

        }

        public ActionResult Size_Create()
        {
            return View();
        }

        public ActionResult Size_Delete(int? Id)
        {
            if (Id.HasValue)
            {
                Size SizeModel = db.Sizes.Find(Id.Value);

                if (SizeModel != null)
                {
                    db.Sizes.Remove(SizeModel);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Variants_Index");
        }
        #endregion

        #region Color

        [HttpPost]
        public ActionResult Color_Create(string title)
        {
            Color newColor = new Color
            {
                Title = title
            };

            db.Colors.Add(newColor);
            db.SaveChanges();

            return RedirectToAction("Variants_Index");

        }

        public ActionResult Color_Create()
        {
            return View();
        }

        public ActionResult Color_Delete(int? Id)
        {
            if (Id.HasValue)
            {
                Color ColorModel = db.Colors.Find(Id.Value);

                if (ColorModel != null)
                {
                    db.Colors.Remove(ColorModel);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Variants_Index");
        }
        #endregion

        #region Variants

        public ActionResult Variants_Index()
        {
            VariantModel vm = new VariantModel()
            {
                Sizes = db.Sizes.ToList(),
                Colores = db.Colors.ToList()
            };

            return View(vm);
        }

        #endregion

        #region MenuBox

        public ActionResult MenuBox_Index()
        {
            return View(db.MenuBoxs.ToList());
        }

        [HttpPost]
        public ActionResult MenuBox_Create(string title, string headline, string color, HttpPostedFileBase imageURL)
        {
            try
            {
                if (imageURL != null && imageURL.ContentLength > 0)
                {
                    var filename = Path.GetFileName(imageURL.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/Images"), filename);
                    imageURL.SaveAs(path);

                    MenuBox newMenuBox = new MenuBox
                    {
                        Title = title,
                        Headline = headline,
                        ImageUrl = "/Content/Images/" + filename,
                        Color = color

                    };

                    db.MenuBoxs.Add(newMenuBox);
                    db.SaveChanges();

                    return RedirectToAction("MenuBox_Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult MenuBox_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MenuBox_Edit(int Id, string title, string headline, string color, HttpPostedFileBase imageURL)
        {

            try
            {
                if (imageURL != null && imageURL.ContentLength > 0)
                {
                    var filename = Path.GetFileName(imageURL.FileName);
                    var path = Path.Combine(Server.MapPath("/Content/Images"), filename);
                    imageURL.SaveAs(path);

                    MenuBox MenuBoxModel = db.MenuBoxs.Find(Id);

                    if (MenuBoxModel != null)
                    {
                        MenuBoxModel.Title = title;
                        MenuBoxModel.Headline = headline;
                        MenuBoxModel.ImageUrl = "/Content/Images/" + filename;
                        MenuBoxModel.Color = color;
                    }

                    db.SaveChanges();

                    return RedirectToAction("MenuBox_Edit");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult MenuBox_Edit(int? Id)
        {
            if (Id.HasValue)
            {
                MenuBox MenuBoxModel = db.MenuBoxs.Find(Id.Value);

                if (MenuBoxModel != null)
                {
                    return View(MenuBoxModel);
                }
            }

            return RedirectToAction("MenuBox_Index");
        }

        public ActionResult MenuBox_Delete(int? Id)
        {
            if (Id.HasValue)
            {
                MenuBox MenuBoxModel = db.MenuBoxs.Find(Id.Value);

                if (MenuBoxModel != null)
                {
                    db.MenuBoxs.Remove(MenuBoxModel);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("MenuBox_Index");
        }
        #endregion
    }
}