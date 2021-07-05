using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class SearchRecipeModel
	{
		[DataMember(Name = "tagIds")]
		public int[] TagIds { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

	}
}
