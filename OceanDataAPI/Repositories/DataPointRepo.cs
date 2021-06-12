using Microsoft.EntityFrameworkCore;
using OceanDataAPI.Data;
using OceanDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanDataAPI.Repositories
{
	public class DataPointRepo : IDataPointRepo
	{
		private readonly OceanDataContext _context;
		public DataPointRepo(OceanDataContext context) => _context = context;


		public async Task<IEnumerable<DataPoint>> GetAll()
		{
			return await _context.DataPoints
				.Include(d => d.Location)
				.ToListAsync();
		}
		
		
		public async Task<DataPoint> GetById(Guid id)
		{
			return await _context.DataPoints.FirstOrDefaultAsync(d => d.ID == id);
		}
		
		
		public async Task<DataPoint> Add(DataPoint dataPoint)
		{
			var result = await _context.DataPoints.AddAsync(dataPoint);
			await _context.SaveChangesAsync();

			return result.Entity;
		}
		
		public async Task<DataPoint> Update(DataPoint dataPoint)
		{
			var result = _context.DataPoints.Update(dataPoint);
			await _context.SaveChangesAsync();

			return result.Entity;
		}

		public bool Exists(Guid id)
		{
			return _context.DataPoints.Any(d => d.ID == id);
		}



	}
}
