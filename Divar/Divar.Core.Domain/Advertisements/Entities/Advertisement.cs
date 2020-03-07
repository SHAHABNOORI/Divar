using System;
using Divar.Core.Domain.Advertisements.Enums;

namespace Divar.Core.Domain.Advertisements.Entities
{
    public class Advertisement
    {
        public Guid Id { get; private set; }

        public Guid OwnerId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public long Price { get; private set; }

        public AdvertisementStatus Status { get; private set; }

        public Advertisement(Guid id, Guid ownerId)
        {
            if (id == Guid.Empty)
            {
                throw new Exception();
            }

            if (OwnerId == Guid.Empty)
            {
                throw new Exception();
            }

            Id = id;
            OwnerId = ownerId;
            CheckInvariants();
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception();

            Title = title;
            CheckInvariants();
        }

        public void SetDescription(string description)
        {
            Description = description;
            CheckInvariants();
        }

        public void SetPrice(long price)
        {
            Price = price;
            CheckInvariants();
        }

        public void SendForReview()
        {
            Status = AdvertisementStatus.ReviewPending;
            CheckInvariants();
        }

        public void CheckInvariants()
        {

        }
    }
}