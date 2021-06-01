using recipe_domain;
using System.Linq;
using System.Collections.Generic;

namespace recipe_infrastructure
{
	public class UserRepository: IUserInterface
	{
		private List<User> Users => new List<User>
	   {
		   new User(){
			   UserId = 1,
			   Login = "tolian",
			   Password = "12345678",
			   Name = "Анатолий"
		   }
	   };
		public User AuthenticateUser(string login, string password)
		{
			return Users.SingleOrDefault(u => u.Login == login && u.Password == password);
		}
	}
}
