using MailKit.Net.Smtp;
using MediatR;
using SUSS.DAL.Repositories;
using SussBookingAppointment.Commands;
using SussBookingAppointment.Services;

namespace SussBookingAppointment.Handlers
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, int>
    {
        private readonly IBooking _bookingRepositry;
        private readonly IEncryptionService _encryptionServices;
        private readonly ISmtpServices _smtpServices;
        public CreateBookingHandler(IBooking bookingRepositry, IEncryptionService encryptionServices, ISmtpServices smtpServices)
        {
            _bookingRepositry= bookingRepositry;
            _encryptionServices = encryptionServices;
            _smtpServices = smtpServices;
        }
        async Task<int> IRequestHandler<CreateBookingCommand, int>.Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
           var result =  await _bookingRepositry.CreateBooking(request.Form_M);
            string bookingID = _encryptionServices.EncryptValue(result.ToString());
            _smtpServices.SendEmailAsync("Abdul.rub@espire.com", "Dev Test Email", bookingID);
            return result;
        }
    }
}
