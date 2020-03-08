﻿using System;
using Divar.Core.Domain.Advertisements.Commands;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Core.Domain.Advertisements.Entities;
using Divar.Core.Domain.Advertisements.ValueObjects;
using Divar.Framework.Domain.ApplicationServices;

namespace Divar.Core.ApplicationService.Advertisements.CommandHandlers
{
    public class CreateHandler : ICommandHandler<CreateCommand>
    {
        private readonly IAdvertisementRepository _repository;

        public CreateHandler(IAdvertisementRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateCommand command)
        {
            if (_repository.Exists(command.Id))
                throw new InvalidOperationException($"قبلا آگهی با شناسه {command.Id} ثبت شده است.");

            var advertisement = new Advertisement(command.Id, UserId.FromGuid(command.OwnerId));
            _repository.Save(advertisement);

        }
    }
}