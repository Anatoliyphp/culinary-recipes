using System.Runtime.Serialization;

namespace Recipe.Application.DTO
{
	[DataContract]
	public class RecipeDto
	{
		[DataMember(Name = "img")]
		public byte[] Img { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "desc")]
		public string Desc { get; set; }

		[DataMember(Name = "time")]
		public int Time { get; set; }

		[DataMember(Name = "persons")]
		public int Persons { get; set; }

		[DataMember(Name = "likes")]
		public int Likes { get; set; }

		[DataMember(Name = "user_id")]
		public int UserId { get; set; }

	}
}
