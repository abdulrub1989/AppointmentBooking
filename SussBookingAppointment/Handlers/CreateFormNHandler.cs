using MediatR;
using SUSS.DAL.Repositories;

namespace SussBookingAppointment.Handlers
{
    public class CreateFormNHandler : IRequestHandler<CreateFormNCommand,int>
    {
        private readonly IFormNRepositry _formNRepositry;
        public CreateFormNHandler(IFormNRepositry formNRepositry)
        {
            _formNRepositry = formNRepositry;
        }

        async Task<int> IRequestHandler<CreateFormNCommand, int>.Handle(CreateFormNCommand request, CancellationToken cancellationToken)
        {
            return await _formNRepositry.CreateFormN(request.formN_Model);
        }
    }
}
