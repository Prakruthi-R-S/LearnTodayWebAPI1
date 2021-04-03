using LearnTodayWebAPI1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnTodayWebAPI1.Controllers
{
    public class TrainerController : ApiController
    {
        public HttpResponseMessage Put(int id, [FromBody] Trainer trainer)
        {
            try
            {
                using (LearnTodayWebAPIDb1Context dbContext = new LearnTodayWebAPIDb1Context())
                {
                    var entity = dbContext.Trainers.FirstOrDefault(s => s.TrainerId == id);
                    if (entity == null)
                    {

                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Searched data not found");
                    }
                    else
                    {
                        entity.Password = trainer.Password;
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);

                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Post([FromBody] Trainer trainer)
        {
            try
            {
                using (LearnTodayWebAPIDb1Context dbContext = new LearnTodayWebAPIDb1Context())
                {
                    dbContext.Trainers.Add(trainer);
                    dbContext.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, trainer);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
