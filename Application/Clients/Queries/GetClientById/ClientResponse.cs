using System;
namespace Application.Clients.Queries.GetClientById
{
  public sealed record ClientResponse(Guid Id, string Nombres, string Apellidos, string FechaNacimiento, int IdTipoDocumento, string TipoDocumento, string NroDocumento);

}

