using Web.Server.Hubs;
using AirportManagement.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using AirportManagement.Domain;

namespace Web.Server.Controllers
{
    [ApiController]
    [Route("api/{controller}/{action?}")]
    public class FlightsController : ControllerBase
    {        
        readonly IHubContext<FlightHub> _ctx;
        readonly IFlightManager _service;

        public FlightsController(
            IFlightManager _service,
            IHubContext<FlightHub> _ctx) : base()
        {            
            this._ctx = _ctx;
            this._service = _service;                        
        }

        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return _service.GetFlights(null);
        }

        [HttpGet("{id}")]
        [ActionName("get")]
        public Flight GetSingle(string id)
        {
            var flight = _service.GetFlights(a => a.Id.Equals(id))
                .FirstOrDefault();

            if (flight != null)
                return flight;
            else
                return null;
        }

        [HttpPost]
        [ActionName("add")]
        public async void Add([FromBody] CreateFlight cmd)
        {
            _service.Handle(cmd);

            await _ctx.Clients.All.SendAsync("Update");
        }

        [HttpPost]
        [ActionName("update")]
        public async void Update([FromBody] UpdateFlightStatus cmd)
        {
            _service.Handle(cmd);

            await _ctx.Clients.All.SendAsync("Update");
        }

        [HttpPost]
        [ActionName("delay")]
        public async void Delay([FromBody] DelayFlight cmd)
        {
            _service.Handle(cmd);

            await _ctx.Clients.All.SendAsync("Update");
        }

        [HttpPost]
        [ActionName("delete")]
        public async void Delete([FromBody] DeleteFlight cmd)
        {
            _service.Handle(cmd);

            await _ctx.Clients.All.SendAsync("Update");
        }
    }
}
