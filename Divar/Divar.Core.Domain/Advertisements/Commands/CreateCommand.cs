using System;

namespace Divar.Core.Domain.Advertisements.Commands
{
    public class CreateCommand
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }
    }
}