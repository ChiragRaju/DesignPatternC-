using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{

    // defination 
     //The Observer Pattern is a design pattern where an object (Subject) maintains a list of dependents (Observers) and automatically notifies them when its state changes.
    internal class ObserverPattern
    {
        public interface ISubscriber
        {
            void Update(string message);
        }

        // Concrete Observer
        public class UserSubscriber : ISubscriber
        {
            private string _userName;

            public UserSubscriber(string userName)
            {
                _userName = userName;
            }

            public void Update(string message)
            {
                Console.WriteLine($"{_userName} received notification: {message}");
            }
        }

        // Subject Interface
        public interface INotificationService
        {
            void Subscribe(ISubscriber subscriber);
            void Unsubscribe(ISubscriber subscriber);
            void Notify(string message);
        }

        // Concrete Subject
        public class NotificationService : INotificationService
        {
            private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();

            public void Subscribe(ISubscriber subscriber)
            {
                _subscribers.Add(subscriber);
                Console.WriteLine("New subscriber added.");
            }

            public void Unsubscribe(ISubscriber subscriber)
            {
                _subscribers.Remove(subscriber);
                Console.WriteLine("Subscriber removed.");
            }

            public void Notify(string message)
            {
                foreach (var subscriber in _subscribers)
                {
                    subscriber.Update(message);
                }
            }
        }

        // Client Code
        class Program
        {
            static void Main()
            {
                INotificationService notificationService = new NotificationService();

                ISubscriber user1 = new UserSubscriber("Alice");
                ISubscriber user2 = new UserSubscriber("Bob");

                // Users subscribe
                notificationService.Subscribe(user1);
                notificationService.Subscribe(user2);

                // Notify all subscribers
                notificationService.Notify("New blog post available!");

                // Unsubscribe a user
                notificationService.Unsubscribe(user1);

                // Notify remaining subscribers
                notificationService.Notify("New video uploaded!");
            }
        }
    }
}
