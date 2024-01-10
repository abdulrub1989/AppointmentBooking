using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using SUSS.DAL.Repositories;
using SUSS.DOM.Entities;
using SussBookingAppointment.ViewModel;
using System.Collections.Immutable;

namespace SussBookingAppointment.Handlers
{
    public class GetCunsultancyTypeHandle : IRequestHandler<GetCunsultancyTypeQuery, CunsultancyTypeViewModel>
    {
        private readonly ICunsultancyType _cunsultancyType;
        public GetCunsultancyTypeHandle(ICunsultancyType cunsultancyType)
        {
            _cunsultancyType = cunsultancyType;
        }
        async Task<CunsultancyTypeViewModel> IRequestHandler<GetCunsultancyTypeQuery, CunsultancyTypeViewModel>.Handle(GetCunsultancyTypeQuery request, CancellationToken cancellationToken)
        {
           IList<CunsultancyType> cunsultancyTypes = await _cunsultancyType.GetCunsultancyType();
            IList<SelectListItem> items = cunsultancyTypes.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name
            }).ToList();
            var cunsultancyTypesFirst = new SelectListItem()
            {
                Value = null,
                Text = "--- Select CunsultancyType ---"
            };
            items.Insert(0, cunsultancyTypesFirst);
            CunsultancyTypeViewModel cunsultancyTypeViewModel = new CunsultancyTypeViewModel();
            cunsultancyTypeViewModel.CunsultancyTypes = items;
            return cunsultancyTypeViewModel;
        }
    }
}
