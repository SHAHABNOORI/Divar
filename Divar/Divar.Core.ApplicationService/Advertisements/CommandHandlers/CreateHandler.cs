using System;
using Divar.Core.Commands.Advertisements.Commands;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Core.Domain.Advertisements.Entities;
using Divar.Core.Domain.Advertisements.ValueObjects;
using Divar.Framework.Domain.ApplicationServices;
using Divar.Framework.Domain.Data;

namespace Divar.Core.ApplicationService.Advertisements.CommandHandlers
{
    public class CreateHandler : ICommandHandler<CreateCommand>
    {
        private readonly IAdvertisementRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateHandler(IAdvertisementRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Handle(CreateCommand command)
        {
            if (_repository.Exists(command.Id))
                throw new InvalidOperationException($"قبلا آگهی با شناسه {command.Id} ثبت شده است.");

            var advertisement = new Advertisement(command.Id, UserId.FromGuid(command.OwnerId));
            _repository.Add(advertisement);
            _unitOfWork.Commit();
        }
    }
}