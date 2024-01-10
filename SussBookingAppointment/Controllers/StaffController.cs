using MediatR;
using Microsoft.AspNetCore.Mvc;
using SUSS.DOM.Entities;
using SussBookingAppointment.Filter.ExceptionFilters;

namespace SussBookingAppointment.Controllers
{
    
    public class StaffController : Controller
    {
        private readonly ILogger<StaffController> _logger;
        private readonly IMediator _mediator;
        public StaffController(ILogger<StaffController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        public async Task<IActionResult> Approver(string id)
        {
            ApproverDOM approverDOM = await _mediator.Send(new GetApproverDetailByBookingIDQuery(id));
            if (approverDOM.Users_Detail.Error_Code == 200)
            {
                approverDOM.ApproverID = id;
                _logger.LogInformation("Id", id);
                return View(approverDOM);
            }
            return RedirectToActionPermanent(approverDOM.Users_Detail.Error_Code == 400 ?
                    "NotFound" : "Index",
                    "Error",
                    new
                    {
                        statusCode = approverDOM.Users_Detail.Error_Code
                    });
        }
        [HttpPost]
        public async Task<IActionResult> Approver(Approver approver)
        {
            _logger.LogInformation("Request Approve in Process", $"Request for Approving With ID:{approver.ApproverID}");
            approver.Status = "2";
            if (await _mediator.Send(new ApproveCommand(approver)) > 0)
            {
                _logger.LogInformation("Request Approved", $"Request Approved With ID:{approver.ApproverID}");
                return RedirectToAction("ConfirmApprove");
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> Reject(Approver approver)
        {
            _logger.LogInformation("Request Reject in Process", $"Request for Rejecting With ID:{approver.ApproverID}");
            approver.Status = "3";
            if (await _mediator.Send(new ApproveCommand(approver)) > 0)
            {
                _logger.LogInformation("Request Rejected", $"Request Rejected With ID:{approver.ApproverID}");
                return RedirectToAction("ConfirmReject");
            }
            return RedirectToAction("Index", "Error");
        }
        public ActionResult ConfirmApprove()
        {
            _logger.LogInformation("Approved", $"Request Approved");
            return View();
        }
        public ActionResult ConfirmReject()
        {
            _logger.LogInformation("Rejected", $"Request Rejected");
            return View();
        }
    }
}
