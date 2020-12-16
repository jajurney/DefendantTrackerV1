﻿using DefendantTracker.Data;
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
        private readonly Guid _defendantID;
        public DefendantService(Guid defendantID)
        {
            _defendantID = defendantID;
        }
        public bool CreateDefendant(DefendantCreate model)
        {
            var entity = new Defendant()
            {
                DefendantID = _defendantID,
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
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Defendants.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DefendantListItem> GetDefendants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                        .Defendants
                        .Where(e => e.DefendantID == _defendantID)
                        .Select(
                            e =>
                            new DefendantListItem
                            {
                                DefendantID = _defendantID,
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
    }
}
