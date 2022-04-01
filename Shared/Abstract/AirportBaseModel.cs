namespace Events.Shared
{
    public abstract class AirportBaseModel
    {
        public AirportBaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public AirportBaseModel(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
