using System;
using Divar.Core.Domain.UserProfiles.Entities;

namespace Divar.Core.Domain.UserProfiles.Data
{
    public interface IUserProfileRepository
    {
        UserProfile Load(Guid id);
        void Add(UserProfile entity);
        bool Exists(Guid id);
    }
}
