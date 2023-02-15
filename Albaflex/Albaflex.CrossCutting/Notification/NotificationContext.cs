using System.Net;

namespace Albaflex.CrossCutting.Notification
{
    public class NotificationContext
    {
        private readonly List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasErrorNotifications => _notifications.Any(x => x.Key.Equals(HttpStatusCode.BadRequest));

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(HttpStatusCode key, string message)
        {
            _notifications.Add(new Notification(key, message));
        }
    }
}
