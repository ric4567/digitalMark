using Flunt.Notifications;

namespace DigitalMark.DTO.Results
{
    public class UpdateProjectResult : BaseResult
    {
        public UpdateProjectResult(IEnumerable<Notification> notifications) : base(notifications)
        {
        }
    }
}