using OceanDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OceanDataAPI.Services
{
	public interface IDataPointService
	{
		Task<IEnumerable<DataPoint>> GetAll();


		Task<DataPoint> GetDataPointById(Guid id);

		Task<DataPoint> AddDataPoint(DataPoint dataPoint);


		Task<IEnumerable<Location>> GetAllLocations();


		Task<Location> GetLocationById(Guid id);


		Task<Location> AddLocation(Location dataPoint);
	}
}