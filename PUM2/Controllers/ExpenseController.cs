
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
    public class ExpenseController : ApiController
    {
        private readonly EFDbContext db = new EFDbContext();
        public ExpenseController() { }

        [HttpGet]
        public IHttpActionResult GetAll()
        {           
            var _expense = db.expenses.ToList();

            if (_expense == null)
            {
                return BadRequest();
            }
            return Ok(_expense);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Expenses _expense = new Expenses();
            _expense = db.expenses.Where(x => x.id==id).FirstOrDefault();

            if (_expense == null)
            {
                return BadRequest();
            }
            return Ok(_expense);
        }
        [HttpPost]
        public IHttpActionResult Post(Expense expense)
        {
            Expenses _expense = new Expenses();
            _expense.repeatValue = expense.repeatValue;
            _expense.sourceId = expense.sourceId;
            _expense.title = expense.title;
            _expense.updatedDate = expense.updatedDate;
            _expense.value = expense.value;
            _expense.category = expense.category;
            _expense.createdDate = expense.createdDate;
            _expense.date = expense.date;
            _expense.description = expense.description;

            db.expenses.Add(_expense);
            db.SaveChanges();

            DbOperation model = new DbOperation();
            model.id = _expense.id;
            model.table = "expanse";
            GeneralController.IncreaseTransactionCounter(model);

            return Ok(_expense);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Expenses _expense = db.expenses.Find(id);
            if (_expense == null)
            {
                return BadRequest();
            }

            db.expenses.Remove(_expense);
            db.SaveChanges();

            DbOperation model = new DbOperation();
            model.id = id;
            model.table = "expanse";
            GeneralController.IncreaseTransactionCounter(model);

            return Ok(_expense);
        }

        [HttpGet]
        public IHttpActionResult clearAllData()
        {
            var query = db.expenses.ToList();

            foreach (var q in query)
            {
                db.expenses.Remove(q);
            }
            db.SaveChanges();
            return Ok("Usunięto dane z tabeli");
        }

    }
}
