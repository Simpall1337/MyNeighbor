using MediatR;
using MyNeighbor.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNeighbor.Application.Housing.Commands.AddApartment
{
    public record AddApartmentCommand(Guid BuildingId, int Number, int Floor) : IRequest<Result<Unit>>;
}
