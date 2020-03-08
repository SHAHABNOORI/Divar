using System;
using Divar.Core.Commands.Advertisements.Commands;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Framework.Domain.ApplicationServices;
using Divar.Framework.Domain.Data;

namespace Divar.Core.ApplicationService.Advertisements.CommandHandlers
{
    public class RequestToPublishHandler : ICommandHandler<RequestToPublishCommand>
    {
        private readonly IAdvertisementRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RequestToPublishHandler(IAdvertisementRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Handle(RequestToPublishCommand command)
        {
            var advertisement = _repository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.RequestToPublish();
            _unitOfWork.Commit();
        }
    }
}