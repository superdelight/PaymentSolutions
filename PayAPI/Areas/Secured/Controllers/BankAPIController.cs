using Payment.DAL.Core.Model;
using PayService.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace PayAPI.Areas.Secured.Controllers
{
    public class BankAPIController : ApiController
    {
        
        // GET: api/BankAPI
        public IEnumerable<BankDTO> Get()
        {
            try
            {
                BankService.BankServiceClient bankClient = new BankService.BankServiceClient();
                BankService.GetAllBanksRequest req = new BankService.GetAllBanksRequest();
                var resp = bankClient.GetAllBanks(req);
                return resp.GetAllBanksResult.Result;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        
        // GET: api/BankAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BankAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BankAPI/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/BankAPI/5
        public void Delete(int id)
        {
        }
    }
}
