using System;

namespace DesignPatternPlayground.SOLID
{
    //Principle is related to substitution of child in place of its parent. 
    //So principle is about relationship i.e. inheritance.
    public class LGoldCustomer : ICustomer
    {
        public double CalculateDiscount()
        {
            return 10;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }
    }
    public class LEnquiryCustomer : IEnquiry
    {
        public double CalculateDiscount()
        {
            return 10;
        }
    }

    public interface IEnquiry
    {
        double CalculateDiscount();
    }
    public interface ICustomer : IEnquiry
    {
        void Add();
    }
    public class LCustomer
    {
        protected virtual void Add()
        {
            
        }
        protected virtual double CalculateDiscont()
        {
            return 0;
        }

    }
}
