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
		public decimal Temperature { get; set; }
		public decimal Salinity { get; set; }
		public Location Location { get; set; }

	}
}
