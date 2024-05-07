using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Primitives;

namespace Application.Combos.Queries.GetTipoDocumento;

internal sealed class GetTipoDocumentoComboQueryHandler : IQueryHandler<GetTipoDocumentoComboQuery, IReadOnlyCollection<TipoDocumentoComboResponse>>
{
  private readonly IDbConnection _dbConnection;

  public GetTipoDocumentoComboQueryHandler(IDbConnection dbConnection) => _dbConnection = dbConnection;

  public async Task<IReadOnlyCollection<TipoDocumentoComboResponse>> Handle(GetTipoDocumentoComboQuery request, CancellationToken cancellationToken)
  {
    const string sql = @"SELECT ""Id"", ""Nombre"" FROM ""TipoDocumento"" WHERE ""Estado"" = @EstadoActivo";

    var combo = await _dbConnection.QueryAsync<TipoDocumentoComboResponse>(sql, new { EstadoActivo = StatusEnum.ACTIVO.Id });

    return combo.ToList();
  }
}

