using MediatR;
using SUSS.DAL.Repositories;
using SUSS.DOM.Entities;
using SussBookingAppointment.Queries;
using SussBookingAppointment.ViewModel;

namespace SussBookingAppointment.Handlers
{
    public class GetUserbyBuildEmailIDHandler : IRequestHandler<GetUserbyBuildEmailID, FormDViewModel>
    {
        private readonly IUserRepositry _userRepositry;
        public GetUserbyBuildEmailIDHandler(IUserRepositry userRepositry)
        {
            _userRepositry = userRepositry;
        }
        async Task<FormDViewModel> IRequestHandler<GetUserbyBuildEmailID, FormDViewModel>.Handle(GetUserbyBuildEmailID request, CancellationToken cancellationToken)
        {
            UsersDetail usersDetail = await _userRepositry.GetUserbyBuildEmailID(request.BuildEmailID);
            FormDViewModel formDView = new FormDViewModel();
            formDView.UsersDetail = usersDetail;
            //UserRegistration userRegistration = Mapper.Map<UsersDetail, UserRegistration>(usersDetail);
            return formDView;
        }

    }
}
