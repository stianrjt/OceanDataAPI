using Microsoft.EntityFrameworkCore;
using OceanDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanDataAPI.Data
{
	public class OceanDataContext : DbContext
	{
		public OceanDataContext(DbContextOptions<OceanDataContext> options) : base(options)
		{

		}

		public DbSet<DataPoint> DataPoints { get; set; }
		public DbSet<Location> Locations { get; set; }
	}
}
