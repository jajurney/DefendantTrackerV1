using DefendantTracker.Data;
using DefendantTracker.Models.OfficerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Services
{
    public class OfficerService
    {
        private readonly Guid _userID;
        public OfficerService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateOfficer(OfficerCreate model)
        {
            var entity = new Officer()
            {
                OfficerID = model.OfficerID,
                BadgeID = model.BadgeID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DepartmentCity = model.DepartmentCity,
                DepartmentCounty = model.DepartmentCounty,
                DepartmentState = model.DepartmentState,
                DepartmentZipcode = model.DepartmentZipcode,
                DepartmentName = model.DepartmentName
            };
            using (var off = new ApplicationDbContext())
            {
                off.Officers.Add(entity);
                return off.SaveChanges() == 1;
            }
        }
        public IEnumerable<OfficerListItem> GetOfficers()
        {
            using (var off = new ApplicationDbContext())
            {
                var query = off
                        .Officers
                        .Select(
                            e =>
                            new OfficerListItem
                            {
                                OfficerID = e.OfficerID,
                                BadgeID = e.BadgeID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                DepartmentCity = e.DepartmentCity,
                                DepartmentCounty = e.DepartmentCounty,
                                DepartmentState = e.DepartmentState,
                                DepartmentZipcode = e.DepartmentZipcode,
                                DepartmentName = e.DepartmentName
                            }
                     );
                return query.ToArray();
            }
        }
        public OfficerDetails GetOfficerById(int id)
        {
            using (var off = new ApplicationDbContext())
            {
                var entity = off
                    .Officers
                    .Single(e => e.OfficerID == id);
                return
                    new OfficerDetails
                    {
                        OfficerID = entity.OfficerID,
                        BadgeID = entity.BadgeID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        FullName = entity.FullName,
                        DepartmentCity = entity.DepartmentCity,
                        DepartmentCounty = entity.DepartmentCounty,
                        DepartmentState = entity.DepartmentState,
                        DepartmentZipcode = entity.DepartmentZipcode,
                        DepartmentLocation = entity.DepartmentLocation,
                        DepartmentName = entity.DepartmentName
                    };
            }
        }
        public bool UpdateOfficer(int id, OfficerEdit model)
        {
            using (var off = new ApplicationDbContext())
            {
                var entity =
                    off
                    .Officers
                    .Single(e => e.OfficerID == id);
                entity.BadgeID = model.BadgeID;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.DepartmentCity = model.DepartmentCity;
                entity.DepartmentCounty = model.DepartmentCounty;
                entity.DepartmentState = model.DepartmentState;
                entity.DepartmentZipcode = model.DepartmentZipcode;
                entity.DepartmentName = model.DepartmentName;
                return off.SaveChanges() == 1;
            }
        }
        public bool DeleteOfficer(int id)
        {
            using (var off = new ApplicationDbContext())
            {
                var entity =
                    off
                        .Officers
                        .Single(e => e.OfficerID == id);
                off.Officers.Remove(entity);
                return off.SaveChanges() == 1;
            }
        }
    }
}
