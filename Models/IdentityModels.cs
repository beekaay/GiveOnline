using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace GiveOnline.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Cart> Carts { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<DonateOnline> DonateOnlines { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Variant> Variants { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Carousel> Carousels { get; set; }
        public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<Event> Events { get; set; } 
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<AboutTimeline> Abouttimelines { get; set; }
        public virtual DbSet<NewsReceiver> NewsReceivers { get; set; }
        public virtual DbSet<MenuBox> MenuBoxs { get; set; }


        public virtual DbSet<MetaDescription> MetaDescriptions { get; set; }
        public virtual DbSet<MetaTag> MetaTags { get; set; }



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}