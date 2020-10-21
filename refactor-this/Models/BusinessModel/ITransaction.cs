using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_this.Models.BusinessModel
{
   public interface ITransaction
    {
        List<dynamic> GetTransactions(Guid id);
        bool AddTransaction(Guid id, Transaction transaction);
    }
}
