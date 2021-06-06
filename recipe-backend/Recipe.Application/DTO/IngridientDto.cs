using System.Runtime.Serialization;

namespace Recipe.Application.DTO
{
	[DataContract]
	public class IngridientDto
	{
		[DataMember(Name = "ingridient_id")]
		public int IngridientId { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "list")]
		public string List { get; set; }

		[DataMember(Name = "recipe_id")]
		public int RecipeId { get; set; }
	}
}
