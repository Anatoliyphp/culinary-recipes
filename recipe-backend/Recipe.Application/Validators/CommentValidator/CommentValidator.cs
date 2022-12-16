using recipe_domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
	public class CommentValidator : IValidator<Comment>
	{
		public override IReadOnlyList<Exception> GetExceptions(Comment comment)
		{
			List<Exception> exceptions = new List<Exception>();

			if (comment.Text.Length > 100 || comment.Text.Length == 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("Comment text has invalid length"));
			}

			return exceptions;
		}

	}
}
