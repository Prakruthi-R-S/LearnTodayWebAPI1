using LearnTodayWebAPI1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnTodayWebAPI1.Controllers
{
    public class AdminController : ApiController
    {
        public IEnumerable<Course> Get()
        {

            using (LearnTodayWebAPIDb1Context dbContext = new LearnTodayWebAPIDb1Context())
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                return dbContext.Courses.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (LearnTodayWebAPIDb1Context dbContext = new LearnTodayWebAPIDb1Context())
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                var entity = dbContext.Courses.FirstOrDefault(s => s.CourseId == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Searched data not found");
                }
            }
        }
    }
}
