using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using refactor_this.Models.BusinessModel;
namespace refactor_this.Service
{
    public class TestService : ITestService
    {
        IAccount _account; ITransaction _transaction;
        public TestService(IAccount account, ITransaction transaction)
        {
            _account = new Account();
            _transaction = new Transaction();
        }
        public bool Add(Account account)
        {
          return  _account.Add(account);
        }

        public bool AddTransaction(Guid id, Transaction transaction)
        {
          return  _transaction.AddTransaction(id, transaction);
        }

        public bool Delete(Guid id)
        {
            return _account.Delete(id);
        }

        public List<Account> Get()
        {
            return _account.Get();
        }

        public Account Get(Guid id)
        {
            return _account.Get(id);
        }

        public List<dynamic> GetTransactions(Guid id)
        {
            return _transaction.GetTransactions(id);
        }

        //public void Save()
        //{
        //    throw new NotImplementedException();
        //}

        public bool Update(Guid id, Account account)
        {
          return  _account.Update(id, account);
        }
    }
}