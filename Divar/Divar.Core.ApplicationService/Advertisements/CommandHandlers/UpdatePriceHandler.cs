using System;
using Divar.Core.Domain.Advertisements.Commands;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Core.Domain.Advertisements.ValueObjects;
using Divar.Framework.Domain.ApplicationServices;
using Divar.Framework.Domain.Data;

namespace Divar.Core.ApplicationService.Advertisements.CommandHandlers
{
    public class UpdatePriceHandler : ICommandHandler<UpdatePriceCommand>
    {
        private readonly IAdvertisementRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePriceHandler(IAdvertisementRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Handle(UpdatePriceCommand command)
        {
            var advertisement = _repository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.UpdatePrice(Price.FromLong(command.Price));
            _unitOfWork.Commit();
        }
    }
}