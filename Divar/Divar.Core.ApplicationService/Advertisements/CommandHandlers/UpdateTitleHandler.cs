using System;
using Divar.Core.Domain.Advertisements.Commands;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Core.Domain.Advertisements.ValueObjects;
using Divar.Framework.Domain.ApplicationServices;

namespace Divar.Core.ApplicationService.Advertisements.CommandHandlers
{
    public class UpdateTitleHandler : ICommandHandler<UpdateTitleCommand>
    {
        private readonly IAdvertisementRepository _repository;

        public UpdateTitleHandler(IAdvertisementRepository repository)
        {
            _repository = repository;
        }

        public void Handle(UpdateTitleCommand command)
        {
            var advertisement = _repository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.SetTitle(AdvertisementTitle.FromString(command.Title));
            _repository.Save(advertisement);
        }
    }
}