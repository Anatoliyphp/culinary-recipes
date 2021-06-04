using System.Threading.Tasks;

namespace recipe_domain
{
	public interface IUserRepository
	{
		Task<User> AuthenticateUser(string login, string password);

		Task<bool> RegisterUser(string login, string name, string password);
	}
}
