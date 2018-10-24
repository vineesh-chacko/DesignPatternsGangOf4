namespace DesignPatternPlayground_Behavioral.ChainOfResp
{
    public interface IExpenseHandler
    {
        ApprovalResponse Approve(IExpenseReport expenseReport);
        void RegisterNext(IExpenseHandler next);
    }
}