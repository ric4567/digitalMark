using Flunt.Notifications;

namespace DigitalMark.DTO.Results
{
    public class SaveProjectResult : BaseResult
    {
        public SaveProjectResult(IEnumerable<Notification> notifications) : base(notifications)
        {
        }
    }
}