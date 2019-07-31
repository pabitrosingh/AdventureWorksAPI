using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdventureWorksAPI.Models
{
    public partial class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext()
        {
        }

        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
            : base(options)
        {
        }

        //for Employee views
        //public virtual DbSet<vEmployee> EmployeeView { get; set; }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<BillOfMaterials> BillOfMaterials { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactCreditCard> ContactCreditCard { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<CountryRegion> CountryRegion { get; set; }
        public virtual DbSet<CountryRegionCurrency> CountryRegionCurrency { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<Culture> Culture { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<CurrencyRate> CurrencyRate { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        public virtual DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
        public virtual DbSet<EmployeePayHistory> EmployeePayHistory { get; set; }
        public virtual DbSet<Illustration> Illustration { get; set; }
        public virtual DbSet<Individual> Individual { get; set; }
        public virtual DbSet<JobCandidate> JobCandidate { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductCostHistory> ProductCostHistory { get; set; }
        public virtual DbSet<ProductDescription> ProductDescription { get; set; }
        public virtual DbSet<ProductDocument> ProductDocument { get; set; }
        public virtual DbSet<ProductInventory> ProductInventory { get; set; }
        public virtual DbSet<ProductListPriceHistory> ProductListPriceHistory { get; set; }
        public virtual DbSet<ProductModel> ProductModel { get; set; }
        public virtual DbSet<ProductModelIllustration> ProductModelIllustration { get; set; }
        public virtual DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<ProductProductPhoto> ProductProductPhoto { get; set; }
        public virtual DbSet<ProductReview> ProductReview { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategory { get; set; }
        public virtual DbSet<ProductVendor> ProductVendor { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReason { get; set; }
        public virtual DbSet<SalesPerson> SalesPerson { get; set; }
        public virtual DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistory { get; set; }
        public virtual DbSet<SalesReason> SalesReason { get; set; }
        public virtual DbSet<SalesTaxRate> SalesTaxRate { get; set; }
        public virtual DbSet<SalesTerritory> SalesTerritory { get; set; }
        public virtual DbSet<SalesTerritoryHistory> SalesTerritoryHistory { get; set; }
        public virtual DbSet<ScrapReason> ScrapReason { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<ShipMethod> ShipMethod { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public virtual DbSet<SpecialOffer> SpecialOffer { get; set; }
        public virtual DbSet<SpecialOfferProduct> SpecialOfferProduct { get; set; }
        public virtual DbSet<StateProvince> StateProvince { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreContact> StoreContact { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistory { get; set; }
        public virtual DbSet<TransactionHistoryArchive> TransactionHistoryArchive { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasure { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<VendorAddress> VendorAddress { get; set; }
        public virtual DbSet<VendorContact> VendorContact { get; set; }
        public virtual DbSet<WorkOrder> WorkOrder { get; set; }
        public virtual DbSet<WorkOrderRouting> WorkOrderRouting { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=QITBLRQIPL143D\\SQL2012;Database=AdventureWorks;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //for Employee views 
            //modelBuilder.Entity<vEmployee>(entity => {

            //    entity.HasKey(e => e.EmployeeID);
            //    entity.Property(e=>e.EmployeeID);
            //    entity.Property(e => e.Designation);
            //    entity.Property(e => e.Department);
            //    entity.Property(e => e.DepartmentGroup);
            //    entity.Property(e => e.Grade_Band);
            //    entity.Property(e => e.HireDate);
            //    entity.Property(e => e.CurrentShift);
            //    entity.Property(e => e.SL);
            //    entity.Property(e => e.EL);
            //    entity.Property(e => e.BL);
            //    entity.Property(e => e.FirstName);
            //    entity.Property(e => e.MiddleName);
            //    entity.Property(e => e.LastName);
            //    entity.Property(e => e.Gender);
            //    entity.Property(e => e.MaritalStatus);
            //    entity.Property(e => e.BirthDate);
            //    entity.Property(e => e.EmailAddress);
            //    entity.Property(e => e.Phone);
            //    entity.Property(e => e.AddressLine1);
            //    entity.Property(e => e.CountryRegionName);
            //    entity.Property(e => e.StateProvinceName);
            //    entity.Property(e => e.City);
            //    entity.Property(e => e.PostalCode);
            //    entity.Property(e => e.ManagerID);
            //});

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Person");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Address_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.StateProvinceId);

                entity.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.StateProvinceId, e.PostalCode })
                    .IsUnique();

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.AddressLine2).HasMaxLength(60);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.StateProvinceId).HasColumnName("StateProvinceID");

                entity.HasOne(d => d.StateProvince)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StateProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.ToTable("AddressType", "Person");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_AddressType_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_AddressType_rowguid")
                    .IsUnique();

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<BillOfMaterials>(entity =>
            {
                entity.HasKey(e => e.BillOfMaterialsId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("BillOfMaterials", "Production");

                entity.HasIndex(e => e.UnitMeasureCode);

                entity.HasIndex(e => new { e.ProductAssemblyId, e.ComponentId, e.StartDate })
                    .HasName("AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.BillOfMaterialsId).HasColumnName("BillOfMaterialsID");

                entity.Property(e => e.Bomlevel).HasColumnName("BOMLevel");

                entity.Property(e => e.ComponentId).HasColumnName("ComponentID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PerAssemblyQty)
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("((1.00))");

                entity.Property(e => e.ProductAssemblyId).HasColumnName("ProductAssemblyID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UnitMeasureCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.BillOfMaterialsComponent)
                    .HasForeignKey(d => d.ComponentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ProductAssembly)
                    .WithMany(p => p.BillOfMaterialsProductAssembly)
                    .HasForeignKey(d => d.ProductAssemblyId);

                entity.HasOne(d => d.UnitMeasureCodeNavigation)
                    .WithMany(p => p.BillOfMaterials)
                    .HasForeignKey(d => d.UnitMeasureCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact", "Person");

                entity.HasIndex(e => e.AdditionalContactInfo)
                    .HasName("PXML_Contact_AddContact");

                entity.HasIndex(e => e.EmailAddress);

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Contact_rowguid")
                    .IsUnique();

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.AdditionalContactInfo).HasColumnType("xml");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NameStyle).HasColumnType("NameStyle");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnType("Phone")
                    .HasMaxLength(25);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Suffix).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(8);
            });

            modelBuilder.Entity<ContactCreditCard>(entity =>
            {
                entity.HasKey(e => new { e.ContactId, e.CreditCardId });

                entity.ToTable("ContactCreditCard", "Sales");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactCreditCard)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.ContactCreditCard)
                    .HasForeignKey(d => d.CreditCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.ToTable("ContactType", "Person");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ContactType_Name")
                    .IsUnique();

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CountryRegion>(entity =>
            {
                entity.HasKey(e => e.CountryRegionCode);

                entity.ToTable("CountryRegion", "Person");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_CountryRegion_Name")
                    .IsUnique();

                entity.Property(e => e.CountryRegionCode)
                    .HasMaxLength(3)
                    .ValueGeneratedNever();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CountryRegionCurrency>(entity =>
            {
                entity.HasKey(e => new { e.CountryRegionCode, e.CurrencyCode });

                entity.ToTable("CountryRegionCurrency", "Sales");

                entity.HasIndex(e => e.CurrencyCode);

                entity.Property(e => e.CountryRegionCode).HasMaxLength(3);

                entity.Property(e => e.CurrencyCode).HasMaxLength(3);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CountryRegionCodeNavigation)
                    .WithMany(p => p.CountryRegionCurrency)
                    .HasForeignKey(d => d.CountryRegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.CountryRegionCurrency)
                    .HasForeignKey(d => d.CurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.ToTable("CreditCard", "Sales");

                entity.HasIndex(e => e.CardNumber)
                    .HasName("AK_CreditCard_CardNumber")
                    .IsUnique();

                entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Culture>(entity =>
            {
                entity.ToTable("Culture", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Culture_Name")
                    .IsUnique();

                entity.Property(e => e.CultureId)
                    .HasColumnName("CultureID")
                    .HasMaxLength(6)
                    .ValueGeneratedNever();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.CurrencyCode);

                entity.ToTable("Currency", "Sales");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Currency_Name")
                    .IsUnique();

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .ValueGeneratedNever();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CurrencyRate>(entity =>
            {
                entity.ToTable("CurrencyRate", "Sales");

                entity.HasIndex(e => new { e.CurrencyRateDate, e.FromCurrencyCode, e.ToCurrencyCode })
                    .HasName("AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode")
                    .IsUnique();

                entity.Property(e => e.CurrencyRateId).HasColumnName("CurrencyRateID");

                entity.Property(e => e.AverageRate).HasColumnType("money");

                entity.Property(e => e.CurrencyRateDate).HasColumnType("datetime");

                entity.Property(e => e.EndOfDayRate).HasColumnType("money");

                entity.Property(e => e.FromCurrencyCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ToCurrencyCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.FromCurrencyCodeNavigation)
                    .WithMany(p => p.CurrencyRateFromCurrencyCodeNavigation)
                    .HasForeignKey(d => d.FromCurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToCurrencyCodeNavigation)
                    .WithMany(p => p.CurrencyRateToCurrencyCodeNavigation)
                    .HasForeignKey(d => d.ToCurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Sales");

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("AK_Customer_AccountNumber")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Customer_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.TerritoryId);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))");

                entity.Property(e => e.CustomerType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.TerritoryId);
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.AddressId });

                entity.ToTable("CustomerAddress", "Sales");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_CustomerAddress_rowguid")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department", "HumanResources");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Department_Name")
                    .IsUnique();

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document", "Production");

                entity.HasIndex(e => new { e.FileName, e.Revision })
                    .HasName("AK_Document_FileName_Revision")
                    .IsUnique();

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.Document1).HasColumnName("Document");

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Revision)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "HumanResources");

                entity.HasIndex(e => e.LoginId)
                    .HasName("AK_Employee_LoginID")
                    .IsUnique();

                entity.HasIndex(e => e.ManagerId);

                entity.HasIndex(e => e.NationalIdnumber)
                    .HasName("AK_Employee_NationalIDNumber")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Employee_rowguid")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.CurrentFlag)
                    .IsRequired()
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasMaxLength(256);

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NationalIdnumber)
                    .IsRequired()
                    .HasColumnName("NationalIDNumber")
                    .HasMaxLength(15);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SalariedFlag)
                    .IsRequired()
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId);
            });

            modelBuilder.Entity<EmployeeAddress>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.AddressId });

                entity.ToTable("EmployeeAddress", "HumanResources");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_EmployeeAddress_rowguid")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.EmployeeAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeAddress)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<EmployeeDepartmentHistory>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.StartDate, e.DepartmentId, e.ShiftId });

                entity.ToTable("EmployeeDepartmentHistory", "HumanResources");

                entity.HasIndex(e => e.DepartmentId);

                entity.HasIndex(e => e.ShiftId);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeDepartmentHistory)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDepartmentHistory)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EmployeeDepartmentHistory)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<EmployeePayHistory>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.RateChangeDate });

                entity.ToTable("EmployeePayHistory", "HumanResources");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.RateChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rate).HasColumnType("money");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePayHistory)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Illustration>(entity =>
            {
                entity.ToTable("Illustration", "Production");

                entity.Property(e => e.IllustrationId).HasColumnName("IllustrationID");

                entity.Property(e => e.Diagram).HasColumnType("xml");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Individual>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("Individual", "Sales");

                entity.HasIndex(e => e.Demographics)
                    .HasName("XMLVALUE_Individual_Demographics");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Demographics).HasColumnType("xml");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Individual)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.Individual)
                    .HasForeignKey<Individual>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<JobCandidate>(entity =>
            {
                entity.ToTable("JobCandidate", "HumanResources");

                entity.HasIndex(e => e.EmployeeId);

                entity.Property(e => e.JobCandidateId).HasColumnName("JobCandidateID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Resume).HasColumnType("xml");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JobCandidate)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Location_Name")
                    .IsUnique();

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Availability)
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CostRate)
                    .HasColumnType("smallmoney")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Product_Name")
                    .IsUnique();

                entity.HasIndex(e => e.ProductNumber)
                    .HasName("AK_Product_ProductNumber")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Product_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Class).HasMaxLength(2);

                entity.Property(e => e.Color).HasMaxLength(15);

                entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

                entity.Property(e => e.FinishedGoodsFlag)
                    .IsRequired()
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ListPrice).HasColumnType("money");

                entity.Property(e => e.MakeFlag)
                    .IsRequired()
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductLine).HasMaxLength(2);

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ProductSubcategoryId).HasColumnName("ProductSubcategoryID");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SellEndDate).HasColumnType("datetime");

                entity.Property(e => e.SellStartDate).HasColumnType("datetime");

                entity.Property(e => e.Size).HasMaxLength(5);

                entity.Property(e => e.SizeUnitMeasureCode).HasMaxLength(3);

                entity.Property(e => e.StandardCost).HasColumnType("money");

                entity.Property(e => e.Style).HasMaxLength(2);

                entity.Property(e => e.Weight).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.WeightUnitMeasureCode).HasMaxLength(3);

                entity.HasOne(d => d.ProductModel)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductModelId);

                entity.HasOne(d => d.ProductSubcategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductSubcategoryId);

                entity.HasOne(d => d.SizeUnitMeasureCodeNavigation)
                    .WithMany(p => p.ProductSizeUnitMeasureCodeNavigation)
                    .HasForeignKey(d => d.SizeUnitMeasureCode);

                entity.HasOne(d => d.WeightUnitMeasureCodeNavigation)
                    .WithMany(p => p.ProductWeightUnitMeasureCodeNavigation)
                    .HasForeignKey(d => d.WeightUnitMeasureCode);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductCategory_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductCategory_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ProductCostHistory>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.StartDate });

                entity.ToTable("ProductCostHistory", "Production");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StandardCost).HasColumnType("money");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCostHistory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductDescription>(entity =>
            {
                entity.ToTable("ProductDescription", "Production");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductDescription_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ProductDocument>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.DocumentId });

                entity.ToTable("ProductDocument", "Production");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.ProductDocument)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductDocument)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductInventory>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.LocationId });

                entity.ToTable("ProductInventory", "Production");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Shelf)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ProductInventory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInventory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductListPriceHistory>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.StartDate });

                entity.ToTable("ProductListPriceHistory", "Production");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ListPrice).HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductListPriceHistory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.ToTable("ProductModel", "Production");

                entity.HasIndex(e => e.CatalogDescription)
                    .HasName("PXML_ProductModel_CatalogDescription");

                entity.HasIndex(e => e.Instructions)
                    .HasName("PXML_ProductModel_Instructions");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductModel_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductModel_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.CatalogDescription).HasColumnType("xml");

                entity.Property(e => e.Instructions).HasColumnType("xml");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ProductModelIllustration>(entity =>
            {
                entity.HasKey(e => new { e.ProductModelId, e.IllustrationId });

                entity.ToTable("ProductModelIllustration", "Production");

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.IllustrationId).HasColumnName("IllustrationID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Illustration)
                    .WithMany(p => p.ProductModelIllustration)
                    .HasForeignKey(d => d.IllustrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ProductModel)
                    .WithMany(p => p.ProductModelIllustration)
                    .HasForeignKey(d => d.ProductModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductModelProductDescriptionCulture>(entity =>
            {
                entity.HasKey(e => new { e.ProductModelId, e.ProductDescriptionId, e.CultureId });

                entity.ToTable("ProductModelProductDescriptionCulture", "Production");

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");

                entity.Property(e => e.CultureId)
                    .HasColumnName("CultureID")
                    .HasMaxLength(6);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.ProductModelProductDescriptionCulture)
                    .HasForeignKey(d => d.CultureId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ProductDescription)
                    .WithMany(p => p.ProductModelProductDescriptionCulture)
                    .HasForeignKey(d => d.ProductDescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ProductModel)
                    .WithMany(p => p.ProductModelProductDescriptionCulture)
                    .HasForeignKey(d => d.ProductModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductPhoto>(entity =>
            {
                entity.ToTable("ProductPhoto", "Production");

                entity.Property(e => e.ProductPhotoId).HasColumnName("ProductPhotoID");

                entity.Property(e => e.LargePhotoFileName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductProductPhoto>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ProductPhotoId })
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ProductProductPhoto", "Production");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductPhotoId).HasColumnName("ProductPhotoID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Primary).HasColumnType("Flag");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductProductPhoto)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ProductPhoto)
                    .WithMany(p => p.ProductProductPhoto)
                    .HasForeignKey(d => d.ProductPhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.ToTable("ProductReview", "Production");

                entity.HasIndex(e => new { e.Comments, e.ProductId, e.ReviewerName })
                    .HasName("IX_ProductReview_ProductID_Name");

                entity.Property(e => e.ProductReviewId).HasColumnName("ProductReviewID");

                entity.Property(e => e.Comments).HasMaxLength(3850);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReviewDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReviewerName)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductReview)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductSubcategory>(entity =>
            {
                entity.ToTable("ProductSubcategory", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductSubcategory_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductSubcategory_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductSubcategoryId).HasColumnName("ProductSubcategoryID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.ProductSubcategory)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductVendor>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.VendorId });

                entity.ToTable("ProductVendor", "Purchasing");

                entity.HasIndex(e => e.UnitMeasureCode);

                entity.HasIndex(e => e.VendorId);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.Property(e => e.LastReceiptCost).HasColumnType("money");

                entity.Property(e => e.LastReceiptDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StandardPrice).HasColumnType("money");

                entity.Property(e => e.UnitMeasureCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVendor)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.UnitMeasureCodeNavigation)
                    .WithMany(p => p.ProductVendor)
                    .HasForeignKey(d => d.UnitMeasureCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.ProductVendor)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.PurchaseOrderId, e.PurchaseOrderDetailId });

                entity.ToTable("PurchaseOrderDetail", "Purchasing");

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

                entity.Property(e => e.PurchaseOrderDetailId)
                    .HasColumnName("PurchaseOrderDetailID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.LineTotal)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(isnull([OrderQty]*[UnitPrice],(0.00)))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReceivedQty).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.RejectedQty).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.StockedQty)
                    .HasColumnType("decimal(9, 2)")
                    .HasComputedColumnSql("(isnull([ReceivedQty]-[RejectedQty],(0.00)))");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderDetail)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PurchaseOrderHeader>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderId);

                entity.ToTable("PurchaseOrderHeader", "Purchasing");

                entity.HasIndex(e => e.EmployeeId);

                entity.HasIndex(e => e.VendorId);

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.ShipMethodId).HasColumnName("ShipMethodID");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmt)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PurchaseOrderHeader)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ShipMethod)
                    .WithMany(p => p.PurchaseOrderHeader)
                    .HasForeignKey(d => d.ShipMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.PurchaseOrderHeader)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SalesOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId });

                entity.ToTable("SalesOrderDetail", "Sales");

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SalesOrderDetail_rowguid")
                    .IsUnique();

                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");

                entity.Property(e => e.SalesOrderDetailId)
                    .HasColumnName("SalesOrderDetailID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CarrierTrackingNumber).HasMaxLength(25);

                entity.Property(e => e.LineTotal)
                    .HasColumnType("numeric(38, 6)")
                    .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SpecialOfferId).HasColumnName("SpecialOfferID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.UnitPriceDiscount).HasColumnType("money");

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.SalesOrderDetail)
                    .HasForeignKey(d => d.SalesOrderId);

                entity.HasOne(d => d.SpecialOfferProduct)
                    .WithMany(p => p.SalesOrderDetail)
                    .HasForeignKey(d => new { d.SpecialOfferId, d.ProductId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID");
            });

            modelBuilder.Entity<SalesOrderHeader>(entity =>
            {
                entity.HasKey(e => e.SalesOrderId);

                entity.ToTable("SalesOrderHeader", "Sales");

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SalesOrderHeader_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.SalesOrderNumber)
                    .HasName("AK_SalesOrderHeader_SalesOrderNumber")
                    .IsUnique();

                entity.HasIndex(e => e.SalesPersonId);

                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");

                entity.Property(e => e.AccountNumber)
                    .HasColumnType("AccountNumber")
                    .HasMaxLength(15);

                entity.Property(e => e.BillToAddressId).HasColumnName("BillToAddressID");

                entity.Property(e => e.Comment).HasMaxLength(128);

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.CreditCardApprovalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");

                entity.Property(e => e.CurrencyRateId).HasColumnName("CurrencyRateID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OnlineOrderFlag)
                    .IsRequired()
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PurchaseOrderNumber)
                    .HasColumnType("OrderNumber")
                    .HasMaxLength(25);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SalesOrderNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID],0),N'*** ERROR ***'))");

                entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.ShipMethodId).HasColumnName("ShipMethodID");

                entity.Property(e => e.ShipToAddressId).HasColumnName("ShipToAddressID");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmt)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.Property(e => e.TotalDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))");

                entity.HasOne(d => d.BillToAddress)
                    .WithMany(p => p.SalesOrderHeaderBillToAddress)
                    .HasForeignKey(d => d.BillToAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.SalesOrderHeader)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.SalesOrderHeader)
                    .HasForeignKey(d => d.CreditCardId);

                entity.HasOne(d => d.CurrencyRate)
                    .WithMany(p => p.SalesOrderHeader)
                    .HasForeignKey(d => d.CurrencyRateId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SalesOrderHeader)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SalesPerson)
                    .WithMany(p => p.SalesOrderHeader)
                    .HasForeignKey(d => d.SalesPersonId);

                entity.HasOne(d => d.ShipMethod)
                    .WithMany(p => p.SalesOrderHeader)
                    .HasForeignKey(d => d.ShipMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ShipToAddress)
                    .WithMany(p => p.SalesOrderHeaderShipToAddress)
                    .HasForeignKey(d => d.ShipToAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.SalesOrderHeader)
                    .HasForeignKey(d => d.TerritoryId);
            });

            modelBuilder.Entity<SalesOrderHeaderSalesReason>(entity =>
            {
                entity.HasKey(e => new { e.SalesOrderId, e.SalesReasonId });

                entity.ToTable("SalesOrderHeaderSalesReason", "Sales");

                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");

                entity.Property(e => e.SalesReasonId).HasColumnName("SalesReasonID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.SalesOrderHeaderSalesReason)
                    .HasForeignKey(d => d.SalesOrderId);

                entity.HasOne(d => d.SalesReason)
                    .WithMany(p => p.SalesOrderHeaderSalesReason)
                    .HasForeignKey(d => d.SalesReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SalesPerson>(entity =>
            {
                entity.ToTable("SalesPerson", "Sales");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SalesPerson_rowguid")
                    .IsUnique();

                entity.Property(e => e.SalesPersonId)
                    .HasColumnName("SalesPersonID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bonus)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CommissionPct)
                    .HasColumnType("smallmoney")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SalesLastYear)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalesQuota).HasColumnType("money");

                entity.Property(e => e.SalesYtd)
                    .HasColumnName("SalesYTD")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.HasOne(d => d.SalesPersonNavigation)
                    .WithOne(p => p.SalesPerson)
                    .HasForeignKey<SalesPerson>(d => d.SalesPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.SalesPerson)
                    .HasForeignKey(d => d.TerritoryId);
            });

            modelBuilder.Entity<SalesPersonQuotaHistory>(entity =>
            {
                entity.HasKey(e => new { e.SalesPersonId, e.QuotaDate });

                entity.ToTable("SalesPersonQuotaHistory", "Sales");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SalesPersonQuotaHistory_rowguid")
                    .IsUnique();

                entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

                entity.Property(e => e.QuotaDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SalesQuota).HasColumnType("money");

                entity.HasOne(d => d.SalesPerson)
                    .WithMany(p => p.SalesPersonQuotaHistory)
                    .HasForeignKey(d => d.SalesPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SalesReason>(entity =>
            {
                entity.ToTable("SalesReason", "Sales");

                entity.Property(e => e.SalesReasonId).HasColumnName("SalesReasonID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ReasonType)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SalesTaxRate>(entity =>
            {
                entity.ToTable("SalesTaxRate", "Sales");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SalesTaxRate_rowguid")
                    .IsUnique();

                entity.HasIndex(e => new { e.StateProvinceId, e.TaxType })
                    .HasName("AK_SalesTaxRate_StateProvinceID_TaxType")
                    .IsUnique();

                entity.Property(e => e.SalesTaxRateId).HasColumnName("SalesTaxRateID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.StateProvinceId).HasColumnName("StateProvinceID");

                entity.Property(e => e.TaxRate)
                    .HasColumnType("smallmoney")
                    .HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.StateProvince)
                    .WithMany(p => p.SalesTaxRate)
                    .HasForeignKey(d => d.StateProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SalesTerritory>(entity =>
            {
                entity.HasKey(e => e.TerritoryId);

                entity.ToTable("SalesTerritory", "Sales");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_SalesTerritory_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SalesTerritory_rowguid")
                    .IsUnique();

                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.Property(e => e.CostLastYear)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CostYtd)
                    .HasColumnName("CostYTD")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CountryRegionCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SalesLastYear)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalesYtd)
                    .HasColumnName("SalesYTD")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");
            });

            modelBuilder.Entity<SalesTerritoryHistory>(entity =>
            {
                entity.HasKey(e => new { e.SalesPersonId, e.StartDate, e.TerritoryId });

                entity.ToTable("SalesTerritoryHistory", "Sales");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SalesTerritoryHistory_rowguid")
                    .IsUnique();

                entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.SalesPerson)
                    .WithMany(p => p.SalesTerritoryHistory)
                    .HasForeignKey(d => d.SalesPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.SalesTerritoryHistory)
                    .HasForeignKey(d => d.TerritoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ScrapReason>(entity =>
            {
                entity.ToTable("ScrapReason", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ScrapReason_Name")
                    .IsUnique();

                entity.Property(e => e.ScrapReasonId).HasColumnName("ScrapReasonID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift", "HumanResources");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Shift_Name")
                    .IsUnique();

                entity.HasIndex(e => new { e.StartTime, e.EndTime })
                    .HasName("AK_Shift_StartTime_EndTime")
                    .IsUnique();

                entity.Property(e => e.ShiftId)
                    .HasColumnName("ShiftID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ShipMethod>(entity =>
            {
                entity.ToTable("ShipMethod", "Purchasing");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ShipMethod_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ShipMethod_rowguid")
                    .IsUnique();

                entity.Property(e => e.ShipMethodId).HasColumnName("ShipMethodID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ShipBase)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShipRate)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");
            });

            modelBuilder.Entity<ShoppingCartItem>(entity =>
            {
                entity.ToTable("ShoppingCartItem", "Sales");

                entity.HasIndex(e => new { e.ShoppingCartId, e.ProductId });

                entity.Property(e => e.ShoppingCartItemId).HasColumnName("ShoppingCartItemID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.ShoppingCartId)
                    .IsRequired()
                    .HasColumnName("ShoppingCartID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingCartItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SpecialOffer>(entity =>
            {
                entity.ToTable("SpecialOffer", "Sales");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SpecialOffer_rowguid")
                    .IsUnique();

                entity.Property(e => e.SpecialOfferId).HasColumnName("SpecialOfferID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DiscountPct)
                    .HasColumnType("smallmoney")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SpecialOfferProduct>(entity =>
            {
                entity.HasKey(e => new { e.SpecialOfferId, e.ProductId });

                entity.ToTable("SpecialOfferProduct", "Sales");

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SpecialOfferProduct_rowguid")
                    .IsUnique();

                entity.Property(e => e.SpecialOfferId).HasColumnName("SpecialOfferID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SpecialOfferProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SpecialOffer)
                    .WithMany(p => p.SpecialOfferProduct)
                    .HasForeignKey(d => d.SpecialOfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<StateProvince>(entity =>
            {
                entity.ToTable("StateProvince", "Person");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_StateProvince_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_StateProvince_rowguid")
                    .IsUnique();

                entity.HasIndex(e => new { e.StateProvinceCode, e.CountryRegionCode })
                    .HasName("AK_StateProvince_StateProvinceCode_CountryRegionCode")
                    .IsUnique();

                entity.Property(e => e.StateProvinceId).HasColumnName("StateProvinceID");

                entity.Property(e => e.CountryRegionCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.IsOnlyStateProvinceFlag)
                    .IsRequired()
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.StateProvinceCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

                entity.HasOne(d => d.CountryRegionCodeNavigation)
                    .WithMany(p => p.StateProvince)
                    .HasForeignKey(d => d.CountryRegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.StateProvince)
                    .HasForeignKey(d => d.TerritoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("Store", "Sales");

                entity.HasIndex(e => e.Demographics)
                    .HasName("PXML_Store_Demographics");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Store_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.SalesPersonId);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Demographics).HasColumnType("xml");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.Store)
                    .HasForeignKey<Store>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SalesPerson)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.SalesPersonId);
            });

            modelBuilder.Entity<StoreContact>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ContactId });

                entity.ToTable("StoreContact", "Sales");

                entity.HasIndex(e => e.ContactId);

                entity.HasIndex(e => e.ContactTypeId);

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_StoreContact_rowguid")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.StoreContact)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.StoreContact)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.StoreContact)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TransactionHistory>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("TransactionHistory", "Production");

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => new { e.ReferenceOrderId, e.ReferenceOrderLineId });

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.ActualCost).HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReferenceOrderId).HasColumnName("ReferenceOrderID");

                entity.Property(e => e.ReferenceOrderLineId).HasColumnName("ReferenceOrderLineID");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TransactionHistory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TransactionHistoryArchive>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("TransactionHistoryArchive", "Production");

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => new { e.ReferenceOrderId, e.ReferenceOrderLineId });

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActualCost).HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReferenceOrderId).HasColumnName("ReferenceOrderID");

                entity.Property(e => e.ReferenceOrderLineId).HasColumnName("ReferenceOrderLineID");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<UnitMeasure>(entity =>
            {
                entity.HasKey(e => e.UnitMeasureCode);

                entity.ToTable("UnitMeasure", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_UnitMeasure_Name")
                    .IsUnique();

                entity.Property(e => e.UnitMeasureCode)
                    .HasMaxLength(3)
                    .ValueGeneratedNever();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("Vendor", "Purchasing");

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("AK_Vendor_AccountNumber")
                    .IsUnique();

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnType("AccountNumber")
                    .HasMaxLength(15);

                entity.Property(e => e.ActiveFlag)
                    .IsRequired()
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.PreferredVendorStatus)
                    .IsRequired()
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PurchasingWebServiceUrl)
                    .HasColumnName("PurchasingWebServiceURL")
                    .HasMaxLength(1024);
            });

            modelBuilder.Entity<VendorAddress>(entity =>
            {
                entity.HasKey(e => new { e.VendorId, e.AddressId });

                entity.ToTable("VendorAddress", "Purchasing");

                entity.HasIndex(e => e.AddressId);

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.VendorAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.VendorAddress)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.VendorAddress)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<VendorContact>(entity =>
            {
                entity.HasKey(e => new { e.VendorId, e.ContactId });

                entity.ToTable("VendorContact", "Purchasing");

                entity.HasIndex(e => e.ContactId);

                entity.HasIndex(e => e.ContactTypeId);

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.VendorContact)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.VendorContact)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.VendorContact)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.ToTable("WorkOrder", "Production");

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.ScrapReasonId);

                entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ScrapReasonId).HasColumnName("ScrapReasonID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StockedQty).HasComputedColumnSql("(isnull([OrderQty]-[ScrappedQty],(0)))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WorkOrder)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ScrapReason)
                    .WithMany(p => p.WorkOrder)
                    .HasForeignKey(d => d.ScrapReasonId);
            });

            modelBuilder.Entity<WorkOrderRouting>(entity =>
            {
                entity.HasKey(e => new { e.WorkOrderId, e.ProductId, e.OperationSequence });

                entity.ToTable("WorkOrderRouting", "Production");

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ActualCost).HasColumnType("money");

                entity.Property(e => e.ActualEndDate).HasColumnType("datetime");

                entity.Property(e => e.ActualResourceHrs).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.ActualStartDate).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PlannedCost).HasColumnType("money");

                entity.Property(e => e.ScheduledEndDate).HasColumnType("datetime");

                entity.Property(e => e.ScheduledStartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.WorkOrderRouting)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.WorkOrder)
                    .WithMany(p => p.WorkOrderRouting)
                    .HasForeignKey(d => d.WorkOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
