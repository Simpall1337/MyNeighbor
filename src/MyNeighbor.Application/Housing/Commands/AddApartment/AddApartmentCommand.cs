using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MyNeighbor.Application.Housing.Commands.AddApartment
{
    public record AddApartmentCommand(Guid BuildingId, int Number, int Floor) : IRequest;
}
