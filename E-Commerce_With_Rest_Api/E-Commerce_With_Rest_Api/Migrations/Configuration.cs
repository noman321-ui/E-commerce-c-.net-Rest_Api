namespace E_Commerce_With_Rest_Api.Migrations
{
    using E_Commerce_With_Rest_Api.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E_Commerce_With_Rest_Api.Models.E_CommerceApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(E_Commerce_With_Rest_Api.Models.E_CommerceApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            List<MainCategory> mainCategories = new List<MainCategory>
            {
                new MainCategory()
                {
                    Category_name = "Men"
                },
                new MainCategory{ Category_name = "Women" },
                new MainCategory{ Category_name = "Life Style" },
                new MainCategory{ Category_name = "Sale" },
            };
            List<Admin> admins = new List<Admin>
            {
                 new Admin
                 {
                    AdminName = "Jahangir Nabin",
                    PhoneNum = "+8801798724156",
                    ImageFile = "download1.jpg",
                    Address = "Naogaon, Rajshahi",
                    DateOfBirth = "5/2/2021",
                    Gender = "male",
                    Username = "admin",
                    Password = "1234",
                    UserType = "admin"
                 }
                    
             };
            List<SubCategory> subCategories = new List<SubCategory>
            {
                new SubCategory{
                    SubCategory_name = "Winter",
                    MainCategoryId = 1
                },
                new SubCategory{
                    SubCategory_name = "Shirts & Tees",
                    MainCategoryId = 1
                },
                new SubCategory{
                    SubCategory_name = "Pants",
                    MainCategoryId = 1
                },
                new SubCategory{
                    SubCategory_name = "Footwaar",
                    MainCategoryId = 1
                },
                new SubCategory{
                    SubCategory_name = "Accessories",
                    MainCategoryId = 1
                },
                new SubCategory{
                    SubCategory_name = "Winter",
                    MainCategoryId = 2
                },
                new SubCategory{
                    SubCategory_name = "Tops",
                    MainCategoryId = 2
                },
                new SubCategory{
                    SubCategory_name = "Bottoms",
                    MainCategoryId = 2
                },
                new SubCategory{
                    SubCategory_name = "Scarves",
                    MainCategoryId = 2
                },
                new SubCategory{
                    SubCategory_name = "Bags",
                    MainCategoryId = 2
                },
                new SubCategory{
                    SubCategory_name = "Luggage",
                    MainCategoryId = 3
                },
                new SubCategory{
                    SubCategory_name = "Perfume",
                    MainCategoryId = 3
                },
                new SubCategory{
                    SubCategory_name = "Sunglass",
                    MainCategoryId = 3
                }
            };
            List<FinalSubCategory> finalSubCategories = new List<FinalSubCategory> {
                new FinalSubCategory
                {
                    FinalSubCate_name = "Jackets",
                    SubCategoryId = 1
                },
                 new FinalSubCategory
                {
                    FinalSubCate_name = "Suits & Blazers",
                    SubCategoryId = 1
                },
                  new FinalSubCategory
                {
                    FinalSubCate_name = "Hoodies",
                    SubCategoryId = 1
                },
                   new FinalSubCategory
                {
                    FinalSubCate_name = "SweatShirts",
                    SubCategoryId = 1
                },
                    new FinalSubCategory
                {
                    FinalSubCate_name = "Sweater",
                    SubCategoryId = 1
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Casual Shirts",
                    SubCategoryId = 2
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Polo",
                    SubCategoryId = 2
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "T Shirts",
                    SubCategoryId = 2
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Dress Shirts",
                    SubCategoryId = 2
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Jeans",
                    SubCategoryId = 3
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Chinos",
                    SubCategoryId = 3
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Dress Pants",
                    SubCategoryId = 3
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Shorts",
                    SubCategoryId = 3
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Joggers/Trousers",
                    SubCategoryId = 3
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Loafers",
                    SubCategoryId = 4
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Sneakers",
                    SubCategoryId = 4
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Sandals",
                    SubCategoryId = 4
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Boots",
                    SubCategoryId = 4
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Bags",
                    SubCategoryId = 5
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Caps/Hats",
                    SubCategoryId = 5
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Mask",
                    SubCategoryId = 5
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Umbrella & Mug",
                    SubCategoryId = 5
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Sunglass",
                    SubCategoryId = 5
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Wallet/Card",
                    SubCategoryId = 5
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Overcoat",
                    SubCategoryId = 6
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Hoodies",
                    SubCategoryId = 6
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Jackets",
                    SubCategoryId = 6
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Sweatshirt",
                    SubCategoryId = 6
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Punchos",
                    SubCategoryId = 6
                },
                 new FinalSubCategory
                {
                    FinalSubCate_name = "Kammez/Kurtis",
                    SubCategoryId = 7
                },
                  new FinalSubCategory
                {
                    FinalSubCate_name = "Fashion Tops & Shirts",
                    SubCategoryId = 7
                },
                   new FinalSubCategory
                {
                    FinalSubCate_name = "Shrugs & Duster",
                    SubCategoryId = 7
                },
                    new FinalSubCategory
                {
                    FinalSubCate_name = "Blazers",
                    SubCategoryId = 7
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Jeans",
                    SubCategoryId = 8
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Leggings",
                    SubCategoryId = 8
                },
                new FinalSubCategory
                {
                    FinalSubCate_name = "Zarzain Pants",
                    SubCategoryId = 8
                }
            };
            if (!context.MainCategories.Any())
            {
                foreach(var mcategory in mainCategories)
                {
                    context.MainCategories.Add(mcategory);
                    context.SaveChanges();
                }
            }
            if (!context.SubCatetories.Any())
            {
                foreach (var scategory in subCategories)
                {
                    context.SubCatetories.Add(scategory);
                    context.SaveChanges();
                }
            }
            if (!context.FinalSubCategories.Any())
            {
                foreach (var fcategory in finalSubCategories)
                {
                    context.FinalSubCategories.Add(fcategory);
                    context.SaveChanges();
                }
            }

            if (!context.Admins.Any())
            {
                foreach (var admin in admins)
                {
                    context.Admins.Add(admin);
                    context.SaveChanges();
                }
            }
        }
    }
}
