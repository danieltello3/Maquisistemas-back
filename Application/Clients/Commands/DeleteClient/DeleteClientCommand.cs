using System;
using Application.Abstractions.Messaging;
using MediatR;

namespace Application.Clients.Commands.DeleteClient;

public sealed record DeleteClientCommand(Guid ClientId) : ICommand<Unit>;