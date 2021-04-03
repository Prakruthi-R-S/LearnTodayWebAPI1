using LearnTodayWebAPI1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnTodayWebAPI1.Controllers
{
    public class StudentController : ApiController
    {
        public IEnumerable<Course> Get()
        {
            using (LearnTodayWebAPIDb1Context dbContext = new LearnTodayWebAPIDb1Context())
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                return dbContext.Courses.ToList();
            }
        }
        public HttpResponseMessage Post([FromBody] Student student)
        {
            try
            {
                using (LearnTodayWebAPIDb1Context dbContext = new LearnTodayWebAPIDb1Context())
                {
                    dbContext.Students.Add(student);
                    dbContext.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, student);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (LearnTodayWebAPIDb1Context dbContext = new LearnTodayWebAPIDb1Context())
                {
                    var entity = dbContext.Students.FirstOrDefault(s => s.StudentId == id);
                    if (entity == null)
                    {

                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No enrollement information found");
                    }
                    else
                    {
                        dbContext.Students.Remove(entity);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);

                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
