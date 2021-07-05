using recipe_domain;
using System;

namespace Application
{
	class UserDomainBuilder : IUserDomainBuilder
	{
		public User CreateUser(UserDto userDto)
		{
			if (userDto != null)
			{
				User user = new User(
					userDto.Login,
					userDto.Password,
					userDto.Name
					);
				user.Id = userDto.Id;
				user.About = userDto.About;

				return user;
			}

			return null;
		}
	}
}
