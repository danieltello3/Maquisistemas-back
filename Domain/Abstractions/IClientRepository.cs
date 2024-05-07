using System;
using Domain.Entities;
namespace Domain.Abstractions;

public interface IClientRepository
{
  void Insert(Client client);
  Client Get(Guid clientId);
  void Update(Client client);
}
