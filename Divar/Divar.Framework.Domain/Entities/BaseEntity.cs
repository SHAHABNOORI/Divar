using System.Collections.Generic;
using System.Linq;
using Divar.Framework.Domain.Events;

namespace Divar.Framework.Domain.Entities
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }

        private readonly List<IEvent> _events = new List<IEvent>();

        private void RaiseEvent(IEvent @event) => _events.Add(@event);

        protected abstract void SetStateByEvent(IEvent @event);

        protected void HandleEvent(IEvent @event)
        {
            SetStateByEvent(@event);
            ValidateInvariants();
            RaiseEvent(@event);
        }

        public IEnumerable<IEvent> GetEvents() => _events.AsEnumerable();
        
        public void ClearEvents() => _events.Clear();

        protected abstract void ValidateInvariants();
    }
}