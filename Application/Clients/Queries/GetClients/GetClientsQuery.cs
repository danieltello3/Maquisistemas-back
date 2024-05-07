using System;
using System.Collections.Generic;
using Application.Abstractions.Messaging;

namespace Application.Clients.Queries.GetClients;

public sealed record GetClientsQuery() : IQuery<IReadOnlyCollection<ClientsResponse>>;


