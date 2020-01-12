


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LockWebMVC.Controllers
{
    public class AuthenController : ApiController
    {
        private lockEntities db = new lockEntities();
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //GET api/<controller>/5
        public bool Get(String name, String cn)
        {
            
            var user_keyList = db.User_key.Where(x => x.DomainUser.UserName == name && x.Ukey.CN == cn).ToList();
            var userList = db.User_key.Where(x => x.DomainUser.UserName == name).ToList();
            if (userList.Count > 0)
            {
                if (user_keyList.Count > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }


        [HttpGet]
        [Route("api/authen/nokey")]
        public bool nokey (string userName)
        {
            var userList = db.DomainUsers.Where(x => x.UserName == userName).ToList();
            if(userList.Count>0)
            {
                return userList[0].NoKey;

            }
            else
            {
                return true;
            }
            

        }

        [HttpGet]
        [Route("api/authen/userInfo")]
        public DomainUser UserInof (string userName)
        {
            var userList = db.DomainUsers.Where(x => x.UserName == userName).ToList();
            if (userList.Count > 0)
            {
                return userList[0];

            }
            else
            {
                return null;
            }


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