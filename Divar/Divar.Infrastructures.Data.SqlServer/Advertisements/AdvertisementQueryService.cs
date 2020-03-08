using Dapper;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Core.Queries.Advertisements.Dtos;
using Divar.Core.Queries.Advertisements.Queries;
using Microsoft.Data.SqlClient;

namespace Divar.Infrastructures.Data.SqlServer.Advertisements
{
    public class AdvertisementQueryService : IAdvertisementQueryService
    {
        private readonly SqlConnection _sqlConnection;

        public AdvertisementQueryService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public AdvertisementDetail Query(GetActiveAdvertisement query)
        {
            string sqlQuery = "Select Top 1 a.Id as 'AdvertisementId'," +
                              " a.Title,a.Description,p.Location as 'photoUrls', up.DisplayName as 'SellersDisplayName' " +
                              " FROM Advertisements a " +
                              " Inner Join Picture p on a.Id = p.AdvertisementId " +
                              " Inner Join UserProfiles up on a.OwnerId = up.Id" +
                              " Where State = 2 and " +
                              " a.Id = @AdvertisementId " +
                              " Order By p.[Order]";
            var result= _sqlConnection.QuerySingleOrDefault<AdvertisementDetail>(sqlQuery,
                new { query.AdvertisementId });
            return result;
        }

        public AdvertisementSummary Query(GetActiveAdvertisementList query)
        {
            throw new System.NotImplementedException();
        }

        public AdvertisementSummary Query(GetAdvertisementForSpecificSeller query)
        {
            throw new System.NotImplementedException();
        }
    }
}