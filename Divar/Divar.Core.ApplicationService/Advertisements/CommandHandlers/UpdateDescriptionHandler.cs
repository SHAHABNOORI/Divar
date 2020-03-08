using System;
using Divar.Core.Domain.Advertisements.Commands;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Core.Domain.Advertisements.ValueObjects;
using Divar.Framework.Domain.ApplicationServices;
using Divar.Framework.Domain.Data;

namespace Divar.Core.ApplicationService.Advertisements.CommandHandlers
{
    public class UpdateDescriptionHandler : ICommandHandler<UpdateDescriptionCommand>
    {
        private readonly IAdvertisementRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDescriptionHandler(IAdvertisementRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Handle(UpdateDescriptionCommand command)
        {
            var advertisement = _repository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.UpdateDescription(AdvertisementDescription.FromString(command.Description));
            _unitOfWork.Commit();
        }
    }
}