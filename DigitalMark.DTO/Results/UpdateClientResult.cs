using Flunt.Notifications;

namespace DigitalMark.DTO.Results
{
    public class UpdateClientResult : BaseResult
    {
        public UpdateClientResult(IEnumerable<Notification> notifications) : base(notifications)
        {
        }
    }
}