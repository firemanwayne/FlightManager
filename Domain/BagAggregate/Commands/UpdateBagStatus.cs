namespace AirportManagement.Shared
{
    public class UpdateBagStatus : ICommand
    {
        public UpdateBagStatus(string bagId, BagStatus status)
        {
            BagId = bagId;
            Status = status;
        }

        public string BagId { get; }

        public BagStatus Status { get; }
    }
}