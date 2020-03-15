namespace ECommerce.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ECommerceConnection")
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Deleted_Product> Deleted_Product { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<DiscountCity> DiscountCities { get; set; }
        public virtual DbSet<DiscountCode> DiscountCodes { get; set; }
        public virtual DbSet<EWallet> EWallets { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Ship> Ships { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .Property(e => e.admin_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.admin_fname)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.admin_lname)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.admin_phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.admin_city)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.admin_password)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Administrator)
                .HasForeignKey(e => e.product_adder);

            modelBuilder.Entity<Bill>()
                .Property(e => e.bill_customer_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.bill_address)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.bill_payment_method)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.bill_credit_card_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.bill_ewallet_name)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.brand_name)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.brand_slogan)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.brand_country)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Brand)
                .HasForeignKey(e => e.product_brand);

            modelBuilder.Entity<Category>()
                .Property(e => e.category_name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.category_description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Category1)
                .WithOptional(e => e.Category2)
                .HasForeignKey(e => e.category_parentid);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.product_categoryid);

            modelBuilder.Entity<CreditCard>()
                .Property(e => e.credit_card_customer_mail)
                .IsUnicode(false);

            modelBuilder.Entity<CreditCard>()
                .Property(e => e.credit_card_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CreditCard>()
                .Property(e => e.credit_card_bank)
                .IsUnicode(false);

            modelBuilder.Entity<CreditCard>()
                .HasMany(e => e.Bills)
                .WithOptional(e => e.CreditCard)
                .HasForeignKey(e => e.bill_credit_card_id);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_fname)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_lname)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_pid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_city)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_postal_code)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.bill_customer_mail);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CreditCards)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.credit_card_customer_mail);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Discounts)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.discount_customer_mail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.EWallets)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.ewallet_customer_mail);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.order_customer_mail);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.review_customer_mail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deleted_Product>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<Deleted_Product>()
                .Property(e => e.product_brand)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.discount_customer_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.discount_discount_codename)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountCity>()
                .Property(e => e.discount_city_name)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountCity>()
                .Property(e => e.discount_city_codename)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountCode>()
                .Property(e => e.discount_code_codename)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountCode>()
                .Property(e => e.discount_code_amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DiscountCode>()
                .Property(e => e.discount_code_max_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DiscountCode>()
                .HasMany(e => e.Discounts)
                .WithRequired(e => e.DiscountCode)
                .HasForeignKey(e => e.discount_discount_codename);

            modelBuilder.Entity<DiscountCode>()
                .HasMany(e => e.DiscountCities)
                .WithRequired(e => e.DiscountCode)
                .HasForeignKey(e => e.discount_city_codename);

            modelBuilder.Entity<EWallet>()
                .Property(e => e.ewallet_customer_mail)
                .IsUnicode(false);

            modelBuilder.Entity<EWallet>()
                .Property(e => e.ewallet_name)
                .IsUnicode(false);

            modelBuilder.Entity<EWallet>()
                .Property(e => e.ewallet_linked_phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EWallet>()
                .HasMany(e => e.Bills)
                .WithOptional(e => e.EWallet)
                .HasForeignKey(e => new { e.bill_customer_mail, e.bill_ewallet_name });

            modelBuilder.Entity<Order>()
                .Property(e => e.order_customer_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.order_shipvia)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.bill_order_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Discounts)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.discount_order_id);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.detail_order_id);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Ships)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.ship_order_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_brand)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_adder)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.detail_product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.review_product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Suppliers)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("Supply").MapLeftKey("supply_product_id").MapRightKey("supply_supplier_mail"));

            modelBuilder.Entity<Review>()
                .Property(e => e.review_comment)
                .IsUnicode(false);

            modelBuilder.Entity<Review>()
                .Property(e => e.review_customer_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Ship>()
                .Property(e => e.ship_shipper_pid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.shipper_pid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.shipper_fname)
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.shipper_lname)
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.shipper_phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.shipper_address)
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.shipper_license)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .HasMany(e => e.Ships)
                .WithRequired(e => e.Shipper)
                .HasForeignKey(e => e.ship_shipper_pid);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supplier_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supplier_fname)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supllier_lname)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supplier_pid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supplier_phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supplier_city)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supplier_address)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supplier_company)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supplier_BRC)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
