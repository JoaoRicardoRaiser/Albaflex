using System.Net;

namespace Albaflex.CrossCutting.Notification
{
    public class Notification
    {
        public HttpStatusCode Key { get; }
        public string Message { get; }

        public Notification(HttpStatusCode key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
