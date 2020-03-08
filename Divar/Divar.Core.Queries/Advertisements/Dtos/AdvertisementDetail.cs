using System;

namespace Divar.Core.Queries.Advertisements.Dtos
{
    public class AdvertisementDetail
    {
        public Guid AdvertisementId { get; set; }

        public string Title { get; set; }

        public long Price { get; set; }

        public string Description { get; set; }

        public string SellersDisplayName { get; set; }

        public string PhotoUrls { get; set; }
    }
}
