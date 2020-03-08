using System;

namespace Divar.Core.Domain.UserProfiles.Commands
{
    public class RegisterUser
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
