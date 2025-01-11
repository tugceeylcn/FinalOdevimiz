namespace Odev.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAddress",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AddressCustomerId = c.Guid(nullable: false),
                        AddressCountryId = c.Guid(),
                        AddressCityId = c.Guid(),
                        AddressCountyId = c.Guid(),
                        AddressDistrictId = c.Guid(),
                        AddressStreetId = c.Guid(),
                        AddressCountryRegionId = c.Guid(),
                        AddressTypeId = c.Guid(),
                        AddressInvoiceTypeId = c.Guid(),
                        AddressInvoiceFirmName = c.String(),
                        AddressInvoiceTaxOffice = c.String(),
                        AddressInvoiceTaxNumber = c.String(),
                        AddressName = c.String(),
                        AddressFirstName = c.String(),
                        AddressLastName = c.String(),
                        AddressText = c.String(),
                        AddressPostalCode = c.String(),
                        AddressPhone = c.String(),
                        AddressMobilePhone = c.String(),
                        AddressIdentityNumber = c.String(),
                        AddressStreetText = c.String(),
                        ZipCode = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                        City_Id = c.Guid(),
                        Country_Id = c.Guid(),
                        County_Id = c.Guid(),
                        District_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCity", t => t.City_Id)
                .ForeignKey("dbo.tblCountry", t => t.Country_Id)
                .ForeignKey("dbo.tblCounty", t => t.County_Id)
                .ForeignKey("dbo.Districts", t => t.District_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.County_Id)
                .Index(t => t.District_Id);
            
            CreateTable(
                "dbo.tblCity",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CityCode = c.Int(nullable: false),
                        CityCountryId = c.Guid(nullable: false),
                        CityLatitude = c.String(),
                        CityLongtitude = c.String(),
                        CityName = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCountry", t => t.CityCountryId, cascadeDelete: true)
                .Index(t => t.CityCountryId);
            
            CreateTable(
                "dbo.tblCountry",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CountryCode = c.String(),
                        CountryLatitude = c.String(),
                        CountryLongitude = c.String(),
                        CountryName = c.String(),
                        CountryRegexMobilePhone = c.String(),
                        CountryRegexPostalCode = c.String(),
                        CountryFlagImageFileName = c.String(),
                        CountryPhoneCodePrefix = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerAddresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        CountryId = c.Guid(nullable: false),
                        CityId = c.Guid(nullable: false),
                        CountyId = c.Guid(nullable: false),
                        DistrictId = c.Guid(nullable: false),
                        AddressText = c.String(),
                        AddressName = c.String(),
                        AddressTypeId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MobilePhone = c.String(),
                        ZipCode = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCity", t => t.CityId)
                .ForeignKey("dbo.tblCountry", t => t.CountryId)
                .ForeignKey("dbo.tblCounty", t => t.CountyId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .Index(t => t.CustomerId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
                .Index(t => t.CountyId)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.tblCounty",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CountyCityId = c.Guid(nullable: false),
                        CountyLatitude = c.String(),
                        CountyLongtitude = c.String(),
                        CountyName = c.String(),
                        CountyCode = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerBirthDate = c.DateTime(),
                        CustomerEmail = c.String(),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        CustomerGenderId = c.Guid(nullable: false),
                        CustomerIdentityNumber = c.String(),
                        CustomerLastBillingAddressId = c.Guid(),
                        CustomerLastShippingAddressId = c.Guid(),
                        CustomerLastIpAddress = c.String(),
                        CustomerPassword = c.String(),
                        CustomerPasswordSalt = c.String(),
                        CustomerPhone = c.String(),
                        CustomerRegisterDate = c.DateTime(),
                        LastChangePasswordDate = c.DateTime(),
                        CustomerTypeId = c.Guid(),
                        CustomerFirstOrderDate = c.DateTime(),
                        CustomerEmailIsValidated = c.Boolean(nullable: false),
                        CustomerEmailValidatedDate = c.DateTime(),
                        CustomerOrderTotal = c.Decimal(precision: 18, scale: 2),
                        CustomerPhoneIsValidated = c.Boolean(nullable: false),
                        CustomerPhoneValidatedDate = c.DateTime(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CargoFirmName = c.String(),
                        CargoOnDeliveryInclTax = c.Decimal(precision: 18, scale: 2),
                        CargoShippingInclTax = c.Decimal(precision: 18, scale: 2),
                        GiftCardMessage = c.String(),
                        OrderAffiliateId = c.Int(),
                        OrderBillingAddressId = c.Guid(nullable: false),
                        OrderCargoId = c.Guid(nullable: false),
                        OrderCustomerId = c.Guid(nullable: false),
                        OrderCustomerIp = c.String(),
                        OrderErrorMessage = c.String(),
                        OrderIndex = c.Int(),
                        OrderInstallmentCount = c.Int(),
                        OrderMaskedCardNumber = c.String(),
                        OrderOrderPaymentStatusId = c.Int(nullable: false),
                        OrderOrderStatusId = c.Int(nullable: false),
                        OrderRefundedAmount = c.Decimal(precision: 18, scale: 2),
                        OrderShippingAddressId = c.Guid(nullable: false),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderTotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderUsedGiftCardAmount = c.Decimal(precision: 18, scale: 2),
                        GiftWrappingInclTax = c.Decimal(precision: 18, scale: 2),
                        GiftWrappingDetail = c.String(),
                        IsThreeDSecurePayment = c.Boolean(),
                        OrderShoppingCartId = c.Guid(),
                        DeliveryDate = c.DateTime(),
                        RefundAmountDate = c.DateTime(),
                        EstimatedDate = c.String(),
                        TrackingNumber = c.String(),
                        InvoiceUrl = c.String(),
                        CustomerFullName = c.String(),
                        CustomerEmail = c.String(),
                        CargoCampaign = c.Boolean(),
                        TransactionNumber = c.String(),
                        ConversationId = c.Guid(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerAddresses", t => t.OrderBillingAddressId)
                .ForeignKey("dbo.tblCargo", t => t.OrderCargoId)
                .ForeignKey("dbo.Customers", t => t.OrderCustomerId)
                .ForeignKey("dbo.CustomerAddresses", t => t.OrderShippingAddressId)
                .Index(t => t.OrderBillingAddressId)
                .Index(t => t.OrderCargoId)
                .Index(t => t.OrderCustomerId)
                .Index(t => t.OrderShippingAddressId);
            
            CreateTable(
                "dbo.tblCargo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CargoName = c.String(),
                        CargoFirmLogo = c.String(),
                        CargoIncTax = c.String(),
                        CargoWebSite = c.String(),
                        TrackingUrl = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DistrictCountyId = c.Guid(nullable: false),
                        DistrictLatitude = c.String(),
                        DistrictLongtitude = c.String(),
                        DistrictName = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCounty", t => t.DistrictCountyId, cascadeDelete: true)
                .Index(t => t.DistrictCountyId);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StreetDistrictId = c.Guid(nullable: false),
                        StreetLatitude = c.String(),
                        StreetLongtitude = c.String(),
                        StreetName = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.StreetDistrictId, cascadeDelete: true)
                .Index(t => t.StreetDistrictId);
            
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AttributeName = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductAttributes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        AttributeId = c.Guid(nullable: false),
                        AttributeValue = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Attributes", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.AttributeId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductName = c.String(),
                        ProductDetail = c.String(),
                        ProductCoverImage = c.String(),
                        ProductFirstPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ColorId = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        SkuId = c.String(),
                        ProductTickets = c.String(),
                        ProductStock = c.Int(nullable: false),
                        TotalSaleCount = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        IsPopular = c.Boolean(nullable: false),
                        Slug = c.String(),
                        AttributeFirst = c.Guid(nullable: false),
                        AttributeTwo = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategory", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.tblColor", t => t.ColorId, cascadeDelete: true)
                .Index(t => t.ColorId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.tblCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryName = c.String(),
                        CategoryImage = c.String(),
                        TopCategoryId = c.Guid(),
                        DisplayOrder = c.Int(nullable: false),
                        Slug = c.String(),
                        IsPopular = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategory", t => t.TopCategoryId)
                .Index(t => t.TopCategoryId);
            
            CreateTable(
                "dbo.tblColor",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ColorName = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        ImageUrl = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.tblBlog",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BlogTitle = c.String(),
                        BlogContent = c.String(),
                        BlogImage = c.String(),
                        BlogTicket = c.String(),
                        CategoryId = c.Guid(),
                        DisplayOrder = c.Int(nullable: false),
                        LikeCount = c.Int(),
                        ShortUrl = c.String(),
                        Slug = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategory", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.tblBlogComment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstLastName = c.String(),
                        Email = c.String(),
                        CommentDetail = c.String(),
                        BlogId = c.Guid(nullable: false),
                        CustomerId = c.Guid(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblBlog", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.BlogGalleries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BlogId = c.Guid(nullable: false),
                        Image = c.String(),
                        ImageTitle = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblBlog", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.CustomerNewsletters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmailEnabled = c.Boolean(nullable: false),
                        SmsEnabled = c.Boolean(nullable: false),
                        CallEnabled = c.Boolean(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerWishLists",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Url = c.String(),
                        Title = c.String(),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentCategory = c.Byte(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeneralPages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        Image = c.String(),
                        Page = c.Byte(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Identities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(),
                        Image = c.String(),
                        UrlDocument = c.String(),
                        DocumentCategory = c.Byte(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MailSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Host = c.String(),
                        Port = c.Int(nullable: false),
                        MailAddress = c.String(),
                        Password = c.String(),
                        Ssl = c.Boolean(nullable: false),
                        CCMail = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Text = c.String(),
                        PictureUrl = c.String(),
                        Slug = c.String(),
                        NewsDate = c.DateTime(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderItemDiscount = c.Decimal(precision: 18, scale: 2),
                        OrderItemOrderId = c.Guid(nullable: false),
                        OrderItemOrderStatusId = c.Int(nullable: false),
                        OrderItemPriceInclTax = c.Decimal(precision: 18, scale: 2),
                        OrderItemQuantity = c.Int(nullable: false),
                        OrderItemRefundAmount = c.Decimal(precision: 18, scale: 2),
                        OrderItemTaxRate = c.Int(nullable: false),
                        OrderItemSalePriceInclTax = c.Decimal(precision: 18, scale: 2),
                        OrderItemSaleDiscount = c.Decimal(precision: 18, scale: 2),
                        OrderItemSaleRefundAmount = c.Decimal(precision: 18, scale: 2),
                        OrderItemSaleInstallmentPriceInclTax = c.Decimal(precision: 18, scale: 2),
                        OrderItemFirstPriceInclTax = c.Decimal(precision: 18, scale: 2),
                        GiftCardDetails = c.String(),
                        OrderItemShoppingCartItemId = c.Guid(),
                        QuantityReturned = c.Int(),
                        QuantityCancelled = c.Int(),
                        UsedGiftClubPointAmount = c.Decimal(precision: 18, scale: 2),
                        EarndGiftClubPointAmount = c.Decimal(precision: 18, scale: 2),
                        ProductId = c.Guid(),
                        ProductName = c.String(),
                        ProductImage = c.String(),
                        TransactionNumber = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.PostalCodes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RegionId = c.Int(),
                        CountryId = c.Guid(),
                        CityId = c.Guid(),
                        CountyId = c.Guid(),
                        DistrictId = c.Guid(),
                        PostCode = c.String(),
                        MaxPostCode = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Currency = c.String(),
                        CargoPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CargoName = c.String(),
                        CargoTrackingUrl = c.String(),
                        MinEstimatedDate = c.Int(nullable: false),
                        MaxEstimatedDate = c.Int(nullable: false),
                        PaymentCreditCardEnabled = c.Boolean(nullable: false),
                        PaymentOnDeliveryEnabled = c.Boolean(nullable: false),
                        PaymentInstallmentEnabled = c.Boolean(nullable: false),
                        CompayTransferEnabled = c.Boolean(nullable: false),
                        CdnPath = c.String(),
                        DefaultLanguageId = c.String(),
                        IyzicoBaseUrl = c.String(),
                        IyzicoSecretKey = c.String(),
                        IyzicoApiKey = c.String(),
                        CargoCampaign = c.String(),
                        SmsGatewayBaseUrl = c.String(),
                        SmsGatewaySecretKey = c.String(),
                        SmsGatewayApiKey = c.String(),
                        SmsSenderName = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        UsedCodeOrCoupon = c.String(),
                        BasketTaxTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GetCargoOnDeliveryInclTax = c.Decimal(precision: 18, scale: 2),
                        GetShoppingCartItemTotalQuantity = c.Int(nullable: false),
                        OrderOrderTypeId = c.Guid(nullable: false),
                        PaymentTypeId = c.Guid(nullable: false),
                        IsCodeOrCopunEnabled = c.Boolean(nullable: false),
                        UsedGiftCardAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsGiftCardEnabled = c.Boolean(nullable: false),
                        CargoId = c.Guid(nullable: false),
                        AddressId = c.Guid(nullable: false),
                        CargoCampaign = c.Boolean(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                        CustomerInfo_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCargo", t => t.CargoId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerInfo_Id)
                .Index(t => t.CargoId)
                .Index(t => t.CustomerInfo_Id);
            
            CreateTable(
                "dbo.ShoppingCartItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ShoppingCartId = c.Guid(nullable: false),
                        CampaignCodeKey = c.String(),
                        UsedGiftCardPointPriceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Guid(nullable: false),
                        ProductTitle = c.String(),
                        ProductCategoryTitle = c.String(),
                        PictureImage = c.String(),
                        ColorId = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductSlug = c.String(),
                        OrderItemPriceInclTax = c.Decimal(precision: 18, scale: 2),
                        OrderItemDiscount = c.Decimal(precision: 18, scale: 2),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCartId, cascadeDelete: true)
                .Index(t => t.ShoppingCartId);
            
            CreateTable(
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Adres = c.String(),
                        Logo = c.String(nullable: false, maxLength: 350),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Instagram = c.String(),
                        Youtube = c.String(),
                        Maps = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Image = c.String(),
                        TextOne = c.String(),
                        TextTwo = c.String(),
                        TextThree = c.String(),
                        IsSale = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SolutionPartners",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartnerName = c.String(),
                        PartnerImage = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        Slug = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubscribeMembers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users1",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserEmail = c.String(),
                        UserFirstName = c.String(),
                        UserLastname = c.String(),
                        UserLastvisitDate = c.DateTime(),
                        UserPassword = c.String(),
                        UserPasswordSalt = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameSurname = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Pwd = c.String(),
                        UserTypeId = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        GeneralPageTransactions = c.Boolean(nullable: false),
                        SubGeneralPageTransactions = c.Boolean(nullable: false),
                        IdentityTransactions = c.Boolean(nullable: false),
                        SubIdentityTransactions = c.Boolean(nullable: false),
                        NewsTransactions = c.Boolean(nullable: false),
                        SubNewsTransactions = c.Boolean(nullable: false),
                        SiteSettingTransactions = c.Boolean(nullable: false),
                        SubSiteSettingTransactions = c.Boolean(nullable: false),
                        SliderTransactions = c.Boolean(nullable: false),
                        SubSliderTransactions = c.Boolean(nullable: false),
                        SubscribeMemberTransactions = c.Boolean(nullable: false),
                        SubSubscribeMemberTransactions = c.Boolean(nullable: false),
                        UsersTransactions = c.Boolean(nullable: false),
                        SubUsersTransactions = c.Boolean(nullable: false),
                        UserTypeTransactions = c.Boolean(nullable: false),
                        SubUserTypeTransactions = c.Boolean(nullable: false),
                        CityTransactions = c.Boolean(nullable: false),
                        SubCityTransactions = c.Boolean(nullable: false),
                        CategoryTransactions = c.Boolean(nullable: false),
                        SubCategoryTransactions = c.Boolean(nullable: false),
                        SolutionPartnersTransactions = c.Boolean(nullable: false),
                        SubSolutionPartnersTransactions = c.Boolean(nullable: false),
                        BlogTransactions = c.Boolean(nullable: false),
                        SubBlogTransactions = c.Boolean(nullable: false),
                        SettingTransactions = c.Boolean(nullable: false),
                        SubSettingTransactions = c.Boolean(nullable: false),
                        ColorTransactions = c.Boolean(nullable: false),
                        SubColorTransactions = c.Boolean(nullable: false),
                        ProductTransactions = c.Boolean(nullable: false),
                        SubProductTransactions = c.Boolean(nullable: false),
                        BlogGalleryTransactions = c.Boolean(nullable: false),
                        SubBlogGalleryTransactions = c.Boolean(nullable: false),
                        OrderTransactions = c.Boolean(nullable: false),
                        SubOrderTransactions = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedUserId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        UpdatedUserId = c.Guid(),
                        Language = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.ShoppingCartItems", "ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCarts", "CustomerInfo_Id", "dbo.Customers");
            DropForeignKey("dbo.ShoppingCarts", "CargoId", "dbo.tblCargo");
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.CustomerWishLists", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CustomerWishLists", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerNewsletters", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.tblBlog", "CategoryId", "dbo.tblCategory");
            DropForeignKey("dbo.BlogGalleries", "BlogId", "dbo.tblBlog");
            DropForeignKey("dbo.tblBlogComment", "BlogId", "dbo.tblBlog");
            DropForeignKey("dbo.ProductAttributes", "AttributeId", "dbo.Attributes");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductAttributes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ColorId", "dbo.tblColor");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.tblCategory");
            DropForeignKey("dbo.tblCategory", "TopCategoryId", "dbo.tblCategory");
            DropForeignKey("dbo.tblAddress", "District_Id", "dbo.Districts");
            DropForeignKey("dbo.tblAddress", "County_Id", "dbo.tblCounty");
            DropForeignKey("dbo.tblAddress", "Country_Id", "dbo.tblCountry");
            DropForeignKey("dbo.tblAddress", "City_Id", "dbo.tblCity");
            DropForeignKey("dbo.tblCity", "CityCountryId", "dbo.tblCountry");
            DropForeignKey("dbo.CustomerAddresses", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Streets", "StreetDistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "DistrictCountyId", "dbo.tblCounty");
            DropForeignKey("dbo.CustomerAddresses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "OrderShippingAddressId", "dbo.CustomerAddresses");
            DropForeignKey("dbo.Orders", "OrderCustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "OrderCargoId", "dbo.tblCargo");
            DropForeignKey("dbo.Orders", "OrderBillingAddressId", "dbo.CustomerAddresses");
            DropForeignKey("dbo.CustomerAddresses", "CountyId", "dbo.tblCounty");
            DropForeignKey("dbo.CustomerAddresses", "CountryId", "dbo.tblCountry");
            DropForeignKey("dbo.CustomerAddresses", "CityId", "dbo.tblCity");
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.ShoppingCartItems", new[] { "ShoppingCartId" });
            DropIndex("dbo.ShoppingCarts", new[] { "CustomerInfo_Id" });
            DropIndex("dbo.ShoppingCarts", new[] { "CargoId" });
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropIndex("dbo.CustomerWishLists", new[] { "ProductId" });
            DropIndex("dbo.CustomerWishLists", new[] { "CustomerId" });
            DropIndex("dbo.CustomerNewsletters", new[] { "CustomerId" });
            DropIndex("dbo.BlogGalleries", new[] { "BlogId" });
            DropIndex("dbo.tblBlogComment", new[] { "BlogId" });
            DropIndex("dbo.tblBlog", new[] { "CategoryId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.tblCategory", new[] { "TopCategoryId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "ColorId" });
            DropIndex("dbo.ProductAttributes", new[] { "AttributeId" });
            DropIndex("dbo.ProductAttributes", new[] { "ProductId" });
            DropIndex("dbo.Streets", new[] { "StreetDistrictId" });
            DropIndex("dbo.Districts", new[] { "DistrictCountyId" });
            DropIndex("dbo.Orders", new[] { "OrderShippingAddressId" });
            DropIndex("dbo.Orders", new[] { "OrderCustomerId" });
            DropIndex("dbo.Orders", new[] { "OrderCargoId" });
            DropIndex("dbo.Orders", new[] { "OrderBillingAddressId" });
            DropIndex("dbo.CustomerAddresses", new[] { "DistrictId" });
            DropIndex("dbo.CustomerAddresses", new[] { "CountyId" });
            DropIndex("dbo.CustomerAddresses", new[] { "CityId" });
            DropIndex("dbo.CustomerAddresses", new[] { "CountryId" });
            DropIndex("dbo.CustomerAddresses", new[] { "CustomerId" });
            DropIndex("dbo.tblCity", new[] { "CityCountryId" });
            DropIndex("dbo.tblAddress", new[] { "District_Id" });
            DropIndex("dbo.tblAddress", new[] { "County_Id" });
            DropIndex("dbo.tblAddress", new[] { "Country_Id" });
            DropIndex("dbo.tblAddress", new[] { "City_Id" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Users1");
            DropTable("dbo.SubscribeMembers");
            DropTable("dbo.SolutionPartners");
            DropTable("dbo.Sliders");
            DropTable("dbo.SiteSettings");
            DropTable("dbo.ShoppingCartItems");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.Settings");
            DropTable("dbo.PostalCodes");
            DropTable("dbo.OrderItems");
            DropTable("dbo.News");
            DropTable("dbo.MailSettings");
            DropTable("dbo.Identities");
            DropTable("dbo.GeneralPages");
            DropTable("dbo.Documents");
            DropTable("dbo.CustomerWishLists");
            DropTable("dbo.CustomerNewsletters");
            DropTable("dbo.BlogGalleries");
            DropTable("dbo.tblBlogComment");
            DropTable("dbo.tblBlog");
            DropTable("dbo.ProductImages");
            DropTable("dbo.tblColor");
            DropTable("dbo.tblCategory");
            DropTable("dbo.Products");
            DropTable("dbo.ProductAttributes");
            DropTable("dbo.Attributes");
            DropTable("dbo.Streets");
            DropTable("dbo.Districts");
            DropTable("dbo.tblCargo");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.tblCounty");
            DropTable("dbo.CustomerAddresses");
            DropTable("dbo.tblCountry");
            DropTable("dbo.tblCity");
            DropTable("dbo.tblAddress");
        }
    }
}
