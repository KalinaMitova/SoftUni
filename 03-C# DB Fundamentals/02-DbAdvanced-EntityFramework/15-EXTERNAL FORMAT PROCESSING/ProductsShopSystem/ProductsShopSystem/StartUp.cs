namespace ProductsShopSystem
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;

    using Data;
    using Data.Models;

    using Newtonsoft.Json;

    using Microsoft.EntityFrameworkCore;
    

    class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize database
            var context = new ProductsShopContext();
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            //_______________JSON_______________
            //Import data from JSON to Database
            string result1 = ImportCategoriesFromJson();
            string result2 = ImportUsersFromJson();
            string result3 = ImportProductsFromJson();
            string result4 = SetCategoriesJSON();

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.WriteLine(result4);

            ////Export data from Database to JSON
            GetProdictsInRangeJSON();
            SuccessfullySoldProductsJSON();
            CategoriesByProductsCountJSON();
            UsersAndProductsJSON();

            //_______________XML_______________
            ////Import data from XML to Database
            //string result1 = ImportUsersFromXml();
            //string result2 = ImportCategoriesFromXml();
            //string result3 = ImportProuctsFromXml();

            //Console.WriteLine(result1);
            //Console.WriteLine(result2);
            //Console.WriteLine(result3);

            ////Export data from Database to XML
            //ProductsInRangeXML();
            //SoldProductsXML();
            //CategoriesByProductsCountXML();
            //UsersAndProductsXML();
        }

        //XML
        static string ImportUsersFromXml()
        {
            string filePath = "Files/users.xml";

            string xmlString = File.ReadAllText(filePath);

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var users = new List<User>();

            foreach (var e in elements)
            {
                string firstName = e.Attribute("firstName")?.Value;
                string lastName = e.Attribute("lastName")?.Value;

                int? age = null;
                if(e.Attribute("age") != null)
                {
                    age = int.Parse(e.Attribute("age").Value);
                }

                var user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                users.Add(user);
            }

            using (var context = new ProductsShopContext())
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }

            return $"{users.Count()} users were imported from file: {filePath}";
        }
        static string ImportCategoriesFromXml()
        {
            string filePath = "Files/categories.xml";

            string xmlString = File.ReadAllText(filePath);

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var categories = new List<Category>();

            foreach (var e in elements)
            {
                var category = new Category()
                {
                    Name = e.Element("name").Value
                };

                categories.Add(category);
            }

            using (var context = new ProductsShopContext())
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            return $"{categories.Count()} categories were imported from file: {filePath}";
        }
        static string ImportProuctsFromXml()
        {
            string filePath = "Files/products.xml";

            string xmlString = File.ReadAllText(filePath);

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var categoryProducts = new List<CategoryProduct>();

            using (var context = new ProductsShopContext())
            {

                var userIds = context.Users
                    .Select(u => u.Id)
                    .ToArray();

                var categoryIds = context.Categories
                    .Select(c => c.Id)
                    .ToArray();

                var rnd = new Random();

                foreach (var e in elements)
                {
                    string name = e.Element("name").Value;
                    decimal price = decimal.Parse(e.Element("price").Value);

                    int sellerIndex = rnd.Next(0, userIds.Length);
                    int sellerId = userIds[sellerIndex];

                    //20% of buyers are null
                    int buyerIndex = rnd.Next(0, (int)(userIds.Length * 1.2));

                    int? buyerId = null;
                    if (buyerIndex < userIds.Length)
                    {
                        buyerId = userIds[sellerIndex];
                    }

                    var product = new Product()
                    {
                        Name =  name,
                        Price = price,
                        SellerId = sellerId,
                        BuyerId = buyerId
                    };

                    int categoryIndex = rnd.Next(0, categoryIds.Length);
                    int categoryId = categoryIds[categoryIndex];

                    var catProduct = new CategoryProduct()
                    {
                        Product = product,
                        CategotyId = categoryId
                    };

                    categoryProducts.Add(catProduct);
                }

                context.CategoriesProducts.AddRange(categoryProducts);

                context.SaveChanges();
            }

            return $"{categoryProducts.Count()} products were imported from file: {filePath}";
        }
        
        static void ProductsInRangeXML()
        {
            using (var context = new ProductsShopContext())
            {
                var products = context.Products
                    .Where(p => (p.Price >= 1000 && p.Price <= 2000) && p.BuyerId != null)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                    })
                    .ToArray();

                var xDoc = new XDocument(
                    new XElement("products")
                    );

                foreach (var p in products)
                {
                    xDoc.Root.Add(
                        new XElement("product",
                            new XAttribute("name", p.name),
                            new XAttribute("price", p.price),
                            new XAttribute("buyer", p.buyer)
                        ));
                }
                
                var xmlString = xDoc.ToString();

                File.WriteAllText("XML/products-in-range.xml", xmlString);
            }
        }
        static void SoldProductsXML()
        {
            using(var context = new ProductsShopContext())
            {
                var users = context.Users
                    .Where(u => u.SoldProducts.Count() > 0)
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        soldProducts = u.SoldProducts
                            .Select(sp => new
                            {
                                name = sp.Name,
                                price = sp.Price
                            })
                    })
                    .ToArray();

                var xDoc = new XDocument(new XElement("users"));

                foreach (var u in users)
                {
                    var user = new XElement("user",
                            new XAttribute("first-name", u.firstName ?? ""),
                            new XAttribute("last-name", u.lastName),
                            new XElement("sold-products"));

                    foreach (var product in u.soldProducts)
                    {
                        user.Element("sold-products")
                            .Add(new XElement("product",
                                new XElement("name", product.name),
                                new XElement("price", product.price)
                            ));
                    }

                    xDoc.Root.Add(user);
                }

                var xmlString = xDoc.ToString();

                File.WriteAllText("XML/users-sold-products.xml", xmlString);
            }
        }
        static void CategoriesByProductsCountXML()
        {
            using (var context = new ProductsShopContext())
            {
                var categories = context.Categories
                    .OrderBy(c => c.Products.Count())
                    .Select(c => new
                    {
                        name = c.Name,
                        productsCount = c.Products.Count(),
                        averagePrice = c.Products.Average(p => p.Product.Price),
                        totalRevenue = c.Products.Sum(p => p.Product.Price)
                    })
                    .ToArray();

                var xDoc = new XDocument(new XElement("categories"));

                foreach (var c in categories)
                {
                    var category = new XElement("category", new XAttribute("name", c.name));

                    category.Add(
                        new XElement("products-count", c.productsCount),
                        new XElement("average-price", c.averagePrice),
                        new XElement("total-revenue", c.totalRevenue)
                        );

                    xDoc.Root.Add(category);
                }

                File.WriteAllText("XML/categories-by-products.xml", xDoc.ToString());
            }
        }
        static void UsersAndProductsXML()
        {
            using (var context = new ProductsShopContext())
            {
                var users = context.Users
                    .Where(u => u.SoldProducts.Count() > 0)
                    .OrderByDescending(p => p.SoldProducts.Count())
                    .ThenBy(p => p.LastName)
                    .Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        u.Age,
                        products = u.SoldProducts
                            .Select(p => new
                            {
                                p.Name,
                                p.Price
                            })
                    })
                    .ToArray();

                var xDoc = new XDocument(new XElement("users"));

                var root = xDoc.Root;
                root.Add(new XAttribute("count", users.Length));

                foreach (var u in users)
                {
                    var user = new XElement("user");

                    if (u.FirstName != null)
                    {
                        user.Add(new XAttribute("first-name", u.FirstName));
                    }

                    user.Add(new XAttribute("last-name", u.LastName));

                    if (u.Age != null)
                    {
                        user.Add(new XAttribute("age", u.Age));
                    }

                    var products = new XElement("sold-products",
                            new XAttribute("count", u.products.Count())
                        );

                    foreach (var p in u.products)
                    {
                        products.Add(new XElement("product",
                                new XAttribute("name", p.Name),
                                new XAttribute("price", p.Price)
                            ));
                    }

                    user.Add(products);

                    root.Add(user);
                }

                File.WriteAllText("XML/users-and-products.xml", xDoc.ToString());
            }
        }
        
        //Json
        static void GetProdictsInRangeJSON()
        {
            using (var context = new ProductsShopContext())
            {
                var products = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                    })
                    .ToArray();

                var jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);

                File.WriteAllText("JSON/PricesInRange.json", jsonString);
            }
        }
        static void SuccessfullySoldProductsJSON()
        {
            using (var context = new ProductsShopContext())
            {
                var users = context.Users
                    .Where(u => u.SoldProducts.Count() >= 1)
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        soldProducts = u.SoldProducts
                            .Select(sp => new
                            {
                                name = sp.Name,
                                price = sp.Price,
                                buyerFirstName = sp.Buyer.FirstName,
                                buyerLastName = sp.Buyer.LastName
                            })
                    })
                    .ToArray();

                var jsonString = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

                File.WriteAllText("JSON/SuccessfullySoldProducts.json", jsonString);
            }
        }
        static void CategoriesByProductsCountJSON()
        {
            using (var context = new ProductsShopContext())
            {
                var categories = context.Categories
                    .OrderBy(c => c.Name)
                    .Select(c => new
                    {
                        category = c.Name,
                        productsCount = c.Products.Count(),
                        averagePrice = c.Products.Average(p => p.Product.Price),
                        totalRevenue = c.Products.Sum(p => p.Product.Price)
                    });

                string jsonString = JsonConvert.SerializeObject(categories, Formatting.Indented);

                File.WriteAllText("JSON/categories-by-products.json", jsonString);
            }
        }
        static void UsersAndProductsJSON()
        {
            using (var context = new ProductsShopContext())
            {
                //Get all users who have at least 1 sold product
                var users = context.Users
                        .Where(u => u.SoldProducts.Count() > 0)
                        .OrderByDescending(u => u.SoldProducts.Count())
                        .ThenBy(u => u.LastName)
                        .Select(u => new
                        {
                            firstName = u.FirstName,
                            lastName = u.LastName,
                            age = u.Age,
                            soldProducts = new
                            {
                                count = u.SoldProducts.Count(),
                                products = u.SoldProducts
                                    .Select(sp => new
                                    {
                                        name = sp.Name,
                                        price = sp.Price
                                    })
                            }
                        })
                        .ToArray();

                var usersWithCount = new
                {
                    usersCount = users.Count(),
                    users = users
                };

                var jsonString = JsonConvert.SerializeObject(usersWithCount, Formatting.Indented);

                File.WriteAllText("JSON/users-and-products.json", jsonString);
            }
        }

        static string ImportUsersFromJson()
        {
            string filePath = "Files/users.json";

            User[] users = ImportJson<User>(filePath);

            using (var context = new ProductsShopContext())
            {
                context.Users
                    .AddRange(users);

                context.SaveChanges();
            }

            return $"{users.Length} users were imported from file: {filePath}";
        }
        static string ImportCategoriesFromJson()
        {
            string filePath = "Files/categories.json";

            Category[] categories = ImportJson<Category>(filePath);

            using (var context = new ProductsShopContext())
            {
                context.Categories.AddRange(categories);

                context.SaveChanges();
            }

            return $"{categories.Length} categories were imported from file: {filePath}";
        }
        static string ImportProductsFromJson()
        {
            string filePath = "Files/products.json";

            var rnd = new Random();

            Product[] products = ImportJson<Product>(filePath);

            using (var context = new ProductsShopContext())
            {
                int[] userIds = context.Users
                    .Select(u => u.Id)
                    .ToArray();

                foreach (var p in products)
                {
                    int index = rnd.Next(0, userIds.Length);
                    int sellerId = userIds[index];

                    int? buyerId = sellerId;
                    while (buyerId == sellerId)
                    {
                        int buyerIndex = rnd.Next(0, userIds.Length);
                        buyerId = userIds[buyerIndex];
                    }

                    if (buyerId - sellerId < 5 && buyerId - sellerId > 0)
                    {
                        buyerId = null;
                    }

                    p.SellerId = sellerId;
                    p.BuyerId = buyerId;
                }

                context.Products.AddRange(products);

                context.SaveChanges();
            }

            return $"{products.Length} products were imported from file: {filePath}";
        }
        static string SetCategoriesJSON()
        {
            using(var context = new ProductsShopContext())
            {
                var productIds = context.Products.Select(p => p.Id).ToArray();
                var categoryIds = context.Categories.Select(c => c.Id).ToArray();

                Random rnd = new Random();

                var categoriesProducts = new List<CategoryProduct>();

                foreach (var p in productIds)
                {
                    var categoryIndexes = new int[3].Select(ci => ci = -1).ToArray();

                    for (int i = 0; i < 3; i++)
                    {
                        int categoryIndex = rnd.Next(0, categoryIds.Length);

                        while(categoryIndexes.Contains(categoryIndex))
                        {
                            categoryIndex = rnd.Next(0, categoryIds.Length);
                        }
                        categoryIndexes[i] = categoryIndex;

                        var categoryProduct = new CategoryProduct()
                        {
                            CategotyId = categoryIds[categoryIndex],
                            ProductId = p
                        };

                        categoriesProducts.Add(categoryProduct);
                    }
                }

                context.CategoriesProducts.AddRange(categoriesProducts);

                context.SaveChanges();

                return $"{categoriesProducts.Count()} categorysProducts were imported.";
            }

        }

        static T[] ImportJson<T>(string path)
        {
            string jsonString = File.ReadAllText(path);

            T[] objects = JsonConvert.DeserializeObject<T[]>(jsonString);

            return objects;
        }
    }
}
