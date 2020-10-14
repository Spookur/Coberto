using GuildCars.Data.Repositories.ADO;
using GuildCars.Data.Repositories.Mock;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.IntegrationTests.BodyStyleRepositoryTests
{
    [TestFixture]
    public class BodyStyleRepositoryMockTests
    {
        [Test]
        public void CanGetAllBodyStyles()
        {
            BodyStyleRepositoryMock repo = new BodyStyleRepositoryMock();

            List<BodyStyle> BodyStyles = repo.GetAll().ToList();

            Assert.AreEqual(4, BodyStyles.Count);

            Assert.AreEqual(BodyStyles[2].BodyStyleId, 3);
            Assert.AreEqual(BodyStyles[2].BodyStyleType, "SUV");
        }

        [Test]
        public void CanGetBodyStyleById()
        {
            BodyStyleRepositoryMock repo = new BodyStyleRepositoryMock();

            BodyStyle bodyStyle = repo.GetAll().FirstOrDefault(b => b.BodyStyleId == 3);

            Assert.AreEqual(bodyStyle.BodyStyleId, 3);
            Assert.AreEqual(bodyStyle.BodyStyleType, "SUV");
        }
    }
}

