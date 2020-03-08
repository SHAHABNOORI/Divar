using System;

namespace Divar.Core.Domain.UserProfiles.Commands
{
    public class UpdateUserEmail
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
