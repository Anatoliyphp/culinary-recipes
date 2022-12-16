using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
	public abstract class IValidator<T>
	{
		public virtual IReadOnlyList<Exception> GetExceptions(T entity)
		{
			throw new NotImplementedException();
		}
		public void Validate(T entity)
		{
			IReadOnlyList<Exception> exceptions = GetExceptions(entity);

			if (exceptions.Any())
			{
				throw new AggregateException($"{entity.GetType()} has critical validation exceptions",
					exceptions);
			}
		}
	}
}
