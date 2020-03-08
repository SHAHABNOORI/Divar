using System;

namespace Divar.Core.Commands.Advertisements.Commands
{
    public class UpdatePriceCommand
    {
        public Guid Id { get; set; }

        public long Price { get; set; }
    }
}