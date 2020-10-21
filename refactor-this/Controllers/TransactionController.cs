using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using refactor_this.Service;
using System.Web.Http.Cors;

namespace refactor_this.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TransactionController : ApiController
    {
        ITestService _testService;
        public TransactionController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult GetTransactions(Guid id)
        {

           var tra= _testService.GetTransactions(id);
            if (tra!=null)
            {
                return Ok(tra);
            }
            return BadRequest("No Transaction Found");
            //using (var connection = Helpers.NewConnection())
            //{
            //    SqlCommand command = new SqlCommand($"select Amount, Date from Transactions where AccountId = '{id}'", connection);
            //    connection.Open();
            //    var reader = command.ExecuteReader();
            //    var transactions = new List<Transaction>();
            //    //while (reader.Read())
            //    //{
            //    //    var amount = (float)reader.GetDouble(0);
            //    //    var date = reader.GetDateTime(1);
            //    //    transactions.Add(new Transaction(amount, date));
            //    //}
            //    return Ok(transactions);
            //}
        }

        [HttpPost, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult AddTransaction(Guid id, Transaction transaction)
        {
            if (_testService.AddTransaction(id, transaction))
            {
                return Ok();
            }
            return BadRequest("Could not update account amount");
            //using (var connection = Helpers.NewConnection())
            //{

            //    SqlCommand command = new SqlCommand($"update Accounts set Amount = Amount + {transaction.Amount} where Id = '{id}'", connection);
            //    connection.Open();
            //    if (command.ExecuteNonQuery() != 1)
            //        return BadRequest("Could not update account amount");

            //    command = new SqlCommand($"INSERT INTO Transactions (Id, Amount, Date, AccountId) VALUES ('{Guid.NewGuid()}', {transaction.Amount}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{id}')", connection);
            //    if (command.ExecuteNonQuery() != 1)
            //        return BadRequest("Could not insert the transaction");

            //    return Ok();
            //}
        }
    }
}