using System;
using System.Linq;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Core.Domain.Advertisements.Entities;

namespace Divar.Infrastructures.Data.SqlServer.Advertisements
{
    public class EfAdvertisementRepository: IAdvertisementRepository, IDisposable
    {
        private readonly DivarDbContext _db;

        public EfAdvertisementRepository(DivarDbContext db)
        {
            _db = db;
        }

        public bool Exists(Guid id)
        {
            return _db.Advertisements.Any(c => c.Id == id);
        }

        public Advertisement Load(Guid id)
        {
            return _db.Advertisements.Find(id);
        }

        public void Add(Advertisement entity)
        {
            _db.Advertisements.Add(entity);
            //_db.SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}