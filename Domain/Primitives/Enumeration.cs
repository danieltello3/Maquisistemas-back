using System;
using System.Collections.Generic;
namespace Domain.Primitives;

public abstract class Enumeration : IComparable
{
	public string Name { get; private set; }
	public int Id { get; private set; }

	public Enumeration(int id, string name)
	{
		Id = id;
		Name = name;
	}

  public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

}

