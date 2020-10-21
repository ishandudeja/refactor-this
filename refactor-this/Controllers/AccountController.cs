using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using refactor_this.Models.BusinessModel;
using refactor_this.Service;
using System.Web.Http.Cors;

namespace refactor_this.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        ITestService _TestService;
        public AccountController(ITestService TestService)
        {
            _TestService = TestService;

        }
        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetById(Guid id)
        {
            return Ok(_TestService.Get(id));
            //using (var connection = Helpers.NewConnection())
            //{
            //    return Ok(Get(id));
            //}
        }

        [HttpGet, Route("api/Accounts")]
        public IHttpActionResult Get()
        {
            var accounts = new List<Account>();
            accounts = _TestService.Get();
            return Ok(accounts);
            //using (var connection = Helpers.NewConnection())
            //{
            //    SqlCommand command = new SqlCommand($"select Id from Accounts", connection);
            //    connection.Open();
            //    var reader = command.ExecuteReader();
            //    var accounts = new List<Account>();
            //    while (reader.Read())
            //    {
            //        var id = Guid.Parse(reader["Id"].ToString());
            //        var account = Get(id);
            //        accounts.Add(account);
            //    }

            //    return Ok(accounts);
            //}
        }

        //private Account Get(Guid id)
        //{
        //    using (var connection = Helpers.NewConnection())
        //    {
        //        SqlCommand command = new SqlCommand($"select * from Accounts where Id = '{id}'", connection);
        //        connection.Open();
        //        var reader = command.ExecuteReader();
        //        if (!reader.Read())
        //            throw new ArgumentException();

        //        var account = new Account();
        //        //account.Name = reader["Name"].ToString();
        //        //account.Number = reader["Number"].ToString();
        //        //account.Amount = float.Parse(reader["Amount"].ToString());
        //        return account;
        //    }
        //}

        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult Add(Account account)
        {
            if (_TestService.Add(account))
            {
                return Ok();
            }
            return BadRequest("Unable to update record");
            //account.Save();

        }

        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult Update(Guid id, Account account)
        {
            if (_TestService.Update(id, account))
            {
                return Ok();
            }
            return BadRequest("Unable to update record");
            //var existing = Get(id);
            //existing.Name = account.Name;
            //existing.Save();


        }

        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            if (_TestService.Delete(id))
            {
                return Ok();
            }
            return BadRequest("Unable to update record");
            //var existing = Get(id);
            //existing.Delete();

        }
    }
}