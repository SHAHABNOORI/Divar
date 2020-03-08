using System;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.UserProfiles.Events
{
    public class UserEmailUpdated : IEvent
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
