using System;
using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
	private readonly ApplicationDbContext _dbContext;

	public ClientRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

	public void Insert(Client client) => _dbContext.Set<Client>().Add(client);

	public Client Get(Guid clientId) => _dbContext.Set<Client>().Find(clientId);

	public void Update(Client client) => _dbContext.Set<Client>().Update(client);
}

