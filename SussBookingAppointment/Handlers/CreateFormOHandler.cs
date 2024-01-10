using MediatR;
using SUSS.DAL.Repositories;
using SussBookingAppointment.Services;

namespace SussBookingAppointment.Handlers
{
    public class CreateFormOHandler : IRequestHandler<CreateFormOCommand,int>
    {
        private readonly IFormORepositry _formORepositry;
        private readonly IEncryptionService _encryptionServices;
        private readonly ISmtpServices _smtpServices;
        public CreateFormOHandler(IFormORepositry formORepositry, IEncryptionService encryptionServices, ISmtpServices smtpServices)
        {
            _formORepositry = formORepositry;
            _encryptionServices = encryptionServices;
            _smtpServices = smtpServices;
        }

        async Task<int> IRequestHandler<CreateFormOCommand, int>.Handle(CreateFormOCommand request, CancellationToken cancellationToken)
        {
            var result = await _formORepositry.CreateFormO(request.formO_Model);
            string bookingID = _encryptionServices.EncryptValue(result.ToString());
            _smtpServices.SendEmailAsync("Abdul.rub@espire.com", "Dev Test Email",bookingID);
            return result;
        }
    }
}
