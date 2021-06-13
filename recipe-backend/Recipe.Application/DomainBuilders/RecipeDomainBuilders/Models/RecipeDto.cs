﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class RecipeDto
	{
		public RecipeDto(
			int id,
			byte[] img,
			string name,
			string desc,
			int time,
			int persons,
			int likes,
			int favourites,
			bool isFavourite,
			int userId,
			IEnumerable<TagDto> tags
			)
		{
			Id = id;
			Img = img;
			Name = name;
			Desc = desc;
			Time = time;
			Persons = persons;
			Likes = likes;
			Favourites = favourites;
			IsFavourite = isFavourite;
			UserId = userId;
			Tags = tags.ToList();
		}

		[DataMember(Name = "id")]
		public int Id { get; set; }

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

		[DataMember(Name = "favourites")]
		public int Favourites { get; set; }

		[DataMember(Name = "IsFavourite")]
		public bool IsFavourite { get; set; }

		[DataMember(Name = "user_id")]
		public int UserId { get; set; }

		[DataMember(Name = "tags")]
		public List<TagDto> Tags;

	}
}