using System.Threading.Tasks;

namespace recipe_domain
{
	public interface IUserRepository
	{
		Task<User> AuthenticateUser(string login);

		Task<bool> RegisterUser(string login, string name, string password);

		Task<User> GetUser(int userId);

		void EditUser(User user);
	}
}
