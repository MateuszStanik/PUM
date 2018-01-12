using DomainModel;
using PUM2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using UnitOfWork.Concrete;

namespace PUM2.Controllers
{
    public class GeneralController : ApiController
    {
        private readonly EFDbContext db = new EFDbContext();

        [HttpGet]
        public IHttpActionResult getLastActions()
        {
            var db_object = db.incomes.ToList().OrderByDescending(x => x.createdDate).Take(5);

           
            return Ok(db_object);
        }
 
        public string IncreaseTransactionCounter()
        {
            var session = HttpContext.Current.Session;

            if (session["actions"] == null)
                session["actions"] = "1";
            else
            {
                int x;
                var tmp = session["actions"].ToString();
                Int32.TryParse(tmp, out x);
                x++;
                session["actions"] = x.ToString();
            }

            return session["actions"].ToString();

        }

        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
            var session = HttpContext.Current.Session;
            
                if (session["username"] == null)
                    session["username"] = "sesja: " + DateTime.Now.ToString();
                return session["username"].ToString();
          
        }
    }
}