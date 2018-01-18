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
        public IHttpActionResult getStats(int year, int month, int day)
        {
            double sumOfIncomes = 0;
            int counterIncomes = 0;
            double sumOfExpanses  = 0;
            int counterExpanses = 0;
            double sumOfSavings = 0;
            int counterSavings = 0;
            decimal avgIncomes = 0;
            decimal avgExpanses = 0;
            decimal avgSavings = 0;
            TransactionStats TS = new TransactionStats();             

            if ((year == 0) && (month == 0) && (day == 0))
                return BadRequest("Nie podano właściwych parametrów metody!");
            if ((month!=0) && (day == 0))
            {
                DateTime date = new DateTime(year, month, 1);
                DateTime dateEnd = new DateTime(year, month + 1, 1);

                var dbResponse = db.incomes.Where(x => (x.date >= date && x.date < dateEnd));
                var dbExpanses = db.expenses.Where(x => (x.date >= date && x.date < dateEnd));
                var dbSavings = db.savings.Where(x => (x.date >= date && x.date < dateEnd));
                foreach (var tmp in dbResponse)
                {
                    sumOfIncomes += tmp.value;
                    counterIncomes += 1;
                }
                foreach (var tmp in dbExpanses)
                {
                    sumOfExpanses += tmp.value;
                    counterExpanses += 1;
                }
                foreach (var tmp in dbSavings)
                {
                    sumOfSavings += tmp.value;
                    counterSavings += 1;
                }

                TS.incomeInputAvg = sumOfIncomes / counterIncomes;
                if (Double.IsNaN(TS.incomeInputAvg))
                {
                    TS.incomeInputAvg = 0.0;
                }
                TS.expenseInputAvg = sumOfExpanses / counterExpanses;
                if (Double.IsNaN(TS.expenseInputAvg))
                {
                    TS.expenseInputAvg = 0.0;
                }
                TS.savingAvg = sumOfSavings / counterSavings;
                if (Double.IsNaN(TS.savingAvg))
                {
                    TS.savingAvg = 0.0;
                }
                TS.year = year;
                TS.month = month;
                TS.day = 0;
                TS.expenseSum = sumOfExpanses;
                TS.incomeSum = sumOfIncomes;
                TS.savingFinished = counterSavings;
                TS.incomeInput = counterIncomes;
                TS.expenseInput = counterExpanses;
            }
            if ((month == 0) && (day == 0))
            {
                DateTime date = new DateTime(year,1,1);
                DateTime dateEnd = new DateTime(year+1, 1, 1);
             
                var dbResponse = db.incomes.Where(x => (x.date>=date && x.date < dateEnd));
                var dbExpanses = db.expenses.Where(x => (x.date >= date && x.date < dateEnd));
                var dbSavings = db.savings.Where(x => (x.date >= date && x.date < dateEnd));
                foreach ( var tmp in dbResponse)
                {
                    sumOfIncomes += tmp.value;
                    counterIncomes += 1;
                }
                foreach (var tmp in dbExpanses)
                {
                    sumOfExpanses += tmp.value;
                    counterExpanses += 1;
                }
                foreach (var tmp in dbSavings)
                {
                    sumOfSavings += tmp.value;
                    counterSavings += 1;
                }

                TS.incomeInputAvg = sumOfIncomes / counterIncomes;
                if(Double.IsNaN(TS.incomeInputAvg))
                {
                    TS.incomeInputAvg = 0.0;
                }
                TS.expenseInputAvg = sumOfExpanses / counterExpanses;
                if (Double.IsNaN(TS.expenseInputAvg))
                {
                    TS.expenseInputAvg = 0.0;
                }
                TS.savingAvg = sumOfSavings / counterSavings;
                if (Double.IsNaN(TS.savingAvg))
                {
                    TS.savingAvg = 0.0;
                }
                TS.year = year;
                TS.month = 0;
                TS.day = 0;
                TS.expenseSum = sumOfExpanses;
                TS.incomeSum = sumOfIncomes;
                TS.savingFinished = counterSavings;
                TS.incomeInput = counterIncomes;
                TS.expenseInput = counterExpanses;
                
            }
            if ((month != 0) && (day != 0))
            {

                DateTime date;
                DateTime dateEnd;
                if (year> DateTime.Now.Year)
                {
                    date = new DateTime(DateTime.Now.Year, month, day);
                    dateEnd = new DateTime(DateTime.Now.Year, month, day + 1);
                }
                else
                {
                    date = new DateTime(year, month, day);
                    dateEnd = new DateTime(year, month, day + 1);
                }
                

                var dbResponse = db.incomes.Where(x => (x.date >= date && x.date < dateEnd));
                var dbExpanses = db.expenses.Where(x => (x.date >= date && x.date < dateEnd));
                var dbSavings = db.savings.Where(x => (x.date >= date && x.date < dateEnd));
                foreach (var tmp in dbResponse)
                {
                    sumOfIncomes += tmp.value;
                    counterIncomes += 1;
                }
                foreach (var tmp in dbExpanses)
                {
                    sumOfExpanses += tmp.value;
                    counterExpanses += 1;
                }
                foreach (var tmp in dbSavings)
                {
                    sumOfSavings += tmp.value;
                    counterSavings += 1;
                }

                TS.incomeInputAvg = sumOfIncomes / counterIncomes;
                if (Double.IsNaN(TS.incomeInputAvg))
                {
                    TS.incomeInputAvg = 0.0;
                }
                TS.expenseInputAvg = sumOfExpanses / counterExpanses;
                if (Double.IsNaN(TS.expenseInputAvg))
                {
                    TS.expenseInputAvg = 0.0;
                }
                TS.savingAvg = sumOfSavings / counterSavings;
                if (Double.IsNaN(TS.savingAvg))
                {
                    TS.savingAvg = 0.0;
                }
                TS.year = date.Year;
                TS.month = month;
                TS.day = day;
                TS.expenseSum = sumOfExpanses;
                TS.incomeSum = sumOfIncomes;
                TS.savingFinished = counterSavings;
                TS.incomeInput = counterIncomes;
                TS.expenseInput = counterExpanses;
            }
            return Ok(TS);
        }


        [HttpGet]
        public IHttpActionResult getLastActions()
        {
            var session = HttpContext.Current.Session;
            if (session["actions"] != null)
            {
                List<DbOperation> listOfOperations;
                listOfOperations = (List<DbOperation>)session["actions"];
                var listToPresent = listOfOperations.Skip(Math.Max(0, listOfOperations.Count() - 5)).Take(5);
                return Ok(listToPresent);
            }
            return BadRequest("Nie znaleziono aktywnosci podczas tej sesji");
        }
 
        public static List<DbOperation> IncreaseTransactionCounter(DbOperation model)
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
                //session.Timeout = 500;
                session["username"] = "Sesja: " + DateTime.Now.ToString();
            return Ok(session["username"]);
          
        }
    }
}