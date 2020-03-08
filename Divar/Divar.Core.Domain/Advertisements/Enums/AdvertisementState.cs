using System.ComponentModel;

namespace Divar.Core.Domain.Advertisements.Enums
{
    public enum AdvertisementState
    {
        [Description("غیرفعال")]
        Inactive = 1,

        [Description("در انتظار تایید")]
        ReviewPending = 2,

        [Description("فعال")]
        Active = 3,

        [Description("فروخته شده")]
        Sold = 4
    }
}