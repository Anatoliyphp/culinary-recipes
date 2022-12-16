using recipe_domain;
using System;
using System.Collections.Generic;

namespace Application
{
	public class TagValidator : IValidator<Tag>
	{
		public override IReadOnlyList<Exception> GetExceptions(Tag tag)
		{
			List<Exception> exceptions = new List<Exception>();

			if (tag.Name.Length > 20 || tag.Name.Length == 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("Tag name has invalid length"));
			}

			foreach(Char letter in tag.Name)
			{
				if (Char.IsDigit(letter))
				{
					exceptions.Add(new ArgumentOutOfRangeException("Tag name has invalid symbols"));
					return exceptions;
				}
			}

			return exceptions;
		}

	}
}
