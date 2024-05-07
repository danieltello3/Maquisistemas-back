using System;
namespace Application.Clients.Commands.UpdateClient;

#nullable enable
public sealed record UpdateClientRequest(Guid Id, string? Nombres, string? Apellidos, DateTime? FechaNacimiento);