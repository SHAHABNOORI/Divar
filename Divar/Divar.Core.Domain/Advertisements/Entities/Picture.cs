using System;
using Divar.Core.Domain.Advertisements.Events;
using Divar.Core.Domain.Advertisements.ValueObjects;
using Divar.Framework.Domain.Entities;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.Advertisements.Entities
{
    public class Picture : BaseEntity<Guid>
    {
        #region Fields
        public PictureSize Size { get; private set; }

        public PictureUrl Location { get; private set; }

        public int Order { get; private set; }
        #endregion

        #region Constructors
        private Picture()
        {

        }
        public Picture(Action<IEvent> applier) : base(applier)
        {
        }
        #endregion

        #region Methods
        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case PictureAddedToAdvertisement e:
                    Id = e.PictureId;
                    Location = PictureUrl.FromString(e.Url);
                    Size = new PictureSize(e.Height, e.Width);
                    Order = e.Order;
                    break;
                case AdvertisementPictureResized e:
                    Size = new PictureSize(e.Height, e.Width);
                    break;
            }
        }

        public void Resize(PictureSize newSize)
        {
            SetStateByEvent(new AdvertisementPictureResized
            {
                PictureId = Id,
                Height = newSize.Width,
                Width = newSize.Width
            });
        }
        #endregion
    }
}
