using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using refactor_this.Models.BusinessModel;
using Unity;

namespace refactor_this
{
    public partial class Account : IAccount
    {
       // private bool isNew = true;

        //public Guid Id { get; set; }

        //public string Name { get; set; }

        //public string Number { get; set; }

        //public float Amount { get; set; }

        //public Account()
        //{
        //    isNew = true;
        //}
       

        //public Account(Guid id)
        //{
        //    isNew = false;
        //    Id = id;
        //}

       

        public bool Delete(Guid id)
        {

            using (Entities db = new Entities()) {
                Account account = db.Accounts.Where(a => a.Id == id).FirstOrDefault();
                if (account != null)
                {
                    db.Entry(account).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            //using (var connection = Helpers.NewConnection())
            //{
            //    SqlCommand command = new SqlCommand($"delete from Accounts where Id = '{Id}'", connection);
            //    connection.Open();
            //    command.ExecuteNonQuery();
            //}
        }

        public List<Account> Get()
        {
            using (Entities db = new Entities())
            {
             return   db.Accounts.ToList();
            }
        }

        public Account Get(Guid id)
        {
            using (Entities db = new Entities()) {
                return db.Accounts.Where(a => a.Id == id).FirstOrDefault();
            }
        }

        public bool Add(Account account)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    db.Entry(account).State = EntityState.Added;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
           
            
        }

        public bool Update(Guid id, Account account)
        {
            using (Entities db = new Entities())
            {
                Account acc = db.Accounts.Where(a => a.Id == id).FirstOrDefault();
                if (acc != null)
                {
                    acc.Amount = account.Amount;
                    acc.Name = account.Name;
                    acc.Number = account.Number;
                      

                    db.Entry(acc).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                
                
            }
            return false;
        }

        //public void Save()
        //{
        //    using (var connection = Helpers.NewConnection())
        //    {
        //        SqlCommand command;
        //        if (isNew)
        //            command = new SqlCommand($"insert into Accounts (Id, Name, Number, Amount) values ('{Guid.NewGuid()}', '{Name}', {Number}, 0)", connection);
        //        else
        //            command = new SqlCommand($"update Accounts set Name = '{Name}' where Id = '{Id}'", connection);

        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}
    }
}