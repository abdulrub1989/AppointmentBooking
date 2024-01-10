using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;
using SUSS.DAL.Repositories;
using SUSS.DOM.Entities;
using SussBookingAppointment.Commands;
using SussBookingAppointment.Filter.ExceptionFilters;
using SussBookingAppointment.Queries;
using SussBookingAppointment.Services;
using SussBookingAppointment.ViewModel;

namespace SussBookingAppointment.Controllers
{
    
    public class ConsultationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEncryptionService _encryptionService;
        private readonly IHttpContextAccessorService _httpContextAccessor;
        private readonly ICounsellingType _counsellingType;
        private readonly IMediator _mediator;
        public ConsultationController(ILogger<HomeController> logger, IEncryptionService encryptionService, IHttpContextAccessorService httpContextAccessor, ICounsellingType counsellingType, IMediator mediator)
        {
             _logger = logger;
            _encryptionService = encryptionService;
            _httpContextAccessor = httpContextAccessor;
            _counsellingType = counsellingType;
            _mediator = mediator;
        }
        public async Task<IActionResult> CunsultancyType(string id)
        {
            CunsultancyTypeViewModel model = await _mediator.Send(new GetCunsultancyTypeQuery());
            model.EmailID = _encryptionService.DecryptValue(id);
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CunsultancyType(CunsultancyTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                BaseEntity result = await _mediator.Send(new CheckCunsultancyExistQyery(model.EmailID,model.CunsultancyID));
                if (result.Error_Code == 200)
                {
                    //return RedirectPermanent("https://outlook.office365.com/owa/calendar/SUSS@espire.com/bookings/");
                    return RedirectToAction("Index","Booking");
                }
                else if (result.Error_Code == 102)
                {
                    TempData["error"] = result.Error_Message;
                    return RedirectToAction("RequestReject", new { type = model.CunsultancyID });
                }
                else if (result.Error_Code == 101)
                {
                    TempData["info"] = result.Error_Message;
                    var _cunResult = await _mediator.Send(new GetCunsultancyTypeQuery());
                    model.CunsultancyTypes = _cunResult.CunsultancyTypes;
                }
                else
                {
                    return RedirectToAction("FormD", "Consultation", new { type = model.CunsultancyID });
                }
            }
            return View(model);
        }
        #region Form D
        public async Task<IActionResult> FormD(int type)
        {
            TempData["type"] = type;
            _counsellingType.SetCounsellingType(type);
            FormDViewModel usersDetail =await _mediator.Send(new GetUserbyBuildEmailID(_httpContextAccessor.GetInBuildEmailCookie()));
            if (usersDetail.UsersDetail.Error_Code == 200)
            {
                return View(usersDetail);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FormD(UserRegistration registrationModel)
        {
            int _type = Convert.ToInt32(TempData["type"]);
            registrationModel.CounsellingID= _type;
            _mediator.Send(new CreateUserRegistrationCommand(registrationModel));
            return RedirectToAction(_type == 3 ? "FormN" : "FormM");
        }
        #endregion

        #region Form M
        public async Task<IActionResult> FormM()
        {
            TempData.Keep("type");
            FormM formM_Model = await _mediator.Send(new GetUserDetailsByUserIdQuery(_httpContextAccessor.GetInBuildEmailCookie()));
            return View(formM_Model);
        }
        [HttpPost]
        public async Task<IActionResult> FormM(FormM model)
        {
            int _type = Convert.ToInt32(TempData["type"]);
            model.CounsellingID = _type;
            var result = await _mediator.Send(new CreateBookingCommand(model));
            if (result > 0)
            {
                return RedirectToAction("Confirm");
            }
            return View();
        }
        #endregion

        #region Form N
        public async Task<IActionResult> FormN()
        {
            TempData.Keep("type");
            FormN formN_Model = await _mediator.Send(new GetUserDetailsFormNQuery(_httpContextAccessor.GetInBuildEmailCookie()));
            return View(formN_Model);
        }
        [HttpPost]
        public async Task<IActionResult> FormN(FormN model)
        {
            int _type = Convert.ToInt32(TempData["type"]);
            model.CounsellingID = _type;
            var result = await _mediator.Send(new CreateFormNCommand(model));
            if (result > 0)
            {
                return RedirectToAction("FormO");
            }
            return View();
        }
        #endregion

        #region Form O
        public async Task<IActionResult> FormO()
        {
            TempData.Keep("type");
            FormO formO_Model = await _mediator.Send(new GetUserDetailsFormOQuery(_httpContextAccessor.GetInBuildEmailCookie()));
            return View(formO_Model);
        }
        [HttpPost]
        public async Task<IActionResult> FormO(FormO model)
        {
            int _type = Convert.ToInt32(TempData["type"]);
            model.CounsellingID = _type;
            var result = await _mediator.Send(new CreateFormOCommand(model));
            if (result > 0)
            {
                return RedirectToAction("Confirm");
            }
            return View();
        }
        #endregion
        public IActionResult Confirm()
        {
            return View();
        }
        public IActionResult RequestReject(int type)
        {
            TempData.Keep("error");
            return View();
        }

    }
}
