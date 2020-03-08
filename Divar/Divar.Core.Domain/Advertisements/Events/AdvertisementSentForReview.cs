using System;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.Advertisements.Events
{
    public class AdvertisementSentForReview : IEvent
    {
        public Guid Id { get; set; }
    }
}
