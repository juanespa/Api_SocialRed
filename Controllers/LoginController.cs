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
    
    public class LoginController : ApiController
    {
        [EnableCors("*", "*", "*")]
        public IHttpActionResult GetAllUsers()
        {

            List<User> Lst = null;
            using (var ctx = new SocialEntities())
            {
                Lst = ctx.User.ToList();
            }

            if (Lst.Count == 0)
            {
                return Content(HttpStatusCode.NotFound, "No tiene Usuarios");
            }

            return Ok(Lst);
        }


        //public IHttpActionResult PostLogin(User user)
        //{



        //    return Ok("probando");
        //}
        [EnableCors("*", "*", "*")]
        public IHttpActionResult GetLogin(string user, string pass)
        {
            User users = null;
            using (var ctx = new SocialEntities())
            {
                users = ctx.User.FirstOrDefault(x => x.Email == user && x.Password == pass);

                if (users != null )
                {
                    if (users.Email == user && users.Password == pass)
                    {
                        return Ok(users);
                    }
                } else
                {
                    return Content(HttpStatusCode.NotFound, users);
                }

            }


              

            return Ok("probando 2");
        }

    }
}
