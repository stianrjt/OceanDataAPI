using Microsoft.EntityFrameworkCore;
using OceanDataAPI.Data;
using OceanDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanDataAPI.Repositories
{

	public class LocationRepo : ILocationRepo
	{
		private readonly OceanDataContext _context;
		public LocationRepo(OceanDataContext context) => _context = context;


		public async Task<IEnumerable<Location>> GetAll()
		{
			return await _context.Locations.ToListAsync();
		}


		public async Task<Location> GetById(Guid id)
		{
			return await _context.Locations.FirstOrDefaultAsync(d => d.ID == id);
		}


		public async Task<Location> Add(Location location)
		{
			var result = await _context.Locations.AddAsync(location);
			await _context.SaveChangesAsync();

			return result.Entity;
		}

		public async Task<Location> Update(Location location)
		{
			var result = _context.Locations.Update(location);
			await _context.SaveChangesAsync();

			return result.Entity;
		}

		public bool Exists(Guid id)
		{
			return _context.Locations.Any(d => d.ID == id);
		}

	}
}
