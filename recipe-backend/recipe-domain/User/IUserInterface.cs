using System;
using System.Collections.Generic;
using System.Text;

namespace recipe_domain
{
	public interface IUserInterface
	{
		User AuthenticateUser(string login, string password);
	}
}
