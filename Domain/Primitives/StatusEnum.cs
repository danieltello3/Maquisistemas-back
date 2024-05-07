using System.Collections.Generic;

namespace Domain.Primitives
{
	public class StatusEnum : Enumeration
	{
		public static StatusEnum DESACTIVADO = new StatusEnum(0, "DESACTIVADO");
		public static StatusEnum ACTIVO = new StatusEnum(1, "ACTIVO");

		public StatusEnum(int id, string name) : base(id,name)
		{
		}

		public static IEnumerable<StatusEnum> List() => new[] { ACTIVO, DESACTIVADO };
	}
}

