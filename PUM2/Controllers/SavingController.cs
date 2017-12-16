using DomainModel;
using PUM2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UnitOfWork.Concrete;

namespace PUM2.Controllers
{
    public class SavingController:ApiController
    {
        private readonly EFDbContext db = new EFDbContext();

        public SavingController() { }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Savings _saving = new Savings();
            _saving = db.savings.Where(x => x.id == id).FirstOrDefault();

            if (_saving == null)
            {
                return BadRequest();
            }
            return Ok(_saving);
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
        
           var _saving = db.savings.ToList();

            if (_saving == null)
            {
                return BadRequest();
            }
            return Ok(_saving);
        }
        [HttpPost]
        public IHttpActionResult Post(Saving saving)
        {
            Savings _saving = new Savings();
            _saving.image = saving.image;
            _saving.title = saving.title;
            _saving.updatedDate = saving.updatedDate;
            _saving.value = saving.value;
            _saving.createdDate = saving.createdDate;
            _saving.date = saving.date;
            _saving.description = saving.description;

            db.savings.Add(_saving);
            db.SaveChanges();

            return Ok(_saving);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Savings _saving = db.savings.Find(id);
            if (_saving == null)
            {
                return BadRequest();
            }

            db.savings.Remove(_saving);
            db.SaveChanges();
            return Ok(_saving);
        }

    }
}