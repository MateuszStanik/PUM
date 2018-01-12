using DomainModel;
using PUM2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnitOfWork.Concrete;

namespace PUM2.Controllers
{
    public class IncomesController : ApiController
    {
        private readonly EFDbContext db = new EFDbContext();

        [HttpGet]
        public IHttpActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Incomes _income = new Incomes();
            _income = db.incomes.Where(x => x.id == id).FirstOrDefault();

            if (_income == null)
            {
                return BadRequest();
            }
            return Ok(_income);
        }


        [HttpGet]
        public IHttpActionResult GetAll()
        {
          var _income = db.incomes.ToList();

            if (_income == null)
            {
                return BadRequest();
            }
            return Ok(_income);
        }

        [HttpPost]
        public IHttpActionResult Post(Income incomes)
        {
            Incomes _incomes = new Incomes();
            _incomes.createdDate = DateTime.Now;
            _incomes.date = incomes.date;
            _incomes.description = incomes.description;
            _incomes.repeatValue = incomes.repeatValue;
            _incomes.sourceId = incomes.sourceId;
            _incomes.title = incomes.title;
            _incomes.type = incomes.type;
            _incomes.updatedDate = incomes.updatedDate;
            _incomes.value = incomes.value;

            db.incomes.Add(_incomes);
            db.SaveChanges();

            return Ok(incomes);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Incomes _income = db.incomes.Find(id);
            if (_income == null)
            {
                return BadRequest();
            }

            db.incomes.Remove(_income);
            db.SaveChanges();
            return Ok(_income);
        }
    
    }
}
