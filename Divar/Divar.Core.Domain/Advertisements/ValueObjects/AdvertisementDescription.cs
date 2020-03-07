using System;
using Divar.Framework.Domain.ValueObjects;

namespace Divar.Core.Domain.Advertisements.ValueObjects
{
    public class AdvertisementDescription : BaseValueObject<AdvertisementDescription>
    {

        public string Value { get; private set; }

        public static AdvertisementDescription FromString(string value) => new AdvertisementDescription(value);

        private AdvertisementDescription()
        {

        }
        public AdvertisementDescription(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("برای متن آگهی مقدار لازم است", nameof(value));
            }
            Value = value;
        }

        public override int ObjectGetHashCode() => Value.GetHashCode();

        public override bool ObjectIsEqual(AdvertisementDescription otherObject) => Value == otherObject.Value;
        

        public static implicit operator string(AdvertisementDescription advertismentText) => advertismentText.Value;
    }
}
