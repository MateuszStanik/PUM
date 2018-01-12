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
            //var db_object = db.incomes.ToList().OrderByDescending(x => x.createdDate).Take(5);
            //DbOperation model = new DbOperation();
            //model.id = 1;
            //model.table = "incomes";
            //List<DbOperation> tmp;
            //tmp = IncreaseTransactionCounter(model);
            //return Ok(db_object);
            var session = HttpContext.Current.Session;
            if (session["actions"] != null)
            {
                List<DbOperation> listOfOperations;
                listOfOperations = (List<DbOperation>)session["actions"];
                listOfOperations.OrderByDescending(x => x.id).Take(5);
                return Ok(listOfOperations);
            }
            return BadRequest("Nie znaleziono aktywnosci podczas tej sesji");
        }
 
        public List<DbOperation> IncreaseTransactionCounter(DbOperation model)
        {
            var session = HttpContext.Current.Session;
            List<DbOperation> listOfOperations;

            if (session["actions"] == null)
            {
                listOfOperations = new List<DbOperation>();
            }
            else
            {
                listOfOperations = (List<DbOperation>)session["actions"];   
            }
            listOfOperations.Add(model);
            session["actions"] = listOfOperations;
            return (List <DbOperation>)session["actions"];
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var session = HttpContext.Current.Session;            
            if (session["username"] == null)
                session["username"] = "Sesja: " + DateTime.Now.ToString();
            return Ok(session["username"]);
          
        }
    }
}