using System;
using Divar.Framework.Domain.Events;

namespace Divar.Core.Domain.UserProfiles.Events
{
    public class UserNameUpdated : IEvent
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
