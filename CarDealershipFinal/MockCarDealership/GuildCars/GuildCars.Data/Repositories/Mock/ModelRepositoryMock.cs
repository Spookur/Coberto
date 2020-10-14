using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.Repositories.Mock
{
    public class ModelRepositoryMock : IModelRepository
    {
        private static List<Model> _models = new List<Model>();

        private static Model Rogue = new Model
        {
            ModelId = 1,
            MakeId = 1,
            ModelName = "Rogue",
            DateAdded = new DateTime(2021, 1, 1),
            Addedby = "admin3@test.com"
        };

        private static Model Acadia = new Model
        {
            MakeId = 2,
            ModelId = 2,
            ModelName = "Acadia",
            DateAdded = new DateTime(2021, 1, 1),
            Addedby = "admin3@test.com"
        };

        private static Model Mustang = new Model
        {
            MakeId = 3,
            ModelId = 3,
            ModelName = "Mustang",
            DateAdded = new DateTime(2020, 1, 1),
            Addedby = "admin3@test.com"
        };

        private static Model Malibu = new Model
        {
            MakeId = 4,
            ModelId = 4,
            ModelName = "Malibu",
            DateAdded = new DateTime(2020, 1, 1),
            Addedby = "admin3@test.com"
        };

        private static Model Vehicle = new Model
        {
            MakeId = 5,
            ModelId = 5,
            ModelName = "Vehicle",
            DateAdded = new DateTime(2009, 5, 1),
            Addedby = "admin3@test.com"
        };

        public ModelRepositoryMock()
        {
            if (_models.Count() == 0)
            {
                _models.Add(Rogue);
                _models.Add(Acadia);
                _models.Add(Mustang);
                _models.Add(Malibu);
                _models.Add(Vehicle);
            }
        }

        public void ClearModelsList()
        {
            _models.Clear();
        }

        public IEnumerable<Model> GetAll()
        {
            return _models;
        }

        public Model GetModelById(int ModelId)
        {
            return _models.FirstOrDefault(m => m.ModelId == ModelId);
        }

        public List<Model> GetModelsByMakeId(int MakeId)
        {
            return _models.FindAll(m => m.MakeId == MakeId);
        }

        public void Insert(Model Model)
        {
            Model.ModelId = _models.Max(m => m.ModelId) + 1;

            _models.Add(Model);
        }
    }
}
