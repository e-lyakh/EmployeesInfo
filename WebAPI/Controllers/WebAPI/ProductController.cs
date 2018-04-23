using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers.WebAPI
{
    public class ProductController : ApiController
    {
        static ProductRepository ProductRep = new ProductRepository();
        public HttpResponseMessage GetAll()
        {
            try
            {
                var list = ProductRep.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Not Get Data");
            }
        }


        public HttpResponseMessage Post([FromBody]Product product)
        {
            try
            {
                Product tmp = ProductRep.Add(product);
                string url = Url.Link("DefaultApi", new { id = tmp.Id });
                HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.Created, tmp);
                msg.Headers.Location = new Uri(url);
                return msg;
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, "Conflict");
            }
        }
    }
}
