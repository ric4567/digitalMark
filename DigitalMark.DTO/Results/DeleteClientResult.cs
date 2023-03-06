using Flunt.Notifications;

namespace DigitalMark.DTO.Results
{
    public class DeleteClientResult : BaseResult
    {
        public DeleteClientResult(IEnumerable<Notification> notifications) : base(notifications)
        {
        }
    }
}