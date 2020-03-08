using System;
using System.Linq;
using Divar.Core.Domain.UserProfiles.Data;
using Divar.Core.Domain.UserProfiles.Entities;
using Divar.Infrastructures.Data.SqlServer;

namespace Bazzar.Infrastructures.Data.SqlServer.UserProfiles
{
    public class EfUserProfileRepository : IUserProfileRepository, IDisposable
    {
        private readonly DivarDbContext _db;

        public EfUserProfileRepository(DivarDbContext db)
        {
            this._db = db;
        }
        public void Add(UserProfile entity)
        {
            _db.UserProfiles.Add(entity);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public bool Exists(Guid id)
        {
            return _db.UserProfiles.Any(c => c.Id == id);
        }

        public UserProfile Load(Guid id)
        {
            return _db.UserProfiles.Find(id);
        }
    }
}
