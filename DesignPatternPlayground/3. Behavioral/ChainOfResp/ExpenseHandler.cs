using System;

namespace DesignPatternPlayground_Behavioral.ChainOfResp
{
    public class ExpenseHandler :IExpenseHandler
    {
        private readonly IExpenseApprover _expenseApprover;
        private IExpenseHandler _next;

        public ExpenseHandler(IExpenseApprover expenseApprover)
        {
            _expenseApprover = expenseApprover;
            _next = EndOfChainExpenseHandler.Instance;
        }
        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            ApprovalResponse response = _expenseApprover.ApproveExpense(expenseReport);
            if (response==ApprovalResponse.BeyondApprovalLimit)
            {
                return _next.Approve(expenseReport);
            }
            return response;
        }

        public void RegisterNext(IExpenseHandler next)
        {
            _next = next;
        }
    }

    public enum ApprovalResponse
    {
        Denied,
        Approved,
        BeyondApprovalLimit,
    }

    public class ExpenseReport : IExpenseReport
    {
        public ExpenseReport(Decimal total)
        {
            Total = total;
        }

        public decimal Total
        {
            get;
            private set;
        }
    }

    public static class ConsoleInput
    {
        public static bool TryReadDecimal(string prompt, out Decimal value)
        {
            value = default(Decimal);

            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    return false;
                }

                try
                {
                    value = Convert.ToDecimal(input);
                    return true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The input is not a valid decimal.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The input is not a valid decimal.");
                }
            }
        }
    }
}
