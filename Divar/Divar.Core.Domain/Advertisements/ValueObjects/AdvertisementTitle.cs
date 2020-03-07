using System;
using Divar.Framework.Domain.ValueObjects;

namespace Divar.Core.Domain.Advertisements.ValueObjects
{
    public class AdvertisementTitle : BaseValueObject<AdvertisementTitle>
    {
        public string Value { get; private set; }

        public static AdvertisementTitle FromString(string value) => new AdvertisementTitle(value);

        private AdvertisementTitle()
        {

        }

        public AdvertisementTitle(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("برای عنوان آگهی مقدار لازم است", nameof(value));
            }
            if (value.Length > 100)
            {
                throw new ArgumentOutOfRangeException("عنوان آگهی نباید بیش از 100 کاراکتر باشد", nameof(value));
            }
            Value = value;
        }

        public override int ObjectGetHashCode() => Value.GetHashCode();

        public override bool ObjectIsEqual(AdvertisementTitle otherObject) => Value == otherObject.Value;
        
        public static implicit operator string(AdvertisementTitle advertismentTitle) => advertismentTitle.Value;
    }
}
