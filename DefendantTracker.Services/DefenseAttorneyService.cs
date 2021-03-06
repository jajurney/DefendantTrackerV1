﻿using DefendantTracker.Data;
using DefendantTracker.Models.DefenseAttorneyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Services
{
    public class DefenseAttorneyService
    {
        private readonly Guid _userID;
        public DefenseAttorneyService(Guid userID)
        {
           _userID = userID;
        }
        public bool CreateDefenseAttorney(DefenseAttorneyCreate model)
        {
            var entity = new DefenseAttorney()
            {
                DefenseAttorneyID = model.DefenseAttorneyID,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            using (var dfa = new ApplicationDbContext())
            {
                dfa.DefenseAttorneys.Add(entity);
                return dfa.SaveChanges() == 1;
            }
        }
        public IEnumerable<DefenseAttorneyListItem> GetDefenseAttorneys()
        {
            using (var dft = new ApplicationDbContext())
            {
                var query = dft
                        .DefenseAttorneys
                        .Select(
                            e =>
                            new DefenseAttorneyListItem
                            {
                                DefenseAttorneyID = e.DefenseAttorneyID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                FullName = e.DAFullName
                            }
                    );
                return query.ToArray();
            }
        }
        public DefenseAttorneyDetails GetDefenseAttorneysById(int id)
        {
            using (var dfa = new ApplicationDbContext())
            {
                var entity = dfa
                    .DefenseAttorneys
                    .Single(e => e.DefenseAttorneyID == id);
                return
                    new DefenseAttorneyDetails
                    {
                        DefenseAttorneyID = entity.DefenseAttorneyID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        FullName = entity.DAFullName
                    };
            }
        }
        public bool UpdateDefenseAttorney(int id, DefenseAttorneyEdit model)
        {
            using (var dft = new ApplicationDbContext())
            {
                var entity =
                    dft
                    .DefenseAttorneys
                    .Single(e => e.DefenseAttorneyID == id);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                return dft.SaveChanges() == 1;
            }
        }
        public bool DeleteDefenseAttorney(int id)
        {
            using (var dfa = new ApplicationDbContext())
            {
                var entity =
                    dfa
                        .DefenseAttorneys
                        .Single(e => e.DefenseAttorneyID == id);
                dfa.DefenseAttorneys.Remove(entity);
                return dfa.SaveChanges() == 1;
            }
        }
    }
}
