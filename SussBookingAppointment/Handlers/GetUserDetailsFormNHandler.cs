using AutoMapper;
using MediatR;
using SUSS.DAL.Repositories;
using SUSS.DOM.Entities;
using SussBookingAppointment.Queries;

namespace SussBookingAppointment.Handlers
{
    public class GetUserDetailsFormNHandler : IRequestHandler<GetUserDetailsFormNQuery, FormN>
    {
        private readonly IUserRepositry _userRepositry;
        private readonly IMapper _mapper;
        public GetUserDetailsFormNHandler(IUserRepositry userRepositry, IMapper mapper)
        {
            _userRepositry = userRepositry;
            _mapper = mapper;
        }
        async Task<FormN> IRequestHandler<GetUserDetailsFormNQuery, FormN>.Handle(GetUserDetailsFormNQuery request, CancellationToken cancellationToken)
        {
            UsersDetail usersDetail = await _userRepositry.GetUserbyBuildEmailID(request.Email);
            FormN form_N = _mapper.Map<UsersDetail, FormN>(usersDetail);
            return form_N;
        }
    }
}
