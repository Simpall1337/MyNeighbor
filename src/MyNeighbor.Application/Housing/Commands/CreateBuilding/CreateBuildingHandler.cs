using MediatR;
using MyNeighbor.Application.Common;
using MyNeighbor.Application.Common.Interfaces;
using MyNeighbor.Domain.Housing;

namespace MyNeighbor.Application.Housing.Commands.CreateBuilding
{
    public class CreateBuildingHandler(IApplicationDbContext context) : IRequestHandler<CreateBuildingCommand, Result<Guid>>
    {

        public async Task<Result<Guid>> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.City, request.Street, request.HouseNumber);
            var building = Building.Create(request.Name, address);

            try
            {
                context.Buildings.Add(building);
                await context.SaveChangesAsync(cancellationToken);
                return Result<Guid>.Success(building.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure(ex.Message);
            }
        }
    }
}
