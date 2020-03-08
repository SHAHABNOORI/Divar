using System;
using Divar.Core.Domain.Advertisements.Entities;

namespace Divar.Core.Domain.Advertisements.Data
{
    public interface IAdvertisementRepository
    {
        bool Exists(Guid id);

        Advertisement Load(Guid id);

        void Save(Advertisement entity);
    }
}