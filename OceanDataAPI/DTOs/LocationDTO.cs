using AutoMapper;
using OceanDataAPI.Models;

namespace OceanDataAPI.DTOs
{
	public class LocationDTO
	{
		public string Longitude { get; set; }
		public string Latitude { get; set; }
	}


	public class locationDtoProfile : Profile
	{
		public locationDtoProfile()
		{
			CreateMap<LocationDTO, Location>().ReverseMap();
		}
	}
}
