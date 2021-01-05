using DefendantTracker.Data;
using DefendantTracker.Models.ArrestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Services
{
    public class ArrestService
    {
        private readonly Guid _userID;
        //private readonly Guid _defendantID;

        public ArrestService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateArrest(ArrestCreate model)
        {
            var entity = new Arrest()
            {
                ArrestDate = DateTime.Now,
                StreetName = model.StreetName,
                ArrestCity = model.ArrestCity,
                ArrestCounty = model.ArrestCounty,
                ArrestState = model.ArrestState,
                ArrestZipcode = model.ArrestZipcode,
                ArrestDesc = model.ArrestDesc,
                DefendantID = model.DefendantID,
                OfficerID = model.OfficerID
            };
            using (var arr = new ApplicationDbContext())
            {
                arr.Arrests.Add(entity);
                return arr.SaveChanges() == 1;
            }
        }
        public IEnumerable<ArrestListItem> GetArrests()
        {
            using (var arr = new ApplicationDbContext())
            {
                var query = arr
                        .Arrests
                        .Select(
                            e =>
                            new ArrestListItem
                            {
                                ArrestID = e.ArrestID,
                                ArrestDate = e.ArrestDate,
                                StreetName = e.StreetName,
                                ArrestCity = e.ArrestCity,
                                ArrestCounty = e.ArrestCounty,
                                ArrestState = e.ArrestState,
                                ArrestZipcode = e.ArrestZipcode,
                                ArrestDesc = e.ArrestDesc,
                                DefendantID = e.DefendantID,
                                OfficerID = e.OfficerID
                            }
                    );
                return query.ToArray();
            }
        }
        public ArrestDetails GetArrestById(int id)
        {
            using (var arr = new ApplicationDbContext())
            {
                var entity = arr
                    .Arrests
                    .Single(e => e.ArrestID == id);
                return
                    new ArrestDetails
                    {
                        ArrestID = entity.ArrestID ,
                        ArrestDate = entity.ArrestDate,
                        StreetName = entity.StreetName,
                        ArrestCity = entity.ArrestCity,
                        ArrestCounty = entity.ArrestCounty,
                        ArrestState = entity.ArrestState,
                        ArrestZipcode = entity.ArrestZipcode,
                        ArrestLocation = entity.ArrestLocation,
                        ArrestDesc = entity.ArrestDesc,
                        DefendantID = entity.DefendantID,
                        OfficerID = entity.OfficerID
                    };
            }
        }
        public bool UpdateArrest(int id,ArrestEdit model)
        {
            using (var arr = new ApplicationDbContext())
            {
                var entity =
                    arr
                    .Arrests
                    .Single(e => e. ArrestID == id);
                entity.ArrestDate = model.ArrestDate;
                entity.StreetName = model.StreetName;
                entity.ArrestCity = model.ArrestCity;
                entity.ArrestCounty = model.ArrestCounty;
                entity.ArrestState = model.ArrestState;
                entity.ArrestZipcode = model.ArrestZipcode;
                entity.ArrestDesc = model.ArrestDesc;
                entity.DefendantID = model.DefendantID;
                entity.OfficerID = model.OfficerID;
                return arr.SaveChanges() == 1;
            }
        }
        public bool DeleteArrest(int id)
        {
            using (var arr = new ApplicationDbContext())
            {
                var entity =
                    arr
                        .Arrests
                        .Single(e => e.ArrestID == id);
                arr.Arrests.Remove(entity);
                return arr.SaveChanges() == 1;
            }
        }
    }
}
