using System;
namespace Application.Clients.Queries.GetClients;

public sealed record ClientsResponse(Guid Id, string Nombres, string Apellidos, string FechaNacimiento, int IdTipoDocumento, string TipoDocumento,string NroDocumento);