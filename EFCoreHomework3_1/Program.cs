using System;
using System.Collections.Generic;
using EFCoreHomework3_1.DAL;
using EFCoreHomework3_1.DBModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreHomework3_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            GenerateData();

            ShowDataToConsole();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static void GenerateData()
        {
            //(2 користувачі, 3 категорії, 7 продуктів та ключові слова для них)
            using (DatabaseContext db = new DatabaseContext())
            {

                #region Add Users
                db.Users.RemoveRange(db.Users);
                var user = new List<User>()
                {
                    new User() { Name = "User1"},
                    new User() { Name = "User2"}
                };
                db.Users.AddRange(user);
                db.SaveChanges();
                #endregion

                #region Get Users
                var u1 = db.Users.Where(p => p.Name == "User1").FirstOrDefault();
                var u2 = db.Users.Where(p => p.Name == "User2").FirstOrDefault();
                #endregion

                #region Add Category
                db.Categories.RemoveRange(db.Categories);
                var category = new List<Category>()
                {
                    new Category { Name = "TV"},
                    new Category { Name = "Smartphone"},
                    new Category { Name = "Notebook"}
                };
                db.Categories.AddRange(category);
                db.SaveChanges();
                #endregion

                #region Get Category GUID
                var c1 = db.Categories.Where(p => p.Name == "TV").Select(p => new { Id = p.Id }).FirstOrDefault().Id;
                var c2 = db.Categories.Where(p => p.Name == "Smartphone").Select(p => new { Id = p.Id }).FirstOrDefault().Id;
                var c3 = db.Categories.Where(p => p.Name == "Notebook").Select(p => new { Id = p.Id }).FirstOrDefault().Id;
                #endregion

                #region Add Products
                db.Products.RemoveRange(db.Products);
                var product = new List<Product>()
                {
                    new Product() { Name = "Телевізор SONY KD-55X81JR", CategoryId = c1 },
                    new Product() { Name = "Смартфон OPPO A17 4/64GB Midnight Black", CategoryId = c2 },
                    new Product() { Name = "Ноутбук ASUS X515EA-BQ1854 Transparent Silver", CategoryId = c3 },
                    new Product() { Name = "Телевізор LG 43UQ75006LF", CategoryId = c1 },
                    new Product() { Name = "Смартфон REALME C30s 4/64Gb Stripe Blue", CategoryId = c2 },
                    new Product() { Name = "Ноутбук LENOVO IdeaPad 1 15ADA7 Cloud Grey", CategoryId = c3 },
                    new Product() { Name = "Телевізор SAMSUNG UE32T4500AUXUA", CategoryId = c1 }
                };
                db.Products.AddRange(product);
                db.SaveChanges();
                #endregion

                #region Get Products GUID
                var p1 = db.Products.Where(p => p.Name == "Телевізор SONY KD-55X81JR").FirstOrDefault();
                var p2 = db.Products.Where(p => p.Name == "Смартфон OPPO A17 4/64GB Midnight Black").FirstOrDefault();
                var p3 = db.Products.Where(p => p.Name == "Ноутбук ASUS X515EA-BQ1854 Transparent Silver").FirstOrDefault();
                var p4 = db.Products.Where(p => p.Name == "Телевізор LG 43UQ75006LF").FirstOrDefault();
                var p5 = db.Products.Where(p => p.Name == "Смартфон REALME C30s 4/64Gb Stripe Blue").FirstOrDefault();
                var p6 = db.Products.Where(p => p.Name == "Ноутбук LENOVO IdeaPad 1 15ADA7 Cloud Grey").FirstOrDefault();
                var p7 = db.Products.Where(p => p.Name == "Телевізор SAMSUNG UE32T4500AUXUA").FirstOrDefault();
                #endregion

                #region Add Words
                db.Words.RemoveRange(db.Words);
                var word = new List<Word>()
                {
                    new Word() { KeyWord = "Smart TV"},
                    new Word() { KeyWord = "НОУТБУК З SSD"},
                    new Word() { KeyWord = "НОУТБУК З HDD"},
                    new Word() { KeyWord = "Qualcomm Snapdragon"},
                    new Word() { KeyWord = "Android"}
                };
                db.Words.AddRange(word);
                db.SaveChanges();
                #endregion

                #region Get Word GUID
                var k1 = db.Words.Where(p => p.KeyWord == "Smart TV").FirstOrDefault(); 
                var k2 = db.Words.Where(p => p.KeyWord == "НОУТБУК З SSD").FirstOrDefault();
                var k3 = db.Words.Where(p => p.KeyWord == "НОУТБУК З HDD").FirstOrDefault();
                var k4 = db.Words.Where(p => p.KeyWord == "Qualcomm Snapdragon").FirstOrDefault();
                var k5 = db.Words.Where(p => p.KeyWord == "Android").FirstOrDefault();
                #endregion

                #region Add KeyParams
                db.KeyParams.Add(new KeyParams() { KeyWords = k1, Product = p1 });
                db.KeyParams.Add(new KeyParams() { KeyWords = k4, Product = p2 });
                db.KeyParams.Add(new KeyParams() { KeyWords = k2, Product = p3 });
                db.KeyParams.Add(new KeyParams() { KeyWords = k1, Product = p4 });
                db.KeyParams.Add(new KeyParams() { KeyWords = k5, Product = p5 });
                db.KeyParams.Add(new KeyParams() { KeyWords = k3, Product = p6 });
                db.KeyParams.Add(new KeyParams() { KeyWords = k1, Product = p7 });
                db.SaveChanges();
                #endregion

                #region Add Cart
                db.Carts.Add(new Cart() { User = u1, Product = p1 });
                db.Carts.Add(new Cart() { User = u2, Product = p2 });
                db.SaveChanges();
                #endregion

            }
        }

        static void ShowDataToConsole()
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                #region Show Products
                List<Category> category = db.Categories
                    .Include(c => c.Products) //.ToList();
                    .ThenInclude(k => k.KeyWords)
                    .ThenInclude(w => w.KeyWords)
                    .ToList();
                    

                if (category != null)
                {
                    foreach (var cat in category)
                    {
                        Console.WriteLine($"\nCategory: {cat.Name}");
                        foreach (var p in cat.Products)
                        {
                            Console.WriteLine($"\t Products: {p.Name}");
                            foreach (var k in p.KeyWords)
                            {
                                Console.WriteLine($"\t\tKeyWords: {k.KeyWords.KeyWord}");
                            }
                        }
                    }
                }
                #endregion

                #region Show Users
                List<Cart> carts = db.Carts
                    .Include(u => u.User)
                    .Include(p => p.Product)
                    .ThenInclude(k => k.KeyWords)
                    .ThenInclude(w => w.KeyWords)
                    .ToList();

                if (carts != null)
                {
                    foreach (var c in carts)
                    {
                        Console.WriteLine($"User: {c.User.Name} Product: {c.Product.Name}");
                        foreach (var k in c.Product.KeyWords)
                        {
                            Console.WriteLine($"\t\tKeyWords: {k.KeyWords.KeyWord}");
                        }
                    }
                }

               
                #endregion


            }



        }
    }
}
