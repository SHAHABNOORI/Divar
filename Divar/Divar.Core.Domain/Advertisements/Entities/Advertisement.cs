using System;
using System.Collections.Generic;
using System.Linq;
using Divar.Core.Domain.Advertisements.Enums;
using Divar.Core.Domain.Advertisements.Events;
using Divar.Core.Domain.Advertisements.ValueObjects;
using Divar.Framework.Domain.Entities;
using Divar.Framework.Domain.Events;
using Divar.Framework.Domain.Exceptions;
using Divar.Framework.Tools.Enums;

namespace Divar.Core.Domain.Advertisements.Entities
{
    public class Advertisement : BaseAggregateRoot<Guid>
    {
        #region Fields    
        public UserId OwnerId { get; protected set; }

        public UserId ApprovedBy { get; protected set; }

        public AdvertisementTitle Title { get; protected set; }

        public AdvertisementDescription Description { get; protected set; }

        public Price Price { get; protected set; }

        public AdvertisementState State { get; protected set; }

        public List<Picture> Pictures { get; private set; }

        #endregion

        public Advertisement(Guid id, UserId ownerId)
        {
            Pictures = new List<Picture>();
            HandleEvent(new AdvertisementCreated()
            {
                Id = id,
                OwnerId = ownerId
            });
        }

        public void SetTitle(AdvertisementTitle title)
        {
            HandleEvent(new AdvertisementTitleUpdated()
            {
                Id = Id,
                Title = title.Value
            });
        }

        public void UpdateDescription(AdvertisementDescription description)
        {

            HandleEvent(new AdvertisementDescriptionUpdated()
            {
                Id = Id,
                Description = description.Value
            });
        }

        public void UpdatePrice(Price price)
        {
            HandleEvent(new AdvertisementPriceUpdated()
            {
                Id = Id,
                Price = price.Value
            });
        }

        public void RequestToPublish()
        {
            HandleEvent(new AdvertisementSentForReview()
            {
                Id = Id
            });
        }

        public void AddPicture(Uri pictureUri, PictureSize size)
        {
            var newPic = new Picture(HandleEvent);
            newPic.HandleEvent(new PictureAddedToAdvertisement
            {
                PictureId = new Guid(),
                ClassifiedAdId = Id,
                Url = pictureUri.ToString(),
                Height = size.Height,
                Width = size.Width
            });
            Pictures.Add(newPic);
        }

        public void ResizePicture(Guid pictureId, PictureSize newSize)
        {
            var picture = FindPicture(pictureId);
            if (picture == null)
                throw new InvalidOperationException(
                    "تصویری با شناسه وارد شده وجود برای تغییر سایز وجود ندارد");
            picture.Resize(newSize);
        }

        private Picture FindPicture(Guid id) => Pictures.FirstOrDefault(x => x.Id == id);

        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case AdvertisementCreated e:
                    Id = e.Id;
                    OwnerId = UserId.FromGuid(e.OwnerId);
                    State = AdvertisementState.Inactive;
                    break;

                case AdvertisementPriceUpdated e:
                    Price = new Price(Rial.FromLong(e.Price));
                    break;

                case AdvertisementSentForReview e:
                    State = AdvertisementState.ReviewPending;
                    break;

                case AdvertisementDescriptionUpdated e:
                    Description = AdvertisementDescription.FromString(e.Description);
                    break;

                case AdvertisementTitleUpdated e:
                    Title = AdvertisementTitle.FromString(e.Title);
                    break;

                default:
                    throw new InvalidOperationException("امکان اجرای عملیات درخواستی وجود ندارد");
            }
        }

        protected override void ValidateInvariants()
        {
            var isValid =
                Id != default &&
                OwnerId != null &&
                (State
                    switch
                {
                    AdvertisementState.ReviewPending =>
                    Title != null
                    && Description != null
                    && Price != null,
                    //&& !Pictures.Any(),
                    AdvertisementState.Active =>
                    Title != null
                    && Description != null
                    && Price != null
                    && ApprovedBy != null,
                    //&& !Pictures.Any(),
                    _ => true
                });
            if (!isValid)
            {
                throw new InvalidEntityStateException(this,
                    $"مقدار تنظیم شده برای آگهی در وضیعت {State.GetDescription()} غیر قابل قبول است");
            }
        }
    }
}