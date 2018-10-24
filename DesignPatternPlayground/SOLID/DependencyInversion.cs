namespace DesignPatternPlayground.SOLID
{
    /*
     * Principle is related to designing decoupling modules, classes of software system. 
     * This principle mostly applied after 4 (Interface Segregation principle) because interface are one form of 
     * abstraction and this principle is related to Details (module/class) should depend on abstraction, 
     * and abstraction should not depend on detail. So this principle is about creating loosely coupled system.
     */
    public class DGoldCustomer : IRead
    {
        public double CalculateDiscount()
        {
            return 10;
        }

        public void Add()
        {
            throw new System.NotImplementedException();
        }

        public void Read()
        {
            throw new System.NotImplementedException();
        }
    }
    public class DEnquiryCustomer : IIEnquiry
    {
        public double CalculateDiscount()
        {
            return 10;
        }
    }



    public interface IDEnquiry
    {
        double CalculateDiscount();
    }
    public interface IDCustomer : IIEnquiry
    {
        void Add();
    }

    public interface IDRead : IDCustomer
    {
        void Read();
    }
    public class ID_Customer
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
