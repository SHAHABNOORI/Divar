using System;

namespace Divar.Core.Commands.Advertisements.Commands
{
    public class UpdateTitleCommand
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}