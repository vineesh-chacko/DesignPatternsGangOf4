using System.Collections.Generic;

namespace DesignPatternPlayground
{
    public class VisitorDemo
    {
        #region Interfaces

        public interface IVisitor
        {
            void Visit(RealEstate realEstate);
            void Visit(BankAccount bankAcount);
            void Visit(Loan loan);
        }

        public interface IAsset
        {
            void Accept(IVisitor visitor);
        }

        #endregion


        public class IncomeVisitor : IVisitor
        {
            public double Amount;

            public void Visit(Loan loan)
            {
                Amount -= loan.MonthlyPayment;
            }

            public void Visit(BankAccount bankAcount)
            {
                Amount += bankAcount.MonthlyInterest*bankAcount.Amount;
            }

            public void Visit(RealEstate realEstate)
            {
                Amount += realEstate.Rent;
            }
        }


        public class NetWorthVisitor : IVisitor
        {
            public int Total;

            public void Visit(RealEstate realEstate)
            {
                Total += realEstate.EstimatedValue;
            }

            public void Visit(BankAccount bankAcount)
            {
                Total += bankAcount.Amount;
            }

            public void Visit(Loan loan)
            {
                Total -= loan.Owned;
            }
        }


        public class RealEstate : IAsset
        {
            public int EstimatedValue { get; set; }
            public double Rent { get; set; }

            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class BankAccount : IAsset
        {
            public int Amount { get; set; }
            public double MonthlyInterest { get; set; }
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }
        public class Loan : IAsset
        {
            public int Owned { get; set; }
            public int MonthlyPayment { get; set; }
            
            public void Accept(IVisitor visitor)
            {

                visitor.Visit(this);
            }
        }
        public class Person :IAsset
        {
            
            public List<IAsset> AssetList = new List<IAsset>();
            public void Accept(IVisitor visitor)
            {
                foreach (var asset in AssetList)
                {
                    asset.Accept(visitor);
                }
            }
        }
    }

}