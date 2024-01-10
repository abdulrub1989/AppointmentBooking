using AutoMapper;
using MediatR;
using SUSS.DAL.Repositories;
using SUSS.DOM.Entities;

namespace SussBookingAppointment.Handlers
{
    public class GetUserDetailsFormOHandler : IRequestHandler<GetUserDetailsFormOQuery,FormO>
    {
        private readonly IUserRepositry _userRepositry;
        private readonly IMapper _mapper;
        public GetUserDetailsFormOHandler(IUserRepositry userRepositry, IMapper mapper)
        {
            _userRepositry = userRepositry;
            _mapper = mapper;
        }

        async Task<FormO> IRequestHandler<GetUserDetailsFormOQuery, FormO>.Handle(GetUserDetailsFormOQuery request, CancellationToken cancellationToken)
        {
            UsersDetail usersDetail = await _userRepositry.GetUserbyBuildEmailID(request.Email);
            FormO form_O = _mapper.Map<UsersDetail, FormO>(usersDetail);
            return form_O;
        }
    }
}
