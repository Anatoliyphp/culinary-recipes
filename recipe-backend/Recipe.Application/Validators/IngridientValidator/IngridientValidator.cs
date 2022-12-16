using recipe_domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
	public class IngridientValidator: IValidator<Ingridient>
	{
		public override IReadOnlyList<Exception> GetExceptions(Ingridient ingridient)
		{
			List<Exception> exceptions = new List<Exception>();

			if (ingridient.Name.Length > 30 || ingridient.Name.Length == 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("Ingridient name has invalid length"));
			}

			if (ingridient.List.Length > 300 || ingridient.List.Length == 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("Ingridient list has invalid length"));
			}

			return exceptions;
		}
	}
}
