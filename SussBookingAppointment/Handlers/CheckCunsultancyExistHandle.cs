using MediatR;
using SUSS.DAL.Repositories;
using SUSS.DOM.Entities;

namespace SussBookingAppointment.Handlers
{
    public class CheckCunsultancyExistHandle : IRequestHandler<CheckCunsultancyExistQyery, BaseEntity>
    {
        private readonly ICunsultancyType _cunsultancyType;
        public CheckCunsultancyExistHandle(ICunsultancyType cunsultancyType)
        {
            _cunsultancyType= cunsultancyType;
        }
       async Task<BaseEntity> IRequestHandler<CheckCunsultancyExistQyery, BaseEntity>.Handle(CheckCunsultancyExistQyery request, CancellationToken cancellationToken)
        {
           return await _cunsultancyType.CheckCunsultancyExist(request.emailID, request.CounselindID);
        }
    }
}
