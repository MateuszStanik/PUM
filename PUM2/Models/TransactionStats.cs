using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PUM2.Models
{
    public class TransactionStats
    {
        
	    public int year { get; set; }
	    public int month { get; set; }// dla statystyki rocznej, 1 - 12 dla miesiecznej lub dziennej
        public int day { get; set; }//dla statystyki rocznej lub miesięcznej, 1 - 31 dla dziennej
        public double expenseSum { get; set; } //suma wydatkow w danym dniu / miesiacu roku
        public double expenseSumAvg { get; set; } // srednia dla danego okresu czasu (statystyka miesieczna - srednio miesiecznie, statystyka dzienna - srednio dziennie itp.
        public double incomeSum { get; set; }
        public double incomeSumAvg { get; set; }
        public double expenseInput { get; set; }//ilosc wpisow w danym okresie czasu
        public double incomeInput { get; set; }// ilosc wpisow w danym okresie czasu
        public double expenseInputAvg { get; set; }
        public double incomeInputAvg { get; set; }
        public double savingFinished { get; set; }// ilosc zakonczonych planet oszczednosciowych (czy w danym okresie czasu konczyl sie jakis)
        public double savingAvg { get; set; } //i srednia

    }
}