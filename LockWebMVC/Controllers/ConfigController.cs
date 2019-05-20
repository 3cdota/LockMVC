using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LockWebMVC.Controllers
{
    public class ConfigController : ApiController
    {
        private LockEntities db = new LockEntities();
        private  const string KEY= "3bzgyxzm";
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/config/endTime")]

        public object GetEndTime ()
        {
            // return new DateTime(2019, 7, 16);
          string licence =db.LockConfigs.First(x => true).Licence;
            return Decode(licence,KEY);
         
        }
        [HttpGet]
        [Route("api/config/encode")]

        public String Encode (string str, string key)
        {
            return Encrypt.EncryptDES(str, key);

        }

        [HttpGet]
        [Route("api/config/decode")]

        public String Decode (string str, string key)
        {
            return Encrypt.DecryptDES(str, key);

        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    }
}