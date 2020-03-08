using Divar.Core.Queries.Advertisements.Dtos;
using Divar.Core.Queries.Advertisements.Queries;

namespace Divar.Core.Domain.Advertisements.Data
{
    public interface IAdvertisementQueryService
    {
        AdvertisementDetail Query(GetActiveAdvertisement query);

        AdvertisementSummary Query(GetActiveAdvertisementList query);

        AdvertisementSummary Query(GetAdvertisementForSpecificSeller query);
    }
}