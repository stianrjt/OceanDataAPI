using AutoMapper;
using OceanDataAPI.Models;
using System;

namespace OceanDataAPI.DTOs
{
	public class DataPointDTO
	{
		public Guid ID { get; set; }
		public DateTimeOffset TimeStamp { get; set; }
		public double Temperature { get; set; }
		public double Salinity { get; set; }
		public LocationDTO Location { get; set; }
	}


	public class DataPointDtoProfile : Profile
	{
		public DataPointDtoProfile()
		{
			CreateMap<DataPointDTO, DataPoint>().ReverseMap();
		}
	}
}
