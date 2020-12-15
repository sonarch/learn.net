using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //QueryingCategories();
            //QueryingProduct();
            //FilteredInclude();
            //QueryingWithLike();
            int deleted = DeleteProducts("Bob");
            WriteLine($"{deleted} product(s) were deleted.");
            ListProducts();
        }
        static int DeleteProducts(string name)
        {
            using (var db = new Northwind())
            {
                IEnumerable<Product> products = db.Products.Where(p => p.ProductName.StartsWith(name));
                db.Products.RemoveRange(products); int affected = db.SaveChanges(); return affected;
            }
        }
        static bool AddProduct(
            int categoryID, string productName, decimal? price
        )
        {
            using (var db = new Northwind())
            {
                var newProduct = new Product
                {
                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price
                };
                db.Add(newProduct);
                int affected = db.SaveChanges();
                return affected == 1;
            }
        }
        static bool IncreaseProductPrice(string name, decimal amount)
        {
            using (var db = new Northwind())
            {
                Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(name));
                updateProduct.Cost += amount;
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }
        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}", "ID", "Product Name", "Cost", "Stock", "Disc.");
                foreach (var item in db.Products.OrderByDescending(p => p.Cost))
                {
                    WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}", item.ProductID, item.ProductName, item.Cost, item.Stock, item.Discontinued);
                }
            }
        }
        static void QueryingWithLike()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Write("Enter part of a product name: ");
                string input = ReadLine();
                IQueryable<Product> prods = db.Products.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
                foreach (Product item in prods)
                {
                    WriteLine("{0} has {1} units in stock. Discontinued? {2}", item.ProductName, item.Stock, item.Discontinued);
                }
            }
        }
        static void QueryingCategories()
        {
            using (Northwind db = new Northwind())
            {
                //var loggerFactory = db.GetService<ILoggerFactory>();
                //loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Categories and how many products they have:");
                IQueryable<Category> cats;
                // = db.Categories;
                //.Include(c => c.Products);
                db.ChangeTracker.LazyLoadingEnabled = false;
                Write("Enable eager loading? (Y/N): ");
                bool eagerloading = (ReadKey().Key == ConsoleKey.Y);
                bool explicitloading = false;
                WriteLine();


                if (eagerloading)
                {
                    cats = db.Categories.Include(c => c.Products);
                }
                else
                {
                    cats = db.Categories;
                    Write("Enable explicit loading? (Y/N): ");
                    explicitloading = (ReadKey().Key == ConsoleKey.Y); WriteLine();
                }



                foreach (var c in cats)
                {
                    if (explicitloading)
                    {
                        Write($"Explicitly load products for {c.CategoryName}? (Y/N): ");
                        ConsoleKeyInfo key = ReadKey();
                        WriteLine(); if (key.Key == ConsoleKey.Y)
                        {
                            var products = db.Entry(c).Collection(c2 => c2.Products);
                            if (!products.IsLoaded) products.Load();
                        }

                    }
                    WriteLine($"{c.CategoryName} has {c.Products.Count} produces.");
                }
            }
        }

        static void FilteredInclude()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                Write("Enter a minimum for units in stock:");
                string unitsInStock = ReadLine();
                int stock = int.Parse(unitsInStock);
                IQueryable<Category> cats = db.Categories.Include(c => c.Products.Where(p => p.Stock >= stock));
                WriteLine(cats.ToQueryString());
                foreach (var c in cats)
                {
                    foreach (Product p in c.Products)
                    {
                        WriteLine($" {p.ProductName} has {p.Stock} units in stock.");
                    }
                }
            }
        }
        static void QueryingProduct()
        {
            using (var db = new Northwind())
            {
                WriteLine("Products that cost more than a price, highes at top.");
                string input;
                decimal price;
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                do
                {
                    Write("Enter a product price:");
                    input = ReadLine();

                } while (!decimal.TryParse(input, out price));
                IQueryable<Product> prods = db.Products.TagWith("Products filtered by price and sorted.").Where(product => product.Cost > price).OrderByDescending(p => p.Cost);
                foreach (var item in prods)
                {
                    WriteLine(
                        "{1} {2} costs {2:$#,##0.00} and has {3} in stock.",
                        item.ProductID, item.ProductName, item.Cost, item.Stock
                    );
                }
            }
        }

    }
}