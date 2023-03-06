namespace DigitalMark.DTO.Commands
{
    public class UpdateClientCommand : SaveClientCommand
    {
        public Guid Id { get; private set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}