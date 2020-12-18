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
        private readonly Guid _stateID;
        public StateAttorneyService(Guid stateID)
        {
            _stateID = stateID;
        }
        public bool CreateStateAttorney(StateAttorneyCreate model)
        {
            var entity = new StateAttorney()
            {
                StateAttorneyID = _stateID,
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
                        .Where(e => e.StateAttorneyID == _stateID)
                        .Select(
                            e =>
                            new StateAttorneyListItem
                            {
                                StateAttorneyID = _stateID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                FullName = e.FullName
                            }
                    );
                return query.ToArray();
            }
        }
        public StateAttorneyDetails GetStateAttorneysById(Guid id)
        {
            using (var sat = new ApplicationDbContext())
            {
                var entity = sat
                    .StateAttorneys
                    .Single(e => e.StateAttorneyID == _stateID);
                return
                    new StateAttorneyDetails
                    {
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        FullName = entity.FullName
                    };
            }
        }
        public bool UpdateStateAttorney(StateAttorneyEdit model)
        {
            using (var sat = new ApplicationDbContext())
            {
                var entity =
                    sat
                    .StateAttorneys
                    .Single(e => e.StateAttorneyID == _stateID);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                return sat.SaveChanges() == 1;
            }
        }
        public bool DeleteStateAttorney(Guid id)
        {
            using (var sat = new ApplicationDbContext())
            {
                var entity =
                    sat
                        .StateAttorneys
                        .Single(e => e.StateAttorneyID == _stateID);
                sat.StateAttorneys.Remove(entity);
                return sat.SaveChanges() == 1;
            }
        }
    }
}
