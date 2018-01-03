using System;
using System.Collection.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace carsData.Controllers
{
    public class AuthController : ApiController
    {
        [RoutePrefix("api/auth")]
        public class LoginRequest
        {
            public string UserName {get; set;}
            public string Password {get; set;}
        }
        [Route("login"), HttpPost]
        public HttpReponseMessage Login(LoginRequest req)
        {
            var authService = new AuthService();
            var userId = authService.GetUserId(req.UserName, req.Password);

            if (userId.HasValue)
            {
                FormsAuthentication.SetAuthCookie(userId.ToString(), createPersistentCookie: true);
                return Request.CreateResponse(HttpStatusCode.OK,($"user with id {userId} has logged in"));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid login");
            }
        }
        [Route("newUser"), HttpPost]
        public HttpReponseMessage Create(loginRequest req)
        {
            var authService = new AuthService();
            var Id = authService.CreateUser(req.UserName, req.Password);

            if (Id.HasValue)
            {
                FormsAuthentication.SetAuthCookie(Id.ToString(), createPersistentCookie: true);
                return Request.CreateResponse(HttpStatusCode.OK, ($"user with the id {Id} has logged in"));
            }
            else
            {
                return Request.CreateErrorReponse(HttpStatusCode.BadRequest, "Invalid login");
            }
        }
        [Route("test"), HttpGet, Authorize]
        public Object ShowId()
        {
            HttpContext.Current.Response.AddHeader("X-Congrats", "You're in!");
            reutn User.Identity.Name;
        }
    }
}