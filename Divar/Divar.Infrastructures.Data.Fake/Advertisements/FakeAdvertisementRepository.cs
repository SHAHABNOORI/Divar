using System;
using System.Collections.Generic;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Core.Domain.Advertisements.Entities;

namespace Divar.Infrastructures.Data.Fake.Advertisements
{
    public class FakeAdvertisementRepository : IAdvertisementRepository
    {
        private readonly Dictionary<Guid, Advertisement> _db = new Dictionary<Guid, Advertisement>();

        public bool Exists(Guid id)
        {
            return _db.ContainsKey(id);
        }

        public Advertisement Load(Guid id)
        {
            return _db[id];
        }

        public void Add(Advertisement entity)
        {
            _db[entity.Id] = entity;
        }
    }
}
