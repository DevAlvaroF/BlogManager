using AutoMapper;
using Shared.Models;

namespace Server.Data
{
	public class DTOMappings : Profile
	{
		public DTOMappings()
		{
			CreateMap<Post, PostDTO>().ReverseMap();
		}
	}
}
