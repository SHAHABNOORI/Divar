using System;
using Divar.Core.Domain.Advertisements.Commands;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Core.Domain.Advertisements.ValueObjects;
using Divar.Framework.Domain.ApplicationServices;

namespace Divar.Core.ApplicationService.Advertisements.CommandHandlers
{
    public class UpdateDescriptionHandler : ICommandHandler<UpdateDescriptionCommand>
    {
        private readonly IAdvertisementRepository _repository;

        public UpdateDescriptionHandler(IAdvertisementRepository repository)
        {
            _repository = repository;
        }

        public void Handle(UpdateDescriptionCommand command)
        {
            var advertisement = _repository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.UpdateDescription(AdvertisementDescription.FromString(command.Description));
            _repository.Save(advertisement);
        }
    }
}