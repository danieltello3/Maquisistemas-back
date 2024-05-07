using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Primitives;

namespace Application.Clients.Queries.GetClients;

internal sealed class GetClientsQueryHandler : IQueryHandler<GetClientsQuery, IReadOnlyCollection<ClientsResponse>>
{
  private readonly IDbConnection _dbConnection;

  public GetClientsQueryHandler(IDbConnection dbConneciton) => _dbConnection = dbConneciton;

  public async Task<IReadOnlyCollection<ClientsResponse>> Handle(GetClientsQuery request,CancellationToken cancellationToken)
  {
    const string sql = @"SELECT c.""Id"",c.""Nombres"", c.""Apellidos"",TO_CHAR(c.""FechaNacimiento"", 'YYYY-MM-DD') as ""FechaNacimiento"", c.""IdTipoDocumento"", td.""Nombre"" as ""TipoDocumento"", c.""NroDocumento""
                          FROM ""Clients"" c 
                          inner join ""TipoDocumento"" td ON c.""IdTipoDocumento"" = td.""Id"" 
                          WHERE c.""Estado"" = @EstadoActivo";

    var clients = await _dbConnection.QueryAsync<ClientsResponse>(sql, new { EstadoActivo = StatusEnum.ACTIVO.Id });

    return clients.ToList();
  }
}

