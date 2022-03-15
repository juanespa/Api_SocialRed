using Api_SocialRed.Models;
using Model_RedSocial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api_SocialRed.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [EnableCors("*", "*", "*")]
        public IHttpActionResult GetAlldatos()
        {

            List<algoo> Lst = null;
            using (var ctx = new SocialEntities())
            {
                Lst = ctx.algoo.ToList();
            }

            if (Lst.Count == 0)
            {
                return Content(HttpStatusCode.NotFound, "No tiene Usuarios");
            }

            return Ok(Lst);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        //public void Post([FromBody] string value)
        //{
        //}
        [EnableCors("*", "*", "*")]
        public IHttpActionResult PostPrueba(algoo al)
        {
            using (var context = new SocialEntities())
            {
                var datos = context.algoo.Add(new algoo()
                {
                    id = al.id,
                    name = al.name,
                    img = al.img

                });

                context.SaveChanges();

            }


            return Ok("Usuario Agregado");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
