using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanDataAPI.Models
{
	public class DataPoint
	{
		public Guid ID { get; set; }
		public DateTimeOffset TimeStamp { get; set; }
		public double Temperature { get; set; }
		public double Salinity { get; set; }
		public Location Location { get; set; }

	}
}
