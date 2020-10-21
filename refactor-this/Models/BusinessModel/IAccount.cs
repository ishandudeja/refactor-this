using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_this.Models.BusinessModel
{
   public interface IAccount
    {
        List<Account> Get();
        Account Get(Guid id);
        bool Add(Account account);
        bool Update(Guid id, Account account);
        //void Save();
        bool Delete(Guid id);
    }
}
