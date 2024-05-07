namespace Domain.Entities;

public class Combos
{
	public int Id { get; private set; }
	public string Nombre { get; private set; }
	public int Estado { get; private set; }

	public Combos(int id, string nombre, int estado)
	{
		Id = id;
		Nombre = nombre;
		Estado = estado;
	}
}

