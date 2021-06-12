using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class FullRecipeDto
	{
		public FullRecipeDto(
			IFormFile img,
			string name,
			string desc,
			int time,
			int persons,
			int likes,
			int userId,
			IEnumerable<TagDto> tags,
			IEnumerable<IngridientDto> ingridients,
			IEnumerable<StepDto> steps
			)
		{
			Img = img;
			Name = name;
			Desc = desc;
			Time = time;
			Persons = persons;
			Likes = likes;
			UserId = userId;
			Tags = tags.ToList();
			Steps = steps.ToList();
			Ingridients = ingridients.ToList();
		}

		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "img")]
		public IFormFile Img { get; set; }

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

		[DataMember(Name = "tags")]
		public List<TagDto> Tags;

		[DataMember(Name = "steps")]
		public List<StepDto> Steps;

		[DataMember(Name = "ingridients")]
		public List<IngridientDto> Ingridients;

	}
}
