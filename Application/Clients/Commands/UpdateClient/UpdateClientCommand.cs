using System;
using Application.Abstractions.Messaging;

namespace Application.Clients.Commands.UpdateClient;

#nullable enable
public sealed record UpdateClientCommand(Guid Id, string? Nombres, string? Apellidos, DateTime? FechaNacimiento) : ICommand<Guid>;