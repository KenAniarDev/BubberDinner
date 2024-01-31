
namespace BuberDinner.Domain.Dinners.ValueObjects;

public sealed class Location 
{
    public string Name { get; }
    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }
                           
    public Location(string name, string address, double latitude, double longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }
}
