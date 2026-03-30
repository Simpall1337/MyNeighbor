using MediatR;
using Microsoft.EntityFrameworkCore;
using MyNeighbor.Application.Common.Interfaces;
using MyNeighbor.Application.Common.Exceptions;
using MyNeighbor.Application.Common;
namespace MyNeighbor.Application.Housing.Queries.GetBuildingById
{
    public class GetBuildingByIdHandler(IApplicationDbContext context) : IRequestHandler<GetBuildingByIdQuery, Result<BuildingDto>>
    {
        public async Task<Result<BuildingDto>> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
        {
            var building =  await context.Buildings
                .Where(b => b.Id == request.Id)
                .Select(b => new BuildingDto(
                    b.Id,
                    b.Name,
                    b.Address.City,
                    b.Address.Street,
                    b.Address.HouseNumber))
                .SingleOrDefaultAsync(cancellationToken);

            if (building == null)
                return Result<BuildingDto>.Failure($"Building {request.Id} not found");

            return Result<BuildingDto>.Success(building);
        }
    }
}
