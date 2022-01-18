using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;

namespace Shop.Data
{
    public class DbObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
                content.Car.AddRange(
                    new Car
                    {
                        name = "Tesla",
                        shortDesc = "Fast car",
                        longDesc = "The Model 3 is an electric fastback mid-size four-door sedan developed by Tesla",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        isFavorite = true,
                        available = true,
                        Category = Categories["Electric cars"]
                    },
                new Car
                {
                    name = "Ford Fiesta",
                    shortDesc = "Quiet and calm car",
                    longDesc = "The Ford Fiesta is a supermini marketed by Ford since 1976 over seven generations.",
                    img = "/img/fordfiesta.jpg",
                    price = 11000,
                    isFavorite = true,
                    available = true,
                    Category = Categories["Classic cars"]
                },
                new Car
                {
                    name = "BMW M3",
                    shortDesc = "Bold and stylish",
                    longDesc = "The BMW M3 is a high-performance version of the BMW 3 Series, developed by BMW's in-house motorsport division, BMW M GmbH. ",
                    img = "/img/bmwm3.jpg",
                    price = 65000,
                    isFavorite = false,
                    available = true,
                    Category = Categories["Classic cars"]
                });
            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories { 
            get {
                if(category ==null) {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Electric cars", desc = "A modern type of transport" },
                        new Category { categoryName = "Classic cars", desc = "Machines with internal combustion engine" }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }

                return category;
            }
        }
    }
}
