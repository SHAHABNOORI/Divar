using System;

namespace Divar.Core.Domain.Advertisements.Commands
{
    public class UpdateDescriptionCommand
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
    }
}