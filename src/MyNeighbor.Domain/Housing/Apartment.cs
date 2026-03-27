namespace MyNeighbor.Domain.Housing;

using MyNeighbor.Domain.Common;

public class Apartment : Entity
{
    public int Number { get; private set; }
    public int Floor { get; private set; }
    public Guid BuildingId { get; private set; }
    public Guid? ResidentId { get; private set; }
    public bool IsOccupied => ResidentId.HasValue;

    private Apartment() { }

    internal static Apartment Create(int number, int floor, Guid buildingId)
    {
        return new Apartment
        {
            Id = Guid.NewGuid(),
            Number = number,
            Floor = floor,
            BuildingId = buildingId
        };
    }

    internal void AssignResident(Guid residentId)
    {
        if (IsOccupied)
            throw new InvalidOperationException($"Apartment {Number} is already occupied");

        ResidentId = residentId;
    }
}