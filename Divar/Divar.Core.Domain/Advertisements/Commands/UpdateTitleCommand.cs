using System;

namespace Divar.Core.Domain.Advertisements.Commands
{
    public class UpdateTitleCommand
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}