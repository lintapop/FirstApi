using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstApi.Controllers
{
    public class ValuesController : ApiController
    {
        private Models.DBContext db = new Models.DBContext();

        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values
        public IHttpActionResult GetUser()
        {
            var users = db.Users.ToList();
            return Ok(users);
        }

        //GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post(string account, string password)
        {
            var user = db.Users.Where(x => x.email == account).FirstOrDefault();
            if (password == user.password)
            {
                return "successful";
            }
            return "failed";
        }

        // PUT api/values/5
        //Post要研究
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}