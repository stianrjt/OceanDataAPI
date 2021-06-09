using Microsoft.AspNetCore.Mvc;
using OceanDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanDataAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DataPointController : ControllerBase
	{
		public DataPointController()
		{

		}


		[HttpGet]
		public IActionResult GetData()
		{
			Random random = new Random();
			Location location = new Location
			{
				ID = Guid.NewGuid(),
				Latitude = random.Next(516400146, 630304598).ToString(),
				Longitude = random.Next(224464416, 341194152).ToString(),
			};
			var data = from number in Enumerable.Range(0, 5)
					   select new DataPoint
					   {
						   ID = Guid.NewGuid(),
						   Salinity = random.NextDouble()*10,
						   Temperature = random.Next(-20, 50),
						   TimeStamp = DateTimeOffset.Now.AddSeconds(number),
						   Location = location,
						  };

			return Ok(data);

		}
	}
}
