namespace DesignPatternPlayground.SOLID
{
    //Principle is related to substitution of child in place of its parent. So principle is about relationship i.e. inheritance.
    public class IGoldCustomer : IRead
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
    public class IEnquiryCustomer : IIEnquiry
    {
        public double CalculateDiscount()
        {
            return 10;
        }
    }



    public interface IIEnquiry
    {
        double CalculateDiscount();
    }
    public interface IICustomer : IIEnquiry
    {
        void Add();
    }

    public interface IRead : IICustomer
    {
        void Read();
    }
    public class ISCustomer
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
