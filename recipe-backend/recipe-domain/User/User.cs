using System;
using System.Collections.Generic;

namespace recipe_domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }
        public ICollection<Recipe> Favourites { get; set; }
    }
}
