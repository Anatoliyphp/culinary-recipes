using System;
using System.Collections.Generic;
using System.Text;

namespace recipe_domain;

public class UserStats
{
    public int Id { get; set; }

    public int RecipesNumber { get; set; }

    public int CommentsNumber { get; set; }

    public int Likes { get; set; }

    public int FavouritesNumber { get; set; }
}

