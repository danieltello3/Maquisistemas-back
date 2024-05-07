using System;
using Application.Abstractions.Messaging;

namespace Application.Clients.Commands.CreateClient;

public sealed record CreateClientCommand(string Nombres, string Apellidos, DateTime FechaNacimiento, int IdTipoDocumento, string NroDocumento) : ICommand<Guid>;