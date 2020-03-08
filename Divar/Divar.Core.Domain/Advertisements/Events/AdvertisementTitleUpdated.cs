using System;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.Advertisements.Events
{
    public class AdvertisementTitleUpdated : IEvent
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
