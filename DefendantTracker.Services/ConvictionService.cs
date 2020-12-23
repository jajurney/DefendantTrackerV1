using DefendantTracker.Data;
using DefendantTracker.Models.ConvictionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Services
{
    public class ConvictionService
    {
        private readonly Guid _userID;
        //private readonly Guid _defendantID;

        public ConvictionService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateConviction(ConvictionCreate model)
        {
            var entity = new Conviction()
            {
                StreetAddress = model.StreetAddress,
                City = model.City,
                County = model.County,
                State = model.State,
                Zipcode = model.Zipcode,
                DateOfConviction = DateTime.Now
            };
            using (var con = new ApplicationDbContext())
            {
                con.Convictions.Add(entity);
                return con.SaveChanges() == 1;
            }
        }
        public IEnumerable<ConvictionListItem> GetConvictions()
        {
            using (var con = new ApplicationDbContext())
            {
                var query = con
                        .Convictions
                        .Select(
                            e =>
                            new ConvictionListItem
                            {
                                ConvicID = e.ConvicID,
                                StreetAddress = e.StreetAddress,
                                City = e.City,
                                County = e.County,
                                State = e.State,
                                Zipcode = e.Zipcode,
                                FullLocation = e.FullLocation,
                                DateOfConviction = e.DateOfConviction
                            }
                    );
                return query.ToArray();
            }
        }
        public ConvictionDetails GetConvictionById(int id)
        {
            using (var con = new ApplicationDbContext())
            {
                var entity = con
                    .Convictions
                    .Single(e => e.ConvicID == id);
                return
                    new ConvictionDetails
                    {
                        ConvicID = entity.ConvicID,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City,
                        County = entity.County,
                        State = entity.State,
                        Zipcode = entity.Zipcode,
                        FullLocation = entity.FullLocation,
                        DateOfConviction = entity.DateOfConviction
                    };
            }
        }
        public bool UpdateConviction(int id, ConvictionEdit model)
        {
            using (var con = new ApplicationDbContext())
            {
                var entity =
                    con
                    .Convictions
                    .Single(e => e.ConvicID == id);
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.County = model.County;
                entity.State = model.State;
                entity.Zipcode = model.Zipcode;
                entity.DateOfConviction = model.DateOfConviction;
                return con.SaveChanges() == 1;
            }
        }
        public bool DeleteConviction(int id)
        {
            using (var con = new ApplicationDbContext())
            {
                var entity =
                    con
                        .Convictions
                        .Single(e => e.ConvicID == id);
                con.Convictions.Remove(entity);
                return con.SaveChanges() == 1;
            }
        }
    }
}

