using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	[KnownType(typeof(List<TagDto>))]
	public class RecipeDto
	{
		public RecipeDto(
			int id,
			string img,
			string name,
			string desc,
			int time,
			int persons,
			int likes,
			bool isLike,
			int favourites,
			bool isFavourite,
			int userId,
			List<TagDto> tags
			)
		{
			Id = id;
			Img = img;
			Name = name;
			Description = desc;
			Time = time;
			Persons = persons;
			Likes = likes;
			IsLike = isLike;
			Favourites = favourites;
			IsFavourite = isFavourite;
			UserId = userId;
			Tags = tags;
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

		[DataMember(Name = "persons")]
		public int Persons { get; set; }

		[DataMember(Name = "likes")]
		public int Likes { get; set; }

		[DataMember(Name = "isLike")]
		public bool IsLike { get; set; }

		[DataMember(Name = "favourites")]
		public int Favourites { get; set; }

		[DataMember(Name = "IsFavourite")]
		public bool IsFavourite { get; set; }

		[DataMember(Name = "user_id")]
		public int UserId { get; set; }

		[DataMember(Name = "tags")]
		public List<TagDto> Tags { get; set; }

	}
}
