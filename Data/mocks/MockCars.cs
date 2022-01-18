using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars { get {
                return new List<Car> {
                new Car { name="Tesla", shortDesc="Fast car",
                    longDesc="The Model 3 is an electric fastback mid-size four-door sedan developed by Tesla",
                    img="/img/tesla.jpg", price=45000, isFavorite=true, available=true,
                    Category=_categoryCars.AllCategories.First() },
                new Car { name="Ford Fiesta", shortDesc="Quiet and calm car",
                    longDesc="The Ford Fiesta is a supermini marketed by Ford since 1976 over seven generations.",
                    img="/img/fordfiesta.jpg", price=11000, isFavorite=true, available=true,
                    Category=_categoryCars.AllCategories.Last() },
                new Car { name="BMW M3", shortDesc="Bold and stylish",
                    longDesc="The BMW M3 is a high-performance version of the BMW 3 Series, developed by BMW's in-house motorsport division, BMW M GmbH. ",
                    img="/img/bmwm3.jpg", price=65000, isFavorite=false, available=true,
                    Category=_categoryCars.AllCategories.Last() }
                };
            } set => throw new NotImplementedException(); }
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
