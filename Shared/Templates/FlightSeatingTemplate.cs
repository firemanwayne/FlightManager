namespace Events.Shared
{
    public class FlightSeatingTemplate
    {
        int totalNumberRows = 0;
        readonly int totalSeatsPerRowFistClass = 4;
        readonly int totalSeatsPerRowCoachPlus = 6;
        readonly int totalSeatsPerRowCoach = 6;
        readonly IList<FlightSeatingRow> firstClassRows = new List<FlightSeatingRow>();
        readonly IList<FlightSeatingRow> coachPlusRows = new List<FlightSeatingRow>();
        readonly IList<FlightSeatingRow> coachRows = new List<FlightSeatingRow>();

        public FlightSeatingTemplate(int totalFirstClassSeats, int totalCoachPlusSeats, int totalCoachSeats)
        {
            if (totalFirstClassSeats % totalSeatsPerRowFistClass > 0)
                throw new ArgumentOutOfRangeException($"The value given for {nameof(totalFirstClassSeats)} must be divisible by {nameof(totalSeatsPerRowFistClass)} which is {totalSeatsPerRowFistClass}");

            if (totalCoachPlusSeats % totalSeatsPerRowCoachPlus > 0) 
                throw new($"The value given for {nameof(totalCoachPlusSeats)} must be divisible by {nameof(totalSeatsPerRowCoachPlus)} which is {totalSeatsPerRowCoachPlus}");

            if (totalCoachSeats % totalSeatsPerRowCoach > 0)
                throw new($"The value given for {nameof(totalCoachSeats)} must be divisible by {nameof(totalSeatsPerRowCoach)} which is {totalSeatsPerRowCoach}");

            TotalFistClassSeats = totalFirstClassSeats;
            TotalCoachPlusSeats = totalCoachPlusSeats;
            TotalCoachSeats = totalCoachSeats;

            CreateSeatingMap();
        }

        int TotalFistClassSeats { get; }
        int TotalCoachPlusSeats { get; }
        int TotalCoachSeats { get; }

        int TotalFistClassRows 
        {
            get 
            { 
                return TotalFistClassSeats / totalSeatsPerRowFistClass;
            }
        }
        int TotalCoachPlusRows 
        {
            get 
            {
                return TotalCoachPlusSeats / totalSeatsPerRowCoachPlus;
            }
        }
        int TotalCoachRows 
        {
            get 
            {
                return TotalCoachSeats / totalSeatsPerRowCoach;
            }
        }

        public IEnumerable<FlightSeatingRow> FirstClassRows { get => firstClassRows; }
        public IEnumerable<FlightSeatingRow> CoachPlusRows { get => coachPlusRows; }
        public IEnumerable<FlightSeatingRow> CoachRows { get => coachRows; }

        void CreateSeatingMap()
        {            
            MapFirstClass();
            MapCoachPlus();
            MapCoach();
        }

        void MapFirstClass()
        {
            for (int i = 1; i <= TotalFistClassRows; i++)
            {
                totalNumberRows++;

                var row = new FlightSeatingRow()
                {
                    RowNumber = totalNumberRows
                };

                for (int j = 0; j < totalSeatsPerRowFistClass; j++)
                {
                    var seat = new FlightSeat()
                    {
                        RowNumber = row.RowNumber,
                        SeatType = FlightSeatType.FirstClass,
                        SeatNumber = (FlightSeatNumber)Enum.Parse(typeof(FlightSeatNumber), j.ToString())
                    };

                    row.AddSeat(seat);
                }

                firstClassRows.Add(row);
            }
        }
        void MapCoachPlus()
        {
            for (int i = 1; i <= TotalCoachPlusRows; i++)
            {
                totalNumberRows++;

                var row = new FlightSeatingRow()
                {
                    RowNumber = totalNumberRows
                };

                for (int j = 0; j < totalSeatsPerRowCoachPlus; j++)
                {
                    var seat = new FlightSeat()
                    {
                        RowNumber = row.RowNumber,
                        SeatType = FlightSeatType.CoachPlus,
                        SeatNumber = (FlightSeatNumber)Enum.Parse(typeof(FlightSeatNumber), j.ToString())
                    };

                    row.AddSeat(seat);
                }

                coachPlusRows.Add(row);
            }
        }
        void MapCoach()
        {
            for (int i = 1; i <= TotalCoachRows; i++)
            {
                totalNumberRows++;

                var row = new FlightSeatingRow()
                {
                    RowNumber = totalNumberRows
                };

                for (int j = 0; j < totalSeatsPerRowCoach; j++)
                {
                    var seat = new FlightSeat()
                    {
                        RowNumber = row.RowNumber,
                        SeatType = FlightSeatType.Coach,
                        SeatNumber = (FlightSeatNumber)Enum.Parse(typeof(FlightSeatNumber), j.ToString())
                    };

                    row.AddSeat(seat);
                }

                coachRows.Add(row);
            }
        }
    }

    public class FlightSeat
    {
        public FlightSeat()
        { }

        public FlightSeat(int rowNumber, FlightSeatType seatType, FlightSeatNumber seatNumber)
        {
            RowNumber = rowNumber;
            SeatType = seatType;
            SeatNumber = seatNumber;
        }

        public int RowNumber { get; set; }
        public FlightSeatType SeatType { get; set; }
        public FlightSeatNumber SeatNumber { get; set; }
    }

    public class FlightSeatingRow
    {
        public FlightSeatingRow()
        { }

        public int RowNumber { get; set; }

        public IList<FlightSeat> Seats { get; } = new List<FlightSeat>();

        public void AddSeat(FlightSeat seat)
        {
            Seats.Add(seat);
        }
    }

    public static class Standard747Template
    {
        public static readonly FlightSeatingTemplate SeatingChart = new(totalFirstClassSeats: 16, totalCoachPlusSeats: 60, totalCoachSeats: 60);
    }
}
