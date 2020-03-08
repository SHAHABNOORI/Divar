using System;

namespace Divar.Core.Commands.Advertisements.Commands
{
    public class CreateCommand
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }
    }
}