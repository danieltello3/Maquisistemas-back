using System;
using Application.Abstractions.Messaging;

namespace Application.Clients.Queries.GetClientById;

public sealed record  GetClientByIdQuery(Guid ClientId) : IQuery<ClientResponse>;


