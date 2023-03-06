using Flunt.Notifications;

namespace DigitalMark.DTO.Results
{
    public class BaseResult
    {
        public BaseResult(IEnumerable<Notification> notifications)
        {
            Notifications = notifications.ToList();
        }

        public bool IsSuccess => Notifications?.Count == 0;
        public List<Notification> Notifications { get; }
    }
}