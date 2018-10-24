using System;

namespace DesignPatternPlayground.SOLID
{
    /*
     * Principle is applied after 1 (Single Responsibility Principle), again this principle is 
     * related to Designing module, class or function. But it about closing already designed thing for 
     * modification but opening designed thing for extension i.e. extending functionality. 
     * So this principle is about extension.
     */
    public class GoldCustomer : Customer
    {
        public override double CalculateDiscont()
        {
            return base.CalculateDiscont() + 10;
        }
    }
    public class Customer
    {
        public virtual double CalculateDiscont()
        {
            return 0;
        }
       
    }

}
