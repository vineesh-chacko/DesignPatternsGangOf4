using System;

namespace DesignPatternPlayground_Creational
{
    class AdapterMain
    {
        //static void Main(string[] args)
        //{
        //    Client c = new Client(new Adapter());
        //    c.Request();
        //}
    }

    public class Client
    {
        private readonly ITarget iTarget;

        public Client(ITarget target)
        {
            iTarget = target;
        }

        public void Request()
        {
            iTarget.MethodB();
        }

    }

    public interface ITarget
    {
        void MethodB();
    }

    public class Adapter : ITarget
    {
        public void MethodB()
        {
            Console.WriteLine("I am method B");
        }

    }

    public class Adaptee 
    {
        private readonly Adapter adaptee = new Adapter();

        public Adaptee()
        {
            adaptee.MethodB();
        }
       
    }
}
