using DefendantTracker.Data;
using DefendantTracker.Models.DefendantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Services
{
    public class DefendantService
    {
        private readonly Guid _userID;
        public DefendantService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateDefendant(DefendantCreate model)
        {
            var entity = new Defendant()
            {
                DefendantID = model.DefendantID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                StreetAddress = model.StreetAddress,
                City = model.City,
                County = model.County,
                State = model.State,
                Zipcode = model.Zipcode,
                Prosecuted = model.Prosecuted,
                Arrested = model.Arrested
            };
            using (var dft = new ApplicationDbContext())
            {
                dft.Defendants.Add(entity);
                return dft.SaveChanges() == 1;
            }
        }
        public IEnumerable<DefendantListItem> GetDefendants()
        {
            using (var dft = new ApplicationDbContext())
            {
                var query = dft
                        .Defendants
                        .Select(
                            e =>
                            new DefendantListItem
                            {
                                DefendantID = e.DefendantID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                StreetAddress = e.StreetAddress,
                                City = e.City,
                                County = e.County,
                                State = e.State,
                                Zipcode = e.Zipcode,
                                Prosecuted = e.Prosecuted,
                                Arrested = e.Arrested
                            }
                    );
                return query.ToArray();
            }
        }
        public DefendantDetails GetDefendantById(int id)
        {
            using (var dft = new ApplicationDbContext())
            {
                var entity = dft
                    .Defendants
                    .Single(e => e.DefendantID == id);
                return
                    new DefendantDetails
                    {
                        DefendantID = entity.DefendantID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        FullName = entity.FullName,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City,
                        County = entity.County,
                        State = entity.State,
                        Zipcode = entity.Zipcode,
                        FullLocation = entity.FullLocation,
                        Arrested = entity.Arrested,
                        Prosecuted = entity.Prosecuted
                    };
            }
        }
        public bool UpdateDefendant(int id, DefendantEdit model)
        {
            using (var dft = new ApplicationDbContext())
            {
                var entity =
                    dft
                    .Defendants
                    .Single(e => e.DefendantID == id);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.County = model.County;
                entity.State = model.State;
                entity.Zipcode = model.Zipcode;
                entity.Arrested = model.Arrested;
                entity.Prosecuted = model.Prosecuted;
                return dft.SaveChanges() == 1;
            }
        }
        public bool DeleteDefendant(int id)
        {
            using (var dft = new ApplicationDbContext())
            {
                var entity =
                    dft
                        .Defendants
                        .Single(e => e.DefendantID == id);
                dft.Defendants.Remove(entity);
                return dft.SaveChanges() == 1;
            }
        }
    }
}
