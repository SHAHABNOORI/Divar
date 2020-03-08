using System;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.Advertisements.Events
{
    public class AdvertisementDescriptionUpdated : IEvent
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
    }

}
