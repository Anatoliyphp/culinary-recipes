using Microsoft.EntityFrameworkCore;
using recipe_domain;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_infrastructure
{
	public class UserRepository: IUserRepository
	{
		private RecipesContext db;

		public UserRepository(RecipesContext Users)
		{
			db = Users;
		}

		public async Task<User> AuthenticateUser(string login, string password)
		{
			return await db.Users.SingleOrDefaultAsync (u => u.Login == login && u.Password == password);
		}

		public async Task<bool> RegisterUser(string login, string name, string password)
		{
			User user = new User(login, name, password);
			if (db.Users.Any(u => u.Login == login))
			{
				return false;
			}
			await db.Users.AddAsync(user);
			return true;
		}
	}
}
