namespace AirportManagement.Domain;

public delegate void FlightCreatedEventHandler(object o, FlightCreatedEventArgs e);
public delegate void FlightChangedEventHandler(object o, FlightChangedEventArgs e);