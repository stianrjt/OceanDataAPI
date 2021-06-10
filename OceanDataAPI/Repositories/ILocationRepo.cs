using OceanDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OceanDataAPI.Repositories
{
	public interface ILocationRepo
	{
		Task<IEnumerable<Location>> GetAll();


		Task<Location> GetById(Guid id);


		Task<Location> Add(Location location);

		Task<Location> Update(Location location);

		bool Exists(Guid id);
	}
}