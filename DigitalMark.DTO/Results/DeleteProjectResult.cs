using Flunt.Notifications;

namespace DigitalMark.DTO.Results
{
    public class DeleteProjectResult : BaseResult
    {
        public DeleteProjectResult(IEnumerable<Notification> notifications) : base(notifications)
        {
        }
    }
}