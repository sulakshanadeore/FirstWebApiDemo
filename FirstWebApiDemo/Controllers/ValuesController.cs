using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApiDemo.Controllers
{
    public class ValuesController : ApiController
    {

        static string[] greetings = new string[] {"Hello","Hi","",""};
        // GET api/values
        public IEnumerable<string> Get()
        {
            return greetings;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return greetings[id];   
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            int cnt=greetings.Count();
            cnt--;
            greetings[cnt]=value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            greetings[id]=value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            greetings[id] = null;

        }
    }
}
