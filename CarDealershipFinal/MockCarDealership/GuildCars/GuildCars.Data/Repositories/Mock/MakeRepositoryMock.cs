using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using GuildCars.Models.Tables;

namespace GuildCars.Data.Repositories.Mock
{
    public class MakeRepositoryMock : IMakeRepository
    {
        private static List<Make> _makes = new List<Make>();

        private static Make Nissan = new Make
        {
            MakeId = 1,
            MakeName = "Nissan",
            DateAdded = new DateTime(2021, 1, 1),
            AddedBy = "admin3@test.com"
        };

        private static Make GMC = new Make
        {
            MakeId = 2,
            MakeName = "GMC",
            DateAdded = new DateTime(2021, 7, 2),
            AddedBy = "admin3@test.com"

        };

        private static Make Ford = new Make
        {
            MakeId = 3,
            MakeName = "Ford",
            DateAdded = new DateTime(2020, 1, 1),
            AddedBy = "admin3@test.com"

        };

        private static Make Chevy = new Make
        {
            MakeId = 4,
            MakeName = "Chevy",
            DateAdded = new DateTime(2020, 5, 1),
            AddedBy = "admin3@test.com"

        };

        private static Make Mock = new Make
        {
            MakeId = 5,
            MakeName = "Mock",
            DateAdded = new DateTime(2022, 5, 1),
            AddedBy = "admin3@test.com"

        };

        public MakeRepositoryMock()
        {
            if (_makes.Count() == 0)
            {
                _makes.Add(Nissan);
                _makes.Add(GMC);
                _makes.Add(Ford);
                _makes.Add(Chevy);
                _makes.Add(Mock);
            }
        }

        public void ClearMakesList()
        {
            _makes.Clear();
        }

        public IEnumerable<Make> GetAll()
        {
            return _makes;
        }

        public Make GetMakeById(int MakeId)
        {
            return _makes.FirstOrDefault(m => m.MakeId == MakeId);
        }

        public void Insert(Make make)
        {
            var id = _makes.Max(m => m.MakeId);

            make.MakeId++;

            _makes.Add(make);
        }
    }
}
