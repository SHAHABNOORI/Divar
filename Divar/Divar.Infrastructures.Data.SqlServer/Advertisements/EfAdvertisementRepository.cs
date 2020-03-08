using System;
using System.Linq;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Core.Domain.Advertisements.Entities;

namespace Divar.Infrastructures.Data.SqlServer.Advertisements
{
    public class EfAdvertisementRepository: IAdvertisementRepository, IDisposable
    {
        private readonly DivarDbContext _advertisementDbContext;

        public EfAdvertisementRepository(DivarDbContext advertisementDbContext)
        {
            _advertisementDbContext = advertisementDbContext;
        }

        public bool Exists(Guid id)
        {
            return _advertisementDbContext.Advertisements.Any(c => c.Id == id);
        }

        public Advertisement Load(Guid id)
        {
            return _advertisementDbContext.Advertisements.Find(id);
        }

        public void Add(Advertisement entity)
        {
            _advertisementDbContext.Advertisements.Add(entity);
            //_advertisementDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _advertisementDbContext?.Dispose();
        }
    }
}