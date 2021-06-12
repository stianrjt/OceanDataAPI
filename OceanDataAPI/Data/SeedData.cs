using OceanDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanDataAPI.Data
{
	public class SeedData
	{

		public static void Initialize(OceanDataContext context)
		{
			Random random = new Random();
			Location location = new Location
			{
				ID = Guid.NewGuid(),
				Latitude = random.Next(216400146, 630304598).ToString(),
				Longitude = random.Next(124464416, 341194152).ToString(),
			};
			var data = from number in Enumerable.Range(0, 100)
					   select new DataPoint
					   {
						   ID = Guid.NewGuid(),
						   Salinity = random.NextDouble() * 10,
						   Temperature = random.Next(1, 30),
						   TimeStamp = DateTimeOffset.Now.AddSeconds(number),
						   Location = location,
					   };

			foreach (var d in data)
			{
			context.DataPoints.Add(d);
			}


			context.SaveChanges();
		}
	}
}
