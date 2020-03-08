using System;
using System.Collections.Generic;
using System.Linq;
using Divar.Framework.Domain.Events;

namespace Divar.Framework.Domain.Entities
{
    //public abstract class BaseEntity<TId>
    //{
    //    public TId Id { get; set; }

    //    private readonly List<IEvent> _events = new List<IEvent>();

    //    private void RaiseEvent(IEvent @event) => _events.Add(@event);

    //    protected abstract void SetStateByEvent(IEvent @event);

    //    protected void HandleEvent(IEvent @event)
    //    {
    //        SetStateByEvent(@event);
    //        ValidateInvariants();
    //        RaiseEvent(@event);
    //    }

    //    public IEnumerable<IEvent> GetEvents() => _events.AsEnumerable();

    //    public void ClearEvents() => _events.Clear();

    //    protected abstract void ValidateInvariants();
    //}

    public abstract class BaseEntity<TId> where TId : IEquatable<TId>
    {
        public TId Id { get; protected set; }

        private readonly Action<IEvent> _applier;

        protected BaseEntity(Action<IEvent> applier)
        {
            _applier = applier;
        }

        protected BaseEntity() { }

        public void HandleEvent(IEvent @event)
        {
            SetStateByEvent(@event);
            _applier(@event);
        }

        protected abstract void SetStateByEvent(IEvent @event);

        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity<TId>;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id == null || other.Id == null)
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(BaseEntity<TId> a, BaseEntity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity<TId> a, BaseEntity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}