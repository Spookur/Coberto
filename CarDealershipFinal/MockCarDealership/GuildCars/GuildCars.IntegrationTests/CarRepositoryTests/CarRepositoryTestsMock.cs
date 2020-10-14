using GuildCars.Data.Repositories.Mock;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.IntegrationTests.CarRepositoryTests
{
    [TestFixture]
    public class CarRepositoryTestsMock
    {
        CarsRepositoryMock repo;

        [SetUp]
        public void Init()
        {
            repo = new CarsRepositoryMock();
        }

        [TearDown]
        public void ResetRepo()
        {
            repo.CarsClearList();
        }

        [Test]
        public void CanGetCarById()
        {
            CarsRepositoryMock repo = new CarsRepositoryMock();
            Car car = repo.GetCarById(2);

            Assert.IsNotNull(car);

            Assert.AreEqual("2ABC2ABC2ABC2ABC2", car.VIN);
            Assert.AreEqual(2, car.CarId);
            Assert.AreEqual(new DateTime(2021, 1, 1), car.ModelYear);
            Assert.IsTrue(car.IsNew);
            Assert.IsFalse(car.IsSold);
            Assert.IsTrue(car.IsFeatured);
            Assert.AreEqual(5, car.UnitsInStock);
            Assert.AreEqual("200", car.Mileage);
            Assert.AreEqual(2, car.BodyColorId);
            Assert.AreEqual(3, car.BodyStyleId);
            Assert.AreEqual(1, car.TransmissionId);
            Assert.AreEqual(2, car.MakeId);
            Assert.AreEqual(2, car.ModelId);
            Assert.AreEqual(4, car.InteriorColorId);
            Assert.AreEqual(33000.00m, car.SalePrice);
            Assert.AreEqual(34150.00m, car.MSRP);
            Assert.AreEqual("/Images/2021GMCAcadia.jpg", car.IMGFilePath);
            Assert.AreEqual("Reliable. Dependable.", car.VehicleDetails);
        }

        [Test]
        public void CanGetAllCars()
        {
            CarsRepositoryMock repo = new CarsRepositoryMock();
            List<Car> cars = repo.GetAllCars().ToList();

            Assert.AreEqual(11, cars.Count);

            Assert.AreEqual("2ABC2ABC2ABC2ABC2", cars[1].VIN);
            Assert.AreEqual(2, cars[1].CarId);
            Assert.AreEqual(new DateTime(2021, 1, 1), cars[1].ModelYear);
            Assert.IsTrue(cars[1].IsNew);
            Assert.IsFalse(cars[1].IsSold);
            Assert.IsTrue(cars[1].IsFeatured);
            Assert.AreEqual(5, cars[1].UnitsInStock);
            Assert.AreEqual("200", cars[1].Mileage);
            Assert.AreEqual(2, cars[1].BodyColorId);
            Assert.AreEqual(3, cars[1].BodyStyleId);
            Assert.AreEqual(1, cars[1].TransmissionId);
            Assert.AreEqual(2, cars[1].MakeId);
            Assert.AreEqual(2, cars[1].ModelId);
            Assert.AreEqual(4, cars[1].InteriorColorId);
            Assert.AreEqual(33000.00m, cars[1].SalePrice);
            Assert.AreEqual(34150.00m, cars[1].MSRP);
            Assert.AreEqual("/Images/2021GMCAcadia.jpg", cars[1].IMGFilePath);
            Assert.AreEqual("Reliable. Dependable.", cars[1].VehicleDetails);
        }

        [Test]
        public void CanGetFeaturedCars()
        {
            CarsRepositoryMock repo = new CarsRepositoryMock();

            List<FeaturedShortListItem> featuredCars = repo.GetAllFeaturedCars().ToList();

            Assert.AreEqual(6, featuredCars.Count);

            Assert.AreEqual(2, featuredCars[0].CarId);
            Assert.AreEqual(new DateTime(2021, 1, 1), featuredCars[0].Year);
            Assert.AreEqual(2, featuredCars[0].MakeId);
            Assert.AreEqual(2, featuredCars[0].ModelId);
            Assert.AreEqual(33000.00m, featuredCars[0].Price);
            Assert.AreEqual("/Images/2021GMCAcadia.jpg", featuredCars[0].ImageURL);
            Assert.AreEqual("GMC", featuredCars[0].Make);
            Assert.AreEqual("Acadia", featuredCars[0].Model);
        }

        [Test]
        public void CanGetNewCars()
        {
            CarsRepositoryMock repo = new CarsRepositoryMock();
            List<Car> cars = repo.GetAllNewCars().ToList();

            Assert.AreEqual(6, cars.Count);

            Assert.AreEqual("2ABC2ABC2ABC2ABC2", cars[1].VIN);
            Assert.AreEqual(2, cars[1].CarId);
            Assert.AreEqual(new DateTime(2021, 1, 1), cars[1].ModelYear);
            Assert.IsTrue(cars[1].IsNew);
            Assert.IsFalse(cars[1].IsSold);
            Assert.IsTrue(cars[1].IsFeatured);
            Assert.AreEqual(5, cars[1].UnitsInStock);
            Assert.AreEqual("200", cars[1].Mileage);
            Assert.AreEqual(2, cars[1].BodyColorId);
            Assert.AreEqual(3, cars[1].BodyStyleId);
            Assert.AreEqual(1, cars[1].TransmissionId);
            Assert.AreEqual(4, cars[2].MakeId);
            Assert.AreEqual(4, cars[2].ModelId);
            Assert.AreEqual(4, cars[1].InteriorColorId);
            Assert.AreEqual(33000.00m, cars[1].SalePrice);
            Assert.AreEqual(34150.00m, cars[1].MSRP);
            Assert.AreEqual("/Images/2021GMCAcadia.jpg", cars[1].IMGFilePath);
            Assert.AreEqual("Reliable. Dependable.", cars[1].VehicleDetails);
        }

        [Test]
        public void CanGetUsedCars()
        {
            CarsRepositoryMock repo = new CarsRepositoryMock();
            List<Car> cars = repo.GetAllUsedCars().ToList();

            Assert.AreEqual(5, cars.Count);

            Assert.AreEqual("5ABC5ABC5ABC5ABC5", cars[1].VIN);
            Assert.AreEqual(5, cars[1].CarId);
            Assert.AreEqual(new DateTime(2020, 1, 1), cars[1].ModelYear);
            Assert.IsFalse(cars[1].IsNew);
            Assert.IsFalse(cars[1].IsSold);
            Assert.IsFalse(cars[1].IsFeatured);
            Assert.AreEqual(2, cars[1].UnitsInStock);
            Assert.AreEqual("1000", cars[1].Mileage);
            Assert.AreEqual(1, cars[1].BodyColorId);
            Assert.AreEqual(1, cars[1].BodyStyleId);
            Assert.AreEqual(1, cars[1].TransmissionId);
            Assert.AreEqual(5, cars[1].MakeId);
            Assert.AreEqual(5, cars[1].ModelId);
            Assert.AreEqual(2, cars[1].InteriorColorId);
            Assert.AreEqual(1800.00m, cars[1].SalePrice);
            Assert.AreEqual(2000.00m, cars[1].MSRP);
            Assert.AreEqual("/Images/MockUsedCar.png", cars[1].IMGFilePath);
            Assert.AreEqual("Mock Used Car Number: 5", cars[1].VehicleDetails);
        }

        [Test]
        public void CanGetUnsoldCars()
        {
            CarsRepositoryMock repo = new CarsRepositoryMock();
            List<Car> cars = repo.GetAllUnsoldCars().ToList();

            Assert.AreEqual(10, cars.Count);

            Assert.AreEqual("3ABC3ABC3ABC3ABC3", cars[1].VIN);
            Assert.AreEqual(3, cars[1].CarId);
            Assert.AreEqual(new DateTime(2020, 1, 1), cars[1].ModelYear);
            Assert.IsFalse(cars[1].IsNew);
            Assert.IsFalse(cars[1].IsSold);
            Assert.IsTrue(cars[1].IsFeatured);
            Assert.AreEqual(1, cars[1].UnitsInStock);
            Assert.AreEqual("1200", cars[1].Mileage);
            Assert.AreEqual(3, cars[1].BodyColorId);
            Assert.AreEqual(2, cars[1].BodyStyleId);
            Assert.AreEqual(2, cars[1].TransmissionId);
            Assert.AreEqual(3, cars[1].MakeId);
            Assert.AreEqual(3, cars[1].ModelId);
            Assert.AreEqual(1, cars[1].InteriorColorId);
            Assert.AreEqual(222669.00m, cars[1].SalePrice);
            Assert.AreEqual(245000.00m, cars[1].MSRP);
            Assert.AreEqual("/Images/2020FordMustang.jpg", cars[1].IMGFilePath);
            Assert.AreEqual("Car goes fast.", cars[1].VehicleDetails);
        }

        [Test]
        public void CanGetSoldCars()
        {
            CarsRepositoryMock repo = new CarsRepositoryMock();
            List<Car> cars = repo.GetAllSoldCars().ToList();

            Assert.AreEqual(1, cars.Count);

            Assert.AreEqual("1ABC1ABC1ABC1ABC1", cars[0].VIN);
            Assert.AreEqual(1, cars[0].CarId);
            Assert.AreEqual(new DateTime(2021, 1, 1), cars[0].ModelYear);
            Assert.IsTrue(cars[0].IsNew);
            Assert.IsTrue(cars[0].IsSold);
            Assert.IsFalse(cars[0].IsFeatured);
            Assert.AreEqual(3, cars[0].UnitsInStock);
            Assert.AreEqual("0", cars[0].Mileage);
            Assert.AreEqual(2, cars[0].BodyColorId);
            Assert.AreEqual(3, cars[0].BodyStyleId);
            Assert.AreEqual(1, cars[0].TransmissionId);
            Assert.AreEqual(1, cars[0].MakeId);
            Assert.AreEqual(1, cars[0].ModelId);
            Assert.AreEqual(2, cars[0].InteriorColorId);
            Assert.AreEqual(50315.00m, cars[0].SalePrice);
            Assert.AreEqual(51815.00m, cars[0].MSRP);
            Assert.AreEqual("/Images/2021NissanRogue.jpg", cars[0].IMGFilePath);
            Assert.AreEqual("Brand new and looks great.", cars[0].VehicleDetails);
        }

        [Test]
        public void CanAddCar()
        {
            Car car = new Car
            {
                ModelYear = new DateTime(2005, 1, 1),
                IsNew = false,
                IsFeatured = true,
                IsSold = false,
                UnitsInStock = 1,
                Mileage = "1200",
                VIN = "20ABC20ABC20ABC20",
                BodyColorId = 3,
                BodyStyleId = 2,
                TransmissionId = 2,
                MakeId = 3,
                ModelId = 3,
                InteriorColorId = 1,
                SalePrice = 2400.00m,
                MSRP = 5000.00m,
                IMGFilePath = "/Images/MockUsedCar.jpg",
                VehicleDetails = "Pretty neat."
            };

            CarsRepositoryMock repo = new CarsRepositoryMock();
            repo.Insert(car);

            List<Car> cars = repo.GetAllCars().ToList();
            Assert.AreEqual(12, cars.Count);

            Assert.AreEqual(12, cars[11].CarId);
            Assert.AreEqual(car.ModelYear, cars[11].ModelYear);
            Assert.AreEqual(car.IsNew, cars[11].IsNew);
            Assert.AreEqual(car.IsFeatured, cars[11].IsFeatured);
            Assert.AreEqual(car.IsSold, cars[11].IsSold);
            Assert.AreEqual(car.UnitsInStock, cars[11].UnitsInStock);
            Assert.AreEqual(car.Mileage, cars[11].Mileage);
            Assert.AreEqual(car.VIN, cars[11].VIN);
            Assert.AreEqual(car.BodyColorId, cars[11].BodyColorId);
            Assert.AreEqual(car.BodyStyleId, cars[11].BodyStyleId);
            Assert.AreEqual(car.TransmissionId, cars[11].TransmissionId);
            Assert.AreEqual(car.MakeId, cars[11].MakeId);
            Assert.AreEqual(car.ModelId, cars[11].ModelId);
            Assert.AreEqual(car.InteriorColorId, cars[11].InteriorColorId);
            Assert.AreEqual(car.SalePrice, cars[11].SalePrice);
            Assert.AreEqual(car.MSRP, cars[11].MSRP);
            Assert.AreEqual(car.IMGFilePath, cars[11].IMGFilePath);
            Assert.AreEqual(car.VehicleDetails, cars[11].VehicleDetails);

        }

        [Test]
        public void CanDeleteCar()
        {
            Car car = new Car
            {
                ModelYear = new DateTime(2015, 1, 1),
                IsNew = false,
                IsFeatured = true,
                IsSold = false,
                UnitsInStock = 1,
                Mileage = "20000",
                VIN = "5ABC5ABC5ABC5ABC5",
                BodyColorId = 5,
                BodyStyleId = 3,
                TransmissionId = 2,
                MakeId = 3,
                ModelId = 2,
                InteriorColorId = 5,
                SalePrice = 19500m,
                MSRP = 21000m,
                IMGFilePath = "Images/placeholder.png",
                VehicleDetails = "2015 Ford Escape."
            };

            CarsRepositoryMock repo = new CarsRepositoryMock();

            repo.Insert(car);

            var newCar = repo.GetCarById(5);

            Assert.IsNotNull(newCar);

            repo.Delete(5);

            newCar = repo.GetCarById(5);

            Assert.IsNull(newCar);

        }

        [Test]
        public void CanUpdateCar()
        {
            Car car = new Car
            {
                ModelYear = new DateTime(2015, 1, 1),
                IsNew = false,
                IsFeatured = true,
                IsSold = false,
                UnitsInStock = 1,
                Mileage = "20000",
                VIN = "5ABC5ABC5ABC5ABC5",
                BodyColorId = 5,
                BodyStyleId = 3,
                TransmissionId = 2,
                MakeId = 3,
                ModelId = 2,
                InteriorColorId = 5,
                SalePrice = 19500m,
                MSRP = 21000m,
                IMGFilePath = "Images/placeholder.png",
                VehicleDetails = "2015 Ford Escape."
            };

            CarsRepositoryMock repo = new CarsRepositoryMock();

            repo.Insert(car);

            car.BodyColorId = 2;
            car.InteriorColorId = 5;
            car.SalePrice = 17500m;
            car.MSRP = 19200m;
            car.IMGFilePath = "Images/updatedImage.png";
            car.IsSold = true;
            car.IsNew = true;
            car.IsFeatured = true;
            car.VIN = "6ABC6ABC6ABC6ABC6";
            car.VehicleDetails = "Updated";
            car.Mileage = "40000";
            car.ModelYear = new DateTime(2018, 1, 1);
            car.MakeId = 2;
            car.ModelId = 3;
            car.TransmissionId = 1;
            car.UnitsInStock = 9;
            car.BodyStyleId = 2;

            repo.Update(car);

            var updatedCar = repo.GetCarById(12);

            Assert.AreEqual(updatedCar.BodyStyleId, 2);
            Assert.AreEqual(updatedCar.BodyColorId, 2);
            Assert.AreEqual(updatedCar.InteriorColorId, 5);
            Assert.AreEqual(updatedCar.IMGFilePath, "Images/updatedImage.png");
            Assert.AreEqual(updatedCar.SalePrice, 17500m);
            Assert.AreEqual(updatedCar.MSRP, 19200m);
            Assert.AreEqual(updatedCar.IsNew, true);
            Assert.AreEqual(updatedCar.IsFeatured, true);
            Assert.AreEqual(updatedCar.IsSold, true);
            Assert.AreEqual(updatedCar.VIN, "6ABC6ABC6ABC6ABC6");
            Assert.AreEqual(updatedCar.VehicleDetails, "Updated");
            Assert.AreEqual(updatedCar.Mileage, "40000");
            Assert.AreEqual(updatedCar.ModelYear, new DateTime(2018, 1, 1));
            Assert.AreEqual(updatedCar.MakeId, 2);
            Assert.AreEqual(updatedCar.ModelId, 3);
            Assert.AreEqual(updatedCar.TransmissionId, 1);
            Assert.AreEqual(updatedCar.UnitsInStock, 8);
        }
    }
}

