using System;
using Divar.Core.Domain.UserProfiles.Commands;
using Divar.Core.Domain.UserProfiles.Data;
using Divar.Core.Domain.UserProfiles.ValueObjects;
using Divar.Framework.Domain.ApplicationServices;
using Divar.Framework.Domain.Data;

namespace Divar.Core.ApplicationService.UserProfiles.CommandHandlers
{
    public class UpdateUserDisplayNameHandler : ICommandHandler<UpdateUserDisplayName>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserProfileRepository _userProfileRepository;

        public UpdateUserDisplayNameHandler(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository)
        {
            this._unitOfWork = unitOfWork;
            _userProfileRepository = userProfileRepository;
        }
        public void Handle(UpdateUserDisplayName command)
        {
            var user = _userProfileRepository.Load(command.UserId);
            if(user == null)
                throw new InvalidOperationException($"کاربری با شناسه {command.UserId} یافت نشد.");
            user.UpdateDisplayName(DisplayName.FromString(command.DisplayName));
            _unitOfWork.Commit();
        }
    }
}
