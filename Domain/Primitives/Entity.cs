using System;
using Domain;
using Domain.Exceptions;
using Domain.Exceptions.Base;

namespace Domain.Primitives;

public abstract class Entity
{
  protected Entity(Guid id) {
    Id = id;
    Estado = StatusEnum.ACTIVO.Id;
  }

  public Guid Id { get; protected set; }
  public int Estado { get; private set; }

  public virtual void Eliminar()
  {
    if( Estado == StatusEnum.DESACTIVADO.Id)
    {
      throw new ClientBadRequestException("El cliente ya fue eliminado");
    }
    Estado = StatusEnum.DESACTIVADO.Id;
  }
}