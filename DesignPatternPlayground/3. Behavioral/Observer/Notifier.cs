using System.Collections;

namespace DesignPatternPlayground
{
    public class Notifier
    {
        public ArrayList notificationList = new ArrayList();

        public void AddNotification(INotification obj)
        {
            notificationList.Add(obj);
        }

        public void RemoveNotification(INotification obj)
        {
            notificationList.Remove(obj);
        }

        public void NotifyAll()
        {
            foreach (INotification notify in notificationList)
            {
                notify.Notify();
            }
        }
    }
}
