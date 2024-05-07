using System;

namespace Application.Clients.Commands.CreateClient;

public sealed record CreateClientRequest(string Nombres, string Apellidos, DateTime FechaNacimiento,int IdTipoDocumento, string NroDocumento);