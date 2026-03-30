using MediatR;
using MyNeighbor.Application.Common;
namespace MyNeighbor.Application.Housing.Queries.GetBuildingById
{
    public record GetBuildingByIdQuery(Guid Id) : IRequest<Result<BuildingDto>>;
    public record BuildingDto(Guid Id, string Name, string City, string Street, string HouseNumber);
}
