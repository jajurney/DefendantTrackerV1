using DefendantTracker.Data;
using DefendantTracker.Models.StateAttorneyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Services
{
    public class StateAttorneyService
    {
        private readonly Guid _userID;
        public StateAttorneyService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateStateAttorney(StateAttorneyCreate model)
        {
            var entity = new StateAttorney()
            {
                StateAttorneyID = model.StateAttorneyID,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            using (var sat = new ApplicationDbContext())
            {
                sat.StateAttorneys.Add(entity);
                return sat.SaveChanges() == 1;
            }
        }
        public IEnumerable<StateAttorneyListItem> GetStateAttorneys()
        {
            using (var sat = new ApplicationDbContext())
            {
                var query = sat
                        .StateAttorneys
                        .Select(
                            e =>
                            new StateAttorneyListItem
                            {
                                StateAttorneyID = e.StateAttorneyID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                FullName = e.FullName
                            }
                    );
                return query.ToArray();
            }
        }
        public StateAttorneyDetails GetStateAttorneysById(int id)
        {
            using (var sat = new ApplicationDbContext())
            {
                var entity = sat
                    .StateAttorneys
                    .Single(e => e.StateAttorneyID == id);
                return
                    new StateAttorneyDetails
                    {
                        StateAttorneyID = entity.StateAttorneyID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        FullName = entity.FullName
                    };
            }
        }
        public bool UpdateStateAttorney(int id, StateAttorneyEdit model)
        {
            using (var sat = new ApplicationDbContext())
            {
                var entity =
                    sat
                    .StateAttorneys
                    .Single(e => e.StateAttorneyID == id);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                return sat.SaveChanges() == 1;
            }
        }
        public bool DeleteStateAttorney(int id)
        {
            using (var sat = new ApplicationDbContext())
            {
                var entity =
                    sat
                        .StateAttorneys
                        .Single(e => e.StateAttorneyID == id);
                sat.StateAttorneys.Remove(entity);
                return sat.SaveChanges() == 1;
            }
        }
    }
}
