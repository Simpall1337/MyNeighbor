using MediatR;
using MyNeighbor.Application.Common.Interfaces;
using MyNeighbor.Domain.Housing;

namespace MyNeighbor.Application.Housing.Commands.CreateBuilding
{
    public class CreateBuildingHandler(IApplicationDbContext context) : IRequestHandler<CreateBuildingCommand, Guid>
    {

        public async Task<Guid> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.City, request.Street, request.HouseNumber);
            var building = Building.Create(request.Name, address);

            context.Buildings.Add(building);
            await context.SaveChangesAsync(cancellationToken);

            return building.Id;
        }
    }
}
