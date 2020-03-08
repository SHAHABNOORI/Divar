using System;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.Advertisements.Events
{
    public class PictureAddedToAdvertisement : IEvent
    {
        public Guid ClassifiedAdId { get; set; }

        public Guid PictureId { get; set; }

        public string Url { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Order { get; set; }
    }
}
