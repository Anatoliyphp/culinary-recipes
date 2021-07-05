using System;
using System.Threading.Tasks;

namespace recipe_infrastructure.UoW
{
	public class UnitOfWork : IDisposable
	{
		private RecipesContext db;
		private RecipeRepository recipeRepository;
		private UserRepository userRepository;
		private bool disposed = false;

		public UnitOfWork(RecipesContext context)
		{
			db = context;
		}

		public RecipeRepository Recipes
		{
			get
			{
				if (recipeRepository == null)
				{
					recipeRepository = new RecipeRepository(db);
				}
				return recipeRepository;
			}
		}

		public UserRepository Users
		{
			get
			{
				if (userRepository == null)
				{
					userRepository = new UserRepository(db);
				}
				return userRepository;
			}
		}

		public async Task Save()
		{
			await db.SaveChangesAsync();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
