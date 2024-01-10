using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using SUSS.DOM.Bookings;
using SussBookingAppointment.Services;

namespace SussBookingAppointment.Controllers
{
    public class BookingController : Controller
    {
        private readonly IAuthenticationServices _authenticationServices;
        public BookingController(IAuthenticationServices authenticationServices)
        {
            _authenticationServices = authenticationServices;
        }
        // GET: BookingController
        [HttpGet(Name = "GetAllMeetings")]
        public async Task<IActionResult> Index()
        {
           var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/solutions/bookingBusinesses/devespire@23bxdz.onmicrosoft.com/appointments");
            request.Headers.Add("Authorization", "Bearer "+ _authenticationServices.GetToken().access_token);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            MeetingData myDeserializedClass=new MeetingData();
            if (!string.IsNullOrEmpty(result))
            {
                myDeserializedClass = JsonConvert.DeserializeObject<MeetingData>(result);
            }
            return View(myDeserializedClass);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
