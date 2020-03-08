using Divar.Framework.Domain.Data;

namespace Divar.Infrastructures.Data.SqlServer
{
    public class AdvertisementUnitOfWork : IUnitOfWork
    {
        private readonly DivarDbContext _advertisementDbContext;

        public AdvertisementUnitOfWork(DivarDbContext advertisementDbContext)
        {
            _advertisementDbContext = advertisementDbContext;
        }

        public int Commit()
        {
            var result = _advertisementDbContext.SaveChanges();
            return result;
        }
    }
}