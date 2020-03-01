using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEFTest.Models
{
    public interface ITransferRepository
    {
        //TODO: убрать зависимости
        void Add(ApplicationUser from, ApplicationUser to, int powwwers);
        IEnumerable<TransferView> GetTransfers(ApplicationUser user);

    }
}
