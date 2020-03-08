using System;

namespace Divar.Core.Queries.Advertisements.Dtos
{
    public class AdvertisementSummary
    {
        public Guid AdvertisementId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string PhotoUrl { get; set; }
    }
}
