using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using recipe_domain;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace recipe_infrastructure
{
	public class UserRepository: IUserRepository
	{
		private RecipesContext db;

		public UserRepository(RecipesContext Users)
		{
			db = Users;
		}

		public async Task<User> AuthenticateUser(string login)
		{
			return await db.Users.SingleOrDefaultAsync (u => u.Login == login);
		}

		public async Task<User> GetUser(int userId)
		{
			return await db.Users.SingleOrDefaultAsync(u => u.Id == userId);
		}

		public async Task<User> GetBestUser()
		{
			List<User> users = await db.Users
				.Include(u => u.Comments)
				.Include(u => u.RecipeLikes)
				.Include(u => u.UserFavourites)
				.OrderByDescending(u => u.RecipeLikes.Count + u.UserFavourites.Count + u.Comments.Count)
				.ToListAsync();
			return users.FirstOrDefault();
		}

		public async Task<bool> RegisterUser(string login, string name, string password)
		{
			User user = new User(login, password, name);
			if (db.Users.Any(u => u.Login == login))
			{
				return false;
			}
			await db.Users.AddAsync(user);
			return true;
		}

		public void EditUser(User user)
		{
			db.Users.Update(user);
		}

		public async Task<List<User>> GetAllUsers(Filter filter)
		{
			List<User> users = await db.Users
				.Include(u => u.Comments)
				.Include(u => u.RecipeLikes)
				.Include(u => u.UserFavourites)
				.ToListAsync();
			return FilterUsers(filter, users);
		}

		public async Task<List<User>> SearchUsers(Filter filter, string name)
		{
			List<User> users = await db.Users
				.Include(u => u.Recipes)
				.ThenInclude(r => r.Comments)
				.Include(u => u.Recipes)
				.ThenInclude(r => r.UserFavourites)
				.Include(u => u.Recipes)
				.ThenInclude(r => r.RecipeLikes)
				.Where(u => EF.Functions.Like(u.Name, $"%{name}%")).ToListAsync();
			return FilterUsers(filter, users);
		}

		private List<User> FilterUsers(Filter filter, List<User> users)
		{
			switch (filter)
			{
				case Filter.ByComments:
					return users.OrderByDescending(u => u.Recipes.Sum(r => r.Comments.Count)).ToList();
				case Filter.ByFavourites:
					return users.OrderByDescending(u => u.Recipes.Sum(r => r.UserFavourites.Count)).ToList();
				case Filter.ByLikes:
					return users.OrderByDescending(u => u.Recipes.Sum(r => r.RecipeLikes.Count)).ToList();
				default:
					throw new ArgumentOutOfRangeException("Incorrect filter type");
			}
		}

	}
}
