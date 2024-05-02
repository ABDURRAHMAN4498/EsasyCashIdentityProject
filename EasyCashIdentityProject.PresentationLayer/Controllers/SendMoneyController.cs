using EasyCashIdentityProject.DataAccess.Concrete;
using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DtoLayer.Dtos.CustomerAccountProcessDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccouontProssesService;

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
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcess)
        {
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var reciverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber ==
            sendMoneyForCustomerAccountProcess.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();


            //sendMoneyForCustomerAccountProcess.SenderID = user.Id;
            //sendMoneyForCustomerAccountProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //sendMoneyForCustomerAccountProcess.ProcessType = "Havale";
            //sendMoneyForCustomerAccountProcess.ReceiverID = reciverAccountNumberID;

            var values = new CustomerAccountProcess();
            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID = user.Id;
            values.ProcessType = "Havale";
            values.ReceiverID = reciverAccountNumberID;
            values.Amount = sendMoneyForCustomerAccountProcess.Amount;

            _customerAccouontProssesService.TInsert(values);
           
            return RedirectToAction("Index","Deneme");
        }
    }
}
