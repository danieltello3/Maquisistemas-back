using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Exceptions;
using Domain.Primitives;

namespace Application.Clients.Queries.GetClientById;

internal sealed class GetClientByIdQueryHandler : IQueryHandler<GetClientByIdQuery,ClientResponse>
{
	private readonly IDbConnection _dbConnection;

	public GetClientByIdQueryHandler(IDbConnection dbConneciton) => _dbConnection = dbConneciton;

	public async Task<ClientResponse> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
	{
		const string sql = @"SELECT c.""Id"",c.""Nombres"", c.""Apellidos"",TO_CHAR(c.""FechaNacimiento"", 'YYYY-MM-DD') as ""FechaNacimiento"", c.""IdTipoDocumento"", td.""Nombre"" as ""TipoDocumento"", c.""NroDocumento""
                          FROM ""Clients"" c 
                          INNER JOIN ""TipoDocumento"" td ON c.""IdTipoDocumento"" = td.""Id""
													WHERE c.""Id"" = @ClientId AND c.""Estado"" = @EstadoActivo";

		var client = await _dbConnection.QueryFirstOrDefaultAsync<ClientResponse>(sql, new { request.ClientId, EstadoActivo= StatusEnum.ACTIVO.Id });

    if (client is null)
		{
			throw new ClientNotFoundException(request.ClientId);
		}

		return client;
	}
}

