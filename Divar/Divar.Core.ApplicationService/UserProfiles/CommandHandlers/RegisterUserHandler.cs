using System;
using Divar.Core.Domain.UserProfiles.Commands;
using Divar.Core.Domain.UserProfiles.Data;
using Divar.Core.Domain.UserProfiles.Entities;
using Divar.Core.Domain.UserProfiles.ValueObjects;
using Divar.Framework.Domain.ApplicationServices;
using Divar.Framework.Domain.Data;

namespace Divar.Core.ApplicationService.UserProfiles.CommandHandlers
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserProfileRepository _userProfileRepository;

        public RegisterUserHandler(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository)
        {
            this._unitOfWork = unitOfWork;
            _userProfileRepository = userProfileRepository;
        }

        public void Handle(RegisterUser command)
        {
            if (_userProfileRepository.Exists(command.UserId))
                throw new InvalidOperationException($"قبلا کاربری با شناسه {command.UserId} ثبت شده است.");

            UserProfile userProfile = new UserProfile(command.UserId,
                FirstName.FromString(command.FirstName),
                LastName.FromString(command.LastName),
                DisplayName.FromString(command.DisplayName));
            _userProfileRepository.Add(userProfile);
            _unitOfWork.Commit();
        }
    }
}
