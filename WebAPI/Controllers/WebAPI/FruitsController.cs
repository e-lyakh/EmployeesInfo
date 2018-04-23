using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers.WebAPI
{
    public class FruitsController : ApiController
    {
        static List<string> fruits = new List<string>()
        {
            "Apple", "Banana", "Pineapple", "Orange"
        };
        // 1. Если имя метода соотв. GET, POST, PUT, DELETE
        // 2. Если имя метода начинается на  GET, POST, PUT, DELETE
        // 3. Если есть аттрибут  HttpGet, HttpPost, HttpPut, HttpDelete
        public IEnumerable<string> GetAll()
        {
            return fruits;
        }

        public HttpResponseMessage Get(int id)
        {
            if (id < fruits.Count)
                return Request.CreateResponse(HttpStatusCode.OK, fruits[id]);

            return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
        }

        [HttpPost]
        public HttpResponseMessage Add([FromBody]string fruit)
        {
            try
            {
                fruits.Add(fruit);
                string url = Url.Link("DefaultApi", new { id = fruits.Count - 1 });
                HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.Created, fruit);
                msg.Headers.Location = new Uri(url);
                return msg;
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
            }
        }
        public HttpResponseMessage Put(int id, [FromBody] string fruit)
        {
            if (id >= fruits.Count)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            try
            {
                fruits[id] = fruit;
                return Request.CreateResponse(HttpStatusCode.OK, fruits[id]);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            if (id >= fruits.Count)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            string tmp = fruits[id];
            fruits.RemoveAt(id);
            return Request.CreateResponse(HttpStatusCode.OK, tmp);
        }

    }
}
