using System;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.UserProfiles.Events
{
    public class UserRegistered : IEvent
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }
    }
}
