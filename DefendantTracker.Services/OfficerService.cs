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
        private readonly Guid _officerID;
        public OfficerService(Guid officerID)
        {
            _officerID = officerID;
        }
        public bool CreateOfficer(OfficerCreate model)
        {
            var entity = new Officer()
            {
                OfficerID = _officerID,
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
                        .Where(e => e.OfficerID == _officerID)
                        .Select(
                            e =>
                            new OfficerListItem
                            {
                                OfficerID = _officerID,
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
        public OfficerDetails GetOfficerById(Guid id)
        {
            using (var off = new ApplicationDbContext())
            {
                var entity = off
                    .Officers
                    .Single(e => e.OfficerID == _officerID);
                return
                    new OfficerDetails
                    {
                        OfficerID = _officerID,
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
        public bool UpdateOfficer(OfficerEdit model)
        {
            using (var off = new ApplicationDbContext())
            {
                var entity =
                    off
                    .Officers
                    .Single(e => e.OfficerID == _officerID);
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
        public bool DeleteOfficer(Guid id)
        {
            using (var off = new ApplicationDbContext())
            {
                var entity =
                    off
                        .Officers
                        .Single(e => e.OfficerID == _officerID);
                off.Officers.Remove(entity);
                return off.SaveChanges() == 1;
            }
        }
    }
}
