namespace MyNeighbor.Domain.Housing;

using MyNeighbor.Domain.Common;

public class Building : AggregateRoot
{
    private readonly List<Apartment> _apartments = new();

    public string Name { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<Apartment> Apartments => _apartments.AsReadOnly();

    private Building()
    {
        Name = string.Empty;
        Address = null!;
    }

    public static Building Create(string name, Address address)
    {
        return new Building
        {
            Id = Guid.NewGuid(),
            Name = name,
            Address = address
        };
    }

    public void AddApartment(int number, int floor)
    {
        if (_apartments.Any(a => a.Number == number))
            throw new InvalidOperationException($"Apartment {number} already exists");

        var apartment = Apartment.Create(number, floor, Id);
        _apartments.Add(apartment);
    }

    public void AssignResident(int apartmentNumber, Guid residentId)
    {
        var apartment = _apartments.FirstOrDefault(a => a.Number == apartmentNumber)
            ?? throw new InvalidOperationException($"Apartment {apartmentNumber} not found");

        apartment.AssignResident(residentId);
    }
}