using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using refactor_this.Models.BusinessModel;
using Unity;
using System.Data.Entity;

namespace refactor_this
{
    public partial class Transaction : ITransaction
    {
        public bool AddTransaction(Guid id, Transaction transaction)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    Transaction tran = db.Transactions.Where(t => t.Id == id).FirstOrDefault();
                    if (tran != null)
                    {
                        tran.Amount = tran.Amount+ transaction.Amount;

                        db.Entry(tran).State = EntityState.Modified;

                    }
                    else
                    {
                        db.Entry(transaction).State = EntityState.Added;
                    }

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        //public float Amount { get; set; }

        //public DateTime Date { get; set; }


        //public Transaction(float amount, DateTime date)
        //{
        //    Amount = amount;
        //    Date = date;
        //}

        public List<dynamic> GetTransactions(Guid id)
        {
            using (Entities db = new Entities())
            {
                return db.Transactions.Where(t => t.AccountId == id).Select(a => new {  a.Date, a.Amount }).ToList<dynamic>();
            }
        }
    }
}