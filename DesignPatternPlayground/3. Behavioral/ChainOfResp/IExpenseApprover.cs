namespace DesignPatternPlayground_Behavioral.ChainOfResp
{
    public interface IExpenseApprover
    {
        ApprovalResponse ApproveExpense(IExpenseReport expenseReport);
    }
}