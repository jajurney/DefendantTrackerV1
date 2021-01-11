using DefendantTracker.Data;
using DefendantTracker.Models.CourtHearingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Services
{
    public class CourtHearingService
    { 
        private readonly Guid _userID;
       

        public CourtHearingService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateCourtHearing(CourtHearingCreate model)
        {
            var entity = new CourtHearing()
            { 
                CourtHearingID = model.CourtHearingID,
                HearingDesc = model.HearingDesc,
                CourtDate = model.CourtDate,
                CourtAddress = model.CourtAddress,
                CourtCity = model.CourtCity,
                CourtCounty = model.CourtCounty,
                CourtState = model.CourtState,
                CourtZipcode = model.CourtZipcode,
                StateAttorneyID = model.StateAttorneyID,
                DefenseAttorneyID = model.DefenseAttorneyID,
                OfficerID = model.OfficerID,
                DefendantID = model.DefendantID,
                ArrestID = model.ArrestID

            };
            using (var cor = new ApplicationDbContext())
            {
                cor.CourtHearings.Add(entity);
                return cor.SaveChanges() == 1;
            }
        }
        public IEnumerable<CourtHearingListItem> GetCourtHearings()
        {
            using (var cor = new ApplicationDbContext())
            {
                var query = cor
                        .CourtHearings
                        .Select(
                            e =>
                            new CourtHearingListItem
                            {
                                CourtHearingID = e.CourtHearingID,
                                HearingDesc = e.HearingDesc,
                                CourtDate = e.CourtDate,
                                CourtAddress = e.CourtAddress,
                                CourtCity = e.CourtCity,
                                CourtCounty = e.CourtCounty,
                                CourtState = e.CourtState,
                                CourtZipcode= e.CourtZipcode,
                                FullLocation = e.FullLocation,
                                StateAttorneyID = e.StateAttorneys.StateAttorneyID,
                                SAFullName= e.StateAttorneys.SAFullName,
                                DefenseAttorneyID = e.DefenseAttorneys.DefenseAttorneyID,
                                DAFullName = e.DefenseAttorneys.DAFullName,
                                OfficerID = e.Officers.OfficerID,
                                OFullName = e.Officers.OFullName,
                                DefendantID = e.Defendants.DefendantID,
                                DFullName = e.Defendants.DFullName,
                                ArrestID = e.ArrestID
                            }
                    );
                return query.ToArray();
            }
        }
        public CourtHearingDetails GetCourtHearingById(int id)
        {
            using (var cor = new ApplicationDbContext())
            {
                var entity = cor
                    .CourtHearings
                    .Single(e => e.CourtHearingID == id);
                return
                    new CourtHearingDetails
                    {
                        CourtHearingID = entity.CourtHearingID,
                        HearingDesc = entity.HearingDesc,
                        CourtDate = entity.CourtDate,
                        CourtAddress = entity.CourtAddress,
                        CourtCity = entity.CourtCity,
                        CourtCounty = entity.CourtCounty,
                        CourtState = entity.CourtState,
                        CourtZipcode = entity.CourtZipcode,
                        FullLocation = entity.FullLocation,
                        StateAttorneyID = entity.StateAttorneyID,
                        DefenseAttorneyID = entity.DefenseAttorneyID,
                        OfficerID = entity.OfficerID,
                        DefendantID = entity.DefendantID,
                        ArrestID = entity.ArrestID

                    };
            }
        }
        public bool UpdateCourtHearing(int id, CourtHearingEdit model)
        {
            using (var cor = new ApplicationDbContext())
            {
                var entity =
                    cor
                    .CourtHearings
                    .Single(e => e.CourtHearingID == id);
                entity.HearingDesc = model.HearingDesc;
                entity.CourtAddress = model.CourtAddress;
                entity.CourtCity = model.CourtCity;
                entity.CourtCounty = model.CourtCounty;
                entity.CourtState = model.CourtState;
                entity.CourtZipcode = model.CourtZipcode;
                entity.StateAttorneyID = model.StateAttorneyID;
                entity.DefenseAttorneyID = model.DefenseAttorneyID;
                entity.OfficerID = model.OfficerID;
                entity.DefendantID = model.DefendantID;
                entity.ArrestID = model.ArrestID;
                return cor.SaveChanges() == 1;
            }
        }
        public bool DeleteCourtHearing(int id)
        {
            using (var cor = new ApplicationDbContext())
            {
                var entity =
                    cor
                        .CourtHearings
                        .Single(e => e.CourtHearingID == id);
                cor.CourtHearings.Remove(entity);
                return cor.SaveChanges() == 1;
            }
        }
    }
}
