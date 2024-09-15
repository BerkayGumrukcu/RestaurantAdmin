using Entities.Models;
using Entities.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.MediaServices.Client.ContentKeyAuthorization;
using System.Runtime.CompilerServices;
using System.Web.Http;
using UI.Models;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace UI.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        internal class RestaurantEntities
        {
            //Db sıkıntısından
        }
        RestaurantEntities db = new RestaurantEntities();
        Response response = new Response();

        [HttpPost, Route("addNewCategory")]
        public HttpResponseMessage addNewCategory([FromBody] Category category)
        {
            try
            {
                var token = Request.Headers.GetValues("Authorization").First();
                TokenClaim tokenClaim = TokenManager.ValidateToken(token);
                //tokenclaim.role != "admin"
                if (true)
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
                db.Categories.Add(category);
                db.SaveChanges();
                response.message = "Kategori eklendi.";
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
