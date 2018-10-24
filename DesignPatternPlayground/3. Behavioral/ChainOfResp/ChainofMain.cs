using DesignPatternPlayground_Behavioral.ChainOfResp;
using System;

namespace DesignPatternPlayground.Behavioral.ChainOfResp
{
    public class ChainOfMain
    {
        public static void Main1()
        {

            var william = new ExpenseHandler(new Employee("William Worker", Decimal.Zero));
            var mary = new ExpenseHandler(new Employee("Mary Manager", new Decimal(1000)));
            var victor = new ExpenseHandler(new Employee("Victor Vicepres", new Decimal(5000)));
            var paula = new ExpenseHandler(new Employee("Paula President", new Decimal(20000)));

            william.RegisterNext(mary);
            mary.RegisterNext(victor);
            victor.RegisterNext(paula);

            Decimal expenseReportAmount;
            if (ConsoleInput.TryReadDecimal("Expense report amount:", out expenseReportAmount))
            {
                IExpenseReport expense = new ExpenseReport(expenseReportAmount);

                ApprovalResponse response = william.Approve(expense);

                Console.WriteLine("The request was {0}.", response);
            }
        }
    }
}

