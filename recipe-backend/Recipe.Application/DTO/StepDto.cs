using System.Runtime.Serialization;

namespace Recipe.Application.DTO
{
	[DataContract]
	public class StepDto
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "desc")]
		public string Desc { get; set; }

		[DataMember(Name = "recipe_id")]
		public int RecipeId { get; set; }
	}
}
