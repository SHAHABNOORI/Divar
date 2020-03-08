using System;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.Advertisements.Events
{
    public class AdvertisementPriceUpdated : IEvent
    {
        public Guid Id { get; set; }

        public long Price { get; set; }
    }

}
