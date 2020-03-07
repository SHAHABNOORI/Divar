using System;

namespace Divar.Framework.Domain.ValueObjects
{
    public abstract class BaseValueObject<TValueObject> : IEquatable<TValueObject>
        where TValueObject : BaseValueObject<TValueObject>
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BaseValueObject<TValueObject>) obj);
        }

        protected bool Equals(BaseValueObject<TValueObject> other)
        {
            var otherObject = other as TValueObject;
            if (ReferenceEquals(otherObject, null))
                return false;
            return ObjectIsEqual(otherObject);
        }

        public override int GetHashCode()
        {
            return ObjectGetHashCode();
        }

        public abstract bool ObjectIsEqual(TValueObject otherObject);

        public abstract int ObjectGetHashCode();

        public bool Equals(TValueObject other)
        {
            return this == other;
        }
        public static bool operator ==(BaseValueObject<TValueObject> right, BaseValueObject<TValueObject> left)
        {
            if (ReferenceEquals(right, null) && ReferenceEquals(left, null))
                return true;
            if (ReferenceEquals(right, null) || ReferenceEquals(left, null))
                return false;
            return right.Equals(left);
        }
        public static bool operator !=(BaseValueObject<TValueObject> right, BaseValueObject<TValueObject> left)
        {
            return !(right == left);
        }
    }
}
