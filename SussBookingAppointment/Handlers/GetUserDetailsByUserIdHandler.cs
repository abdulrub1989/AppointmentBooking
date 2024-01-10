using AutoMapper;
using MediatR;
using SUSS.DAL.Repositories;
using SUSS.DOM.Entities;
using SussBookingAppointment.Queries;

namespace SussBookingAppointment.Handlers
{
    public class GetUserDetailsByUserIdHandler : IRequestHandler<GetUserDetailsByUserIdQuery, FormM>
    {
        private readonly IUserRepositry _userRepositry;
        private readonly IMapper _mapper;
        public GetUserDetailsByUserIdHandler(IUserRepositry userRepositry, IMapper mapper)
        {
            _userRepositry = userRepositry;
            _mapper = mapper;
        }

        async Task<FormM> IRequestHandler<GetUserDetailsByUserIdQuery, FormM>.Handle(GetUserDetailsByUserIdQuery request, CancellationToken cancellationToken)
        {
            UsersDetail usersDetail = await _userRepositry.GetUserbyBuildEmailID(request.emailId);
            FormM form_M = _mapper.Map<UsersDetail, FormM>(usersDetail);
            return form_M;
        }
    }
}
