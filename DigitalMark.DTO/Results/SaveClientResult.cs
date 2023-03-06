using Flunt.Notifications;

namespace DigitalMark.DTO.Results
{
    public class SaveClientResult : BaseResult
    {
        public SaveClientResult(IEnumerable<Notification> notifications) : base(notifications)
        {
        }
    }
}