using AirportManagement.Domain;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Desktop.Clients
{
    public class FlightHttpClient
    {
        readonly HttpClient _client;

        public FlightHttpClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Flight> GetFlight(string id) => await _client.GetFromJsonAsync<Flight>($"/api/flights/get/{id}");

        public async Task<Flight[]> GetFlights() => await _client.GetFromJsonAsync<Flight[]>("/api/flights");

        public async Task AddFlight(CreateFlight cmd) => await _client.PostAsJsonAsync($"api/flights/add", cmd);

        public async Task UpdateStatus(UpdateFlightStatus cmd) => await _client.PostAsJsonAsync("api/flights/update", cmd);

        public async Task DelayFlight(DelayFlight cmd) => await _client.PostAsJsonAsync("api/flights/delay", cmd);

        public async Task DeleteFlight(DeleteFlight cmd) => await _client.PostAsJsonAsync("api/flights/delete", cmd);
    }
}
