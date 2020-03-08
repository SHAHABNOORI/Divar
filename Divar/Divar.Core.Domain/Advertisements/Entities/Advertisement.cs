using System;
using Divar.Core.Domain.Advertisements.Enums;
using Divar.Core.Domain.Advertisements.ValueObjects;
using Divar.Framework.Domain.Entities;
using Divar.Framework.Domain.Exceptions;
using Divar.Framework.Tools.Enums;

namespace Divar.Core.Domain.Advertisements.Entities
{
    public class Advertisement : BaseEntity<Guid>
    {
        #region Fields    
        public UserId OwnerId { get; protected set; }

        public UserId ApprovedBy { get; protected set; }

        public AdvertisementTitle Title { get; protected set; }

        public AdvertisementDescription Description { get; protected set; }

        public Price Price { get; protected set; }

        public AdvertisementState State { get; protected set; }

        #endregion

        public Advertisement(Guid id, UserId ownerId)
        {
            Id = id;
            OwnerId = ownerId;
        }

        public void SetTitle(AdvertisementTitle title)
        {
            Title = title;
            ValidateInvariants();
        }

        public void UpdateText(AdvertisementDescription description)
        {
            Description = description;
            ValidateInvariants();
        }
        public void UpdatePrice(Price price)
        {
            Price = price;
            ValidateInvariants();
        }
        public void RequestToPublish()
        {
            State = AdvertisementState.ReviewPending;
            ValidateInvariants();
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
                    AdvertisementState.Active =>
                    Title != null
                    && Description != null
                    && Price != null
                    && ApprovedBy != null,
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