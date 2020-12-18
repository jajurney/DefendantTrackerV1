using DefendantTracker.Data;
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
        private readonly Guid _defenseID;
        public DefenseAttorneyService(Guid defenseID)
        {
            _defenseID = defenseID;
        }
        public bool CreateDefenseAttorney(DefenseAttorneyCreate model)
        {
            var entity = new DefenseAttorney()
            {
                DefenseAttorneyID = _defenseID,
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
                        .Where(e => e.DefenseAttorneyID == _defenseID)
                        .Select(
                            e =>
                            new DefenseAttorneyListItem
                            {
                                DefenseAttorneyID = _defenseID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                FullName = e.FullName
                            }
                    );
                return query.ToArray();
            }
        }
        public DefenseAttorneyDetails GetDefenseAttorneysById(Guid id)
        {
            using (var dfa = new ApplicationDbContext())
            {
                var entity = dfa
                    .DefenseAttorneys
                    .Single(e => e.DefenseAttorneyID == _defenseID);
                return
                    new DefenseAttorneyDetails
                    {
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        FullName = entity.FullName
                    };
            }
        }
        public bool UpdateDefenseAttorney(DefenseAttorneyEdit model)
        {
            using (var dft = new ApplicationDbContext())
            {
                var entity =
                    dft
                    .DefenseAttorneys
                    .Single(e => e.DefenseAttorneyID == _defenseID);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                return dft.SaveChanges() == 1;
            }
        }
        public bool DeleteDefenseAttorney (Guid id)
        {
            using (var dfa = new ApplicationDbContext())
            {
                var entity =
                    dfa
                        .DefenseAttorneys
                        .Single(e => e.DefenseAttorneyID == _defenseID);
                dfa.DefenseAttorneys.Remove(entity);
                return dfa.SaveChanges() == 1;
            }
        }
    }
}
