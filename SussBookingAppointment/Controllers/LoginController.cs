using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using SUSS.DAL.Repositories;
using SUSS.DOM.Entities;
using SussBookingAppointment.Queries;
using SussBookingAppointment.Services;

namespace SussBookingAppointment.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginRepository _loggin;
        private readonly IHttpContextAccessorService _httpContextAccessor;
        private readonly IDiagnosticContext _diagnosticContext;
        private readonly IEncryptionService _encryptionService;
        private readonly IAuthenticationServices _authenticationServices;
        private readonly IMediator _mediator;
        public LoginController(ILogger<LoginController> logger, IEncryptionService encryptionService,
            IHttpContextAccessorService httpContextAccessor, IDiagnosticContext diagnosticContext,
           IAuthenticationServices authenticationServices, IMediator mediator)
        {
            _logger = logger;
            _encryptionService = encryptionService;
            _httpContextAccessor = httpContextAccessor;
            _diagnosticContext = diagnosticContext;
            _mediator = mediator;
            _authenticationServices = authenticationServices;
        }
        [HttpGet(Name = "Index")]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://login.microsoftonline.com/999d5e4e-b16b-4eaf-aa97-ac9afa915c91/oauth2/v2.0/token?client_id=c9484aae-d7d9-4d03-9f2d-a884c7ae8355");
            request.Headers.Add("Cookie", "fpc=Aq_YBleE9u9OmmA8e0cc_ukQM7tLAQAAAFnxLt0OAAAA; stsservicecookie=estsfd; x-ms-gateway-slice=estsfd");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("grant_type", "client_credentials"));
            collection.Add(new("client_secret", "Pyh8Q~g7oJ8kjDsDAid4-SMJXxMeHMWl64sHUbIc"));
            collection.Add(new("client_id", "c9484aae-d7d9-4d03-9f2d-a884c7ae8355"));
            collection.Add(new("Scope", "https://graph.microsoft.com/.default"));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(result))
            {
                AuthenticationToken token = JsonConvert.DeserializeObject<AuthenticationToken>(result);
                _authenticationServices.SetToken(token);
            }
            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost(Name = "Index")]
        public async Task<IActionResult> Index(LoginModel users)
        {
            if (ModelState.IsValid)
            {
                _httpContextAccessor.SetInBuildEmailCookie(users.EmailAddress);
                users.Password = users.Password;
                UsersDetail usersDetail = await _mediator.Send(new LoginUserByEmailQuery(users));
                if (usersDetail.Error_Code == 200)
                {
                    return RedirectToAction("CunsultancyType", "Consultation", new { id = _encryptionService.EncryptValue(users.EmailAddress) });
                }
                TempData["info"] = usersDetail.Error_Message;
            }
            return View(users);
        }
    }
}
