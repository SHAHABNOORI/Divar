using System;

namespace Divar.Core.Commands.Advertisements.Commands
{
    public class UpdateDescriptionCommand
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
    }
}