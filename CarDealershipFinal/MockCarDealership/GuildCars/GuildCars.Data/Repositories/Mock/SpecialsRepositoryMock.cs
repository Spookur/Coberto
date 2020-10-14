﻿using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.Repositories.Mock
{
    public class SpecialsRepositoryMock : ISpecialsRepository
    {
        private static List<Special> _specials = new List<Special>();

        private static Special _specialOne = new Special
        {
            SpecialId = 1,
            Title = "$1000 Off Special!",
            SpecialDetails = "$1000 Off any Nissan SUV!"
        };

        private static Special _specialTwo = new Special
        {
            Title = "Free tank of gas!",
            SpecialId = 2,
            SpecialDetails = "Free tank of gas with every purchase!"
        };

        
        private static Special _specialThree = new Special
        {
            Title = "Ford: Free Warranty special!",
            SpecialId = 3,
            SpecialDetails = "Free extended warranty on all Ford models!"
        };

        private static Special _specialFour = new Special
        {
            Title = "New GMC Acadia",
            SpecialId = 4,
            SpecialDetails = "$1000 off any new GMC Acadia!"
        };

        public SpecialsRepositoryMock()
        {
            if(_specials.Count != 0)
            {
                _specials.Clear();
            }

            _specials.Add(_specialOne);
            _specials.Add(_specialTwo);
            _specials.Add(_specialThree);
            _specials.Add(_specialFour);
        }

        public void Delete(int SpecialId)
        {
            Special special = _specials.FirstOrDefault(s => s.SpecialId == SpecialId);

            _specials.Remove(special);
        }

        public IEnumerable<Special> GetAll()
        {
            return _specials;
        }

        public void Insert(Special special)
        {
            special.SpecialId = _specials.Max(s => s.SpecialId) + 1;

            _specials.Add(special);
        }

        public void SpecialsClearList()
        {
            _specials.Clear();
        }
    }
}