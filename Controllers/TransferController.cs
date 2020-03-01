using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WebApiEFTest.Models;

namespace WebApiEFTest.Controllers
{
    [Authorize]
    public class TransferController : ApiController
    {

        ITransferRepository _transferRepo;
        IUserManagement _userManager;

        public TransferController(ITransferRepository transferRepository, IUserManagement userManager) {
            _transferRepo = transferRepository;
            _userManager = userManager;
        }

        [Route("api/Transfer/Send")]
        public string Post([FromBody]TransferModel model) {

            if (!ModelState.IsValid) {
                return "Поля перевода указаны неверно";
            }

            ApplicationUser fromUser = _userManager.Find(User.Identity.Name);
            ApplicationUser toUser = _userManager.Find(model.ToUserName);

            if (fromUser.Email == toUser.Email) {
                return "Имена отправителя и получателя совпадают!";
            }

            var powwwers = model.Powwwers;
            if (fromUser.Powwwers < powwwers) {
                return "Недостаточно средств для перевода!";
            }
            else {
                _userManager.ChangeBalance(fromUser, -powwwers);
                _userManager.ChangeBalance(toUser, powwwers);

                _transferRepo.Add(fromUser, toUser, powwwers);
            }

            var successMessage = $"{fromUser.Email} перевел {toUser.Email} {powwwers} powwwer(s)!. Баланс: {fromUser.Powwwers}";
            return successMessage;

        }

        [Route("api/Transfer/History")]
        public IEnumerable<TransferView> Get() {

            ApplicationUser user = _userManager.Find(User.Identity.Name);
            return _transferRepo.GetTransfers(user);
        }
    }
}
