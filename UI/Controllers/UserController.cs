using Entities.Models;
using Entities.Token;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace UI.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        internal class RestaurantEntities
        {
            //Db sıkıntısından
        }
        RestaurantEntities db = new RestaurantEntities();

       [HttpPost, Route("signup")]
       public HttpResponseMessage Signup([FromBody] User user)
        {
            try
            {
                User userObj = db.Users.Where(u => u.email == user.Email).FirstOrDefault();
                if (userObj == null) {
                    user.Role = "user";
                    user.Status = "false";
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, new {message = "Kayıt Başarılı"});
                }
                else
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new { message = "Email kullanılıyor." });
                }
            }
            catch (Exception e)
            {

                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost, Route("login")]
        public HttpResponseMessage Login([FromBody] User user)
        {
            try
            {
                User userObj = db.Users.Where(u => (u.email == user.Email && u.Password == user.Password)).FirstOrDefault();
                if (userObj != null)
                {
                    if (userObj.Status == "true")
                    {
                        return Request.CreateResponse(System.Net.HttpStatusCode.OK, new { token = TokenManager.GenerateToken(userObj.Email, userObj.Role) });
                    }
                    else
                    {
                        return Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new {message = "Admin yetkisi bekleyin"});
                    }
                }
                else
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new { message = "Giriş Başarısız." });
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, e);
            }
        }

        //Token işlemi bitince "getAllUser" gelecek



    }

}
