using System;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.UserProfiles.Events
{
    public class UserDisplayNameUpdated : IEvent
    {
        public Guid UserId { get; set; }

        public string DisplayName { get; set; }
    }
}
