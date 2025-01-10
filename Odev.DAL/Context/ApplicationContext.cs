using Odev.DAL.Mappings;
using Odev.DAL.Models;
using System.Data.Entity;

namespace Odev.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Server=localhost; Database=OdevDb; Integrated Security=True;")
        { }

        public DbSet<GeneralPage> GeneralPages { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<Identity> Identities { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<SiteSetting> SiteSettings { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<SubscribeMember> SubscribeMembers { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<County> County { get; set; }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<District> District { get; set; }

        public DbSet<MailSetting> MailSetting { get; set; }

        public DbSet<PostalCode> PostalCode { get; set; }

        public DbSet<Street> Street { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<UserType> UserType { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<SolutionPartners> SolutionPartners { get; set; }

        public DbSet<Blog> Blog { get; set; }

        public DbSet<BlogComment> BlogComment { get; set; }

        public DbSet<Setting> Setting { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Color> Color { get; set; }

        public DbSet<Cargo> Cargo { get; set; }

        public DbSet<CustomerNewsletter> CustomerNewsletter { get; set; }

        public DbSet<CustomerWishList> CustomerWishList { get; set; }

        public DbSet<BlogGallery> BlogGallery { get; set; }

        public DbSet<CustomerAddress> CustomerAddress { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }

        public DbSet<Attribute> Attributes { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                   .HasOptional(c => c.TopCategory)
                   .WithMany()
                   .HasForeignKey(c => c.TopCategoryId);

            modelBuilder.Entity<Blog>()
                   .HasOptional(c => c.CategoryInfo)
                   .WithMany()
                   .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Product>()
            .HasRequired(p => p.CategoryInfo) // Product.CategoryInfo is required
            .WithMany(c => c.Products) // CategoryInfo.Products is a collection of Products
            .HasForeignKey(p => p.CategoryId); // Foreign key is CategoryInfoId

            modelBuilder.Entity<Product>()
            .HasMany(p => p.ProductAttributes)
            .WithRequired(pa => pa.Product)
            .HasForeignKey(pa => pa.ProductId);

            modelBuilder.Entity<Attribute>()
            .HasMany(a => a.ProductAttributes)
            .WithRequired(pa => pa.Attribute)
            .HasForeignKey(pa => pa.AttributeId);

            modelBuilder.Entity<Product>()
            .HasMany(p => p.ProductImages)
            .WithRequired(pi => pi.Product)
            .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<CustomerAddress>()
            .HasRequired(ca => ca.Country)
            .WithMany(c => c.CustomerAddresses)
            .HasForeignKey(ca => ca.CountryId)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerAddress>()
            .HasRequired(ca => ca.County)
            .WithMany(c => c.CustomerAddresses)
            .HasForeignKey(ca => ca.CountyId)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerAddress>()
            .HasRequired(ca => ca.District)
            .WithMany(c => c.CustomerAddresses)
            .HasForeignKey(ca => ca.DistrictId)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerAddress>()
            .HasRequired(ca => ca.City)
            .WithMany(c => c.CustomerAddresses)
            .HasForeignKey(ca => ca.CityId)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>().HasRequired(t => t.BillingAddress).WithMany().HasForeignKey(d => d.OrderBillingAddressId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>().HasRequired(t => t.ShippingAddress).WithMany().HasForeignKey(d => d.OrderShippingAddressId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>().HasRequired(t => t.Customer).WithMany(t => t.CustomerOrders).HasForeignKey(d => d.OrderCustomerId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>().HasRequired(t => t.Cargo).WithMany().HasForeignKey(d => d.OrderCargoId).WillCascadeOnDelete(false);



            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new BlogCommentMap());
            modelBuilder.Configurations.Add(new BlogMap());
            modelBuilder.Configurations.Add(new CargoMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new ColorMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new CountyMap());
            modelBuilder.Configurations.Add(new SiteSettingMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
