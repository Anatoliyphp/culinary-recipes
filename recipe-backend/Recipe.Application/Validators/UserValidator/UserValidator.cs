using recipe_domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
	public class UserValidator: IValidator<User>
	{
		public override IReadOnlyList<Exception> GetExceptions(User user)
		{
			List<Exception> exceptions = new List<Exception>();

			if (user.Name.Length > 30 || user.Name.Length == 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("User name has invalid length"));
			}

			foreach (Char letter in user.Name)
			{
				if (Char.IsDigit(letter))
				{
					exceptions.Add(new ArgumentOutOfRangeException("User name has invalid symbols"));
					return exceptions;
				}
			}

			if (user.Login.Length > 50 || user.Login.Length == 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("User login has invalid length"));
			}

			if (user.Password.Length > 50 || user.Password.Length == 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("User login has invalid length"));
			}

			return exceptions;
		}
	}
}
