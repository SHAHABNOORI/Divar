using System;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.Advertisements.Events
{
    public class AdvertisementCreated : IEvent
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }
    }

}
