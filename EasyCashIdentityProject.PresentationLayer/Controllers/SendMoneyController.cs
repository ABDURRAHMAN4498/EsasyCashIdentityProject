using EasyCashIdentityProject.DtoLayer.Dtos.CustomerAccountProcessDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SendMoneyController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(
            SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcess
            )
        {
            var user = await _userManager.FindByIdAsync(User.Identity.Name);
            sendMoneyForCustomerAccountProcess.SenderID = user.Id;
            sendMoneyForCustomerAccountProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            sendMoneyForCustomerAccountProcess.ProcessType = "Havale";
            AppUser appUser = new AppUser()
            {

            };
            return View();
        }
    }
}
