using System;
using Divar.Core.Domain.Advertisements.Commands;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Framework.Domain.ApplicationServices;

namespace Divar.Core.ApplicationService.Advertisements.CommandHandlers
{
    public class RequestToPublishHandler : ICommandHandler<RequestToPublishCommand>
    {
        private readonly IAdvertisementRepository _repository;

        public RequestToPublishHandler(IAdvertisementRepository repository)
        {
            _repository = repository;
        }

        public void Handle(RequestToPublishCommand command)
        {
            var advertisement = _repository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.RequestToPublish();
            _repository.Save(advertisement);
        }
    }
}