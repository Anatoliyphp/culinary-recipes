namespace Recipe.Application.DTO
{
	public class RecipeDto
	{
		public int RecipeId { get; set; }

		public byte[] Img { get; set; }

		public string Name { get; set; }

		public string Desc { get; set; }

		public int Time { get; set; }

		public int Persons { get; set; }

		public int Likes { get; set; }

		public int UserId { get; set; }

	}
}
