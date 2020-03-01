using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiEFTest.Models
{
    public class TransferRepository : ITransferRepository   // TODO: добавить реализацию IDisposible
    {
        readonly TestContext context = new TestContext();

        public void Add(ApplicationUser from, ApplicationUser to, int powwwers) {
            Transfer transfer = new Transfer() {
                FromUserId = from.Id,
                ToUserId = to.Id,
                Powwwers = powwwers,
                DateTime = DateTime.Now
            };

            context.Transfers.Add(transfer);
            context.SaveChanges();
        }

        public IEnumerable<TransferView> GetTransfers(ApplicationUser user) {

            var userTransfers = (from t in context.Transfers
                            where t.FromUserId == user.Id || t.ToUserId == user.Id
                            join fu in context.Users on t.FromUserId equals fu.Id
                            join tu in context.Users on t.ToUserId equals tu.Id
                            select new { 
                                FromUser = fu.Email,
                                ToUser = tu.Email,
                                Powwwers = t.Powwwers,
                                DateTime = t.DateTime 
                            }).AsNoTracking();


            List<TransferView> transferViews = new List<TransferView>();

            foreach(var t in userTransfers) {
                if (t.ToUser == user.Email) {
                    transferViews.Add(new TransferView() {
                        UserName = t.FromUser,
                        Powwwers = t.Powwwers,
                        DateTime = t.DateTime
                    });
                }
                else {
                    transferViews.Add(new TransferView() {
                        UserName = t.ToUser,
                        Powwwers = -t.Powwwers,
                        DateTime = t.DateTime
                    });
                }
            }

            return transferViews.OrderByDescending(tv=>tv.DateTime);
        }

    }
}