using System;

namespace DesignPatternPlayground_Behavioral.ChainOfResp
{
    public interface IExpenseReport
    {
        Decimal Total { get; }
    }
}