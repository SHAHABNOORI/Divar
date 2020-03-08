using System;
using Bazzar.Core.Domain.Shared.ValueObjects;
using Divar.Core.Domain.UserProfiles.Commands;
using Divar.Core.Domain.UserProfiles.Data;
using Divar.Framework.Domain.ApplicationServices;
using Divar.Framework.Domain.Data;

namespace Divar.Core.ApplicationService.UserProfiles.CommandHandlers
{
    public class UpdateUserEmailHandler : ICommandHandler<UpdateUserEmail>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserProfileRepository _userProfileRepository;

        public UpdateUserEmailHandler(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository)
        {
            this._unitOfWork = unitOfWork;
            _userProfileRepository = userProfileRepository;
        }

        public void Handle(UpdateUserEmail command)
        {
            var user = _userProfileRepository.Load(command.UserId);
            if (user == null)
                throw new InvalidOperationException($"کاربری با شناسه {command.UserId} یافت نشد.");
            user.UpdateEmail(Email.FromString(command.Email));
            _unitOfWork.Commit();
        }
    }
}
