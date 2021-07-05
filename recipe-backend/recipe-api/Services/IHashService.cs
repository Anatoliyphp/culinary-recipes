using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_api.Services
{
	public interface IHashService
	{
		string HashString(string text);

		string DecryteString(string cryptedText);
	}
}
