using System;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.Advertisements.Events
{
    public class AdvertisementPictureResized : IEvent
    {
        public Guid PictureId { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }
    }
}
