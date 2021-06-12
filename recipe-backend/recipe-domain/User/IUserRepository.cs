using System.Threading.Tasks;

namespace recipe_domain
{
	public interface IUserRepository
	{
		Task<User> AuthenticateUser(string login, string password);

		Task<bool> RegisterUser(string login, string name, string password);

		Task<User> GetUser(int userId);

		Task EditUser(User user);
	}
}
