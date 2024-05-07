using System;
using Domain.Primitives;

namespace Domain.Entities;

public sealed class Client : Entity
{
  public string Nombres { get; private set; }
  public string Apellidos { get; private set; }
  public DateTime FechaNacimiento { get; private set; }
  public int IdTipoDocumento { get; private set; }
  public string NroDocumento { get; private set; }

  public Client(Guid id, string nombres, string apellidos, DateTime fechaNacimiento, int idTipoDocumento, string nroDocumento) : base(id)
  {
    Nombres = nombres;
    Apellidos = apellidos;
    FechaNacimiento = fechaNacimiento.ToUniversalTime();
    IdTipoDocumento = idTipoDocumento;
    NroDocumento = nroDocumento;
  }

#nullable enable
  public void Modificar(string? nombres, string? apellidos, DateTime? fechaNacimiento)
  {
    if (nombres != null)
    {
      Nombres = nombres;
    }

    if (apellidos != null)
    {
      Apellidos = apellidos;
    }

    if (fechaNacimiento != null)
    {
      FechaNacimiento = fechaNacimiento.Value.ToUniversalTime();
    }
  }
}

