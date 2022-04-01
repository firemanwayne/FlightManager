using System.Net.Http.Json;

namespace Events.Shared
{
    public class FlightHttpClient
    {
        readonly HttpClient _http;

        public FlightHttpClient(HttpClient _http)
        {
            this._http = _http ?? throw new ArgumentNullException(nameof(_http));
        }

        public async Task<Flight> GetFlight(string id)
        {
            return await _http.GetFromJsonAsync<Flight>($"/api/flights/get/{id}");
        }

        public async Task<Flight[]> GetFlights()
        {            
            return await _http.GetFromJsonAsync<Flight[]>("/api/flights");                            
        }

        public async Task AddFlight(CreateFlightCommand cmd)
        {
            await _http.PostAsJsonAsync($"api/flights/add", cmd);
        }

        public async Task UpdateStatus(UpdateFlightStatusCommand cmd)
        {
            await _http.PostAsJsonAsync("api/flights/update", cmd);
        }

        public async Task DelayFlight(DelayFlightCommand cmd)
        {
            await _http.PostAsJsonAsync("api/flights/delay", cmd);
        }

        public async Task DeleteFlight(DeleteFlightCommand cmd)
        {
            await _http.PostAsJsonAsync("api/flights/delete", cmd);
        }
    }
}
