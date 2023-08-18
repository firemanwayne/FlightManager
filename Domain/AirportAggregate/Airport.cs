using AirportManagement.Shared;
using System.Text.Json.Serialization;

namespace AirportManagement.Domain
{
    public class Airport : AirportBaseModel
    {
        public Airport() { }

        public Airport(string name, string fAAId, string city, string state) : base(fAAId)
        {
            Name = name;
            FAAIdentifier = fAAId;
            CityName = city;
            State = state;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("fAAIdentifier")]
        public string FAAIdentifier { get; set; } = string.Empty;

        [JsonPropertyName("cityName")]
        public string CityName { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        public Airport this[string fAAId] => GetAirport(fAAId);

        public static Airport GetAirport(string fAAId) => Airports.USAirports.First(a => a.Id.Equals(fAAId));
    }

    public readonly struct Airports
    {
        public static IEnumerable<Airport> GetUsAirports => USAirports;

        internal static readonly IList<Airport> USAirports = new List<Airport>()
        {
            ////ALABAMA
            new Airport("Birmingham–Shuttlesworth International Airport", "BHM", "Birmingham", "Al"),
            new Airport("Dothan Regional Airport", "DHN", "Dothan", "Al"),
            new Airport("Huntsville International Airport", "HSV", "Huntsville", "Al"),
            new Airport("Mobile Regional Airport", "MOB", "Mobile", "Al"),
            new Airport("Montgomery Regional Airport", "MGM", "Montgomery", "Al"),

            ////ARIZONA
            new Airport("Phoenix Sky Harbor International Airport", "PHX", "Phoenix", "Az"),

            ////FLORIDA
            new Airport("Miami International Airport", "MIA", "Miami", "Fl"),

            ////MARYLAND
            new Airport("Baltimore/Washington International Airport", "BWI", "Baltimore", "Md"),

            ////NEW York
            new Airport("John F. Kennedy International Airport (was New York International Airport)", "JFK", "New York", "Ny"),
            new Airport("LaGuardia Airport (and Marine Air Terminal)", "LGA", "New York", "Ny"),

            ////TENNESSEE
            new Airport("Chattanooga Metropolitan Airport (Lovell Field)","CHA","Chattanooga","Tn"),
            new Airport("McGhee Tyson Airport","TYS","Knoxville","Tn"),
            new Airport("Memphis International Airport","MEM","Memphis","Tn"),
            new Airport("Nashville International Airport (Berry Field)","BNA","Nashville","Tn"),
            new Airport("Tri-Cities Regional Airport (Tri-Cities Regional TN/VA)","TRI","Tri-Cities","Tn"),

            ////TEXAS
            new Airport("Abilene Regional Airport", "ABI", "Abilene", "Tx"),
            new Airport("Rick Husband Amarillo International Airport", "AMA", "Amarillo", "Tx"),
            new Airport("Austin–Bergstrom International Airport", "AUS", "Austin", "Tx"),
            new Airport("Jack Brooks Regional Airport (was Southeast Texas Regional)", "BPT", "Beaumont", "Tx"),
            new Airport("Brownsville/South Padre Island International Airport", "BRO", "Brownsville", "Tx"),
            new Airport("Easterwood Airport (Easterwood Field)", "CLL", "College Station", "Tx"),
            new Airport("Corpus Christi International Airport", "CRP", "Corpus Christi", "Tx"),
            new Airport("Dallas Love Field", "DAL", "Dallas", "Tx"),
            new Airport("Dallas/Fort Worth International Airport", "DFW", "Dallas", "Tx"),
            new Airport("El Paso International Airport", "ELP", "El Paso", "Tx"),
            new Airport("Valley International Airport", "HRL", "Harlingen", "Tx"),
            new Airport("George Bush Intercontinental Airport", "IAH", "Houston", "Tx"),
            new Airport("William P. Hobby Airport", "HOU", "Houston", "Tx"),
            new Airport("Killeen–Fort Hood Regional Airport/Robert Gray Army Airfield", "GRK", "Killeen", "Tx"),
            new Airport("Laredo International Airport", "LRD", "Laredo", "Tx"),
            new Airport("East Texas Regional Airport", "GGG", "Longview", "Tx"),
            new Airport("Lubbock Preston Smith International Airport", "LBB", "Lubbock", "Tx"),
            new Airport("McAllen Miller International Airport", "MFE", "McAllen", "Tx"),
            new Airport("Midland International Air and Space Port", "MAF", "Midland/Odessa", "Tx"),
            new Airport("San Angelo Regional Airport (Mathis Field)", "SJT", "San Angelo", "Tx"),
            new Airport("San Antonio International Airport", "SAT", "San Antonio", "Tx"),
            new Airport("Tyler Pounds Regional Airport", "TYR", "Tyler", "Tx"),
            new Airport("Waco Regional Airport", "ACT", "Waco", "Tx"),
            new Airport("Wichita Falls Regional Airport/Sheppard Air Force Base", "SPS", "Wichita Falls", "Tx"),
        };        
    }
}
