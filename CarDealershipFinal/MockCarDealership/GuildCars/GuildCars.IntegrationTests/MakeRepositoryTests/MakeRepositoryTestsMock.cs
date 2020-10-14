﻿using GuildCars.Data.Repositories.Mock;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.IntegrationTests.MakeRepositoryTests
{
    [TestFixture]
    public class MakeRepositoryTestsMock
    {

        MakeRepositoryMock repo;

        [SetUp]
        public void Init()
        {
            repo = new MakeRepositoryMock();
        }

        [TearDown]
        public void ResetRepo()
        {
            repo.ClearMakesList();
        }

        [Test]
        public void CanGetAllMakes()
        {
            MakeRepositoryMock repo = new MakeRepositoryMock();

            List<Make> Makes = repo.GetAll().ToList();

            Assert.AreEqual(5, Makes.Count);

            Assert.AreEqual(Makes[2].MakeId, 3.ToString());
            Assert.AreEqual(Makes[2].MakeName, "Ford");
            Assert.AreEqual(Makes[2].DateAdded, new DateTime(2020, 1, 1));
        }

        [Test]
        public void CanGetMakeById()
        {
            MakeRepositoryMock repo = new MakeRepositoryMock();

            Make make = repo.GetMakeById(1);

            Assert.IsNotNull(make);

            Assert.AreEqual(1, make.MakeId);


        }

        [Test]
        public void CanAddMake()
        {
            Make make = new Make
            {
                MakeName = "TestMake",
                DateAdded = DateTime.Now.Date,
                AddedBy = "TestUser"

            };

            MakeRepositoryMock repo = new MakeRepositoryMock();
            repo.Insert(make);

            List<Make> makes = repo.GetAll().ToList();
            Assert.AreEqual(6, makes.Count);

            Assert.AreEqual("6", makes[5].MakeId);
            Assert.AreEqual(make.MakeName, makes[5].MakeName);
            Assert.AreEqual(make.DateAdded, makes[5].DateAdded);
            Assert.AreEqual(make.AddedBy, makes[5].AddedBy);

        }
    }
}