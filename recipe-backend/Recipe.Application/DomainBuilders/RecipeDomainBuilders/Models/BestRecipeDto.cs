using Microsoft.AspNetCore.Http;
using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class BestRecipeDto
	{
		public BestRecipeDto(
			int id,
			string img,
			string name,
			string desc,
			int time,
			int likes,
			int userId
			)
		{
			Id = id;
			Img = img;
			Name = name;
			Description = desc;
			Time = time;
			Likes = likes;
			UserId = userId;
		}

		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "img")]
		public string Img { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "desc")]
		public string Description { get; set; }

		[DataMember(Name = "time")]
		public int Time { get; set; }

		[DataMember(Name = "likes")]
		public int Likes { get; set; }

		[DataMember(Name = "user_id")]
		public int UserId { get; set; }

	}
}
