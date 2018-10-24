using System;

namespace DesignPatternPlayground
{
    public class EmailNotifications : INotification
    {
        public void Notify()
        {
            Console.WriteLine("Email notification code executed.");
        }
    }

    public class EventNotification: INotification
    {
        public void Notify()
        {
            Console.WriteLine("Event notification code executed.");
        }
    }

    public class SMSNotification : INotification
    {
        public void Notify()
        {
            Console.WriteLine("SMS notification code executed.");
        }
    }
}
