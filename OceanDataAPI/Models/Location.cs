using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanDataAPI.Models
{
	public class Location
	{
		public Guid ID { get; set; }
		public string Longitude { get; set; }
		public string Latitude { get; set; }

	}
}
