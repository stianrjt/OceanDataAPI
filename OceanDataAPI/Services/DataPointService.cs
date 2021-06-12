using OceanDataAPI.Models;
using OceanDataAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanDataAPI.Services
{
	public class DataPointService : IDataPointService
	{
		private readonly IDataPointRepo _dataPointRepo;
		private readonly ILocationRepo _locationRepo;
		public DataPointService(IDataPointRepo dataPointRepo, ILocationRepo locationRepo)
		{
			_dataPointRepo = dataPointRepo;
			_locationRepo = locationRepo;
		}


		public async Task<IEnumerable<DataPoint>> GetAll()
		{
			return await _dataPointRepo.GetAll();
		}


		public async  Task<DataPoint> GetDataPointById(Guid id)
		{
			var result = await _dataPointRepo.GetById(id);

			return result;
		}


		public async Task<DataPoint> AddDataPoint(DataPoint dataPoint)
		{
			var result = await _dataPointRepo.Add(dataPoint);

			return result;
		}


		public async Task<IEnumerable<Location>> GetAllLocations()
		{
			return await _locationRepo.GetAll();
		}


		public async Task<Location> GetLocationById(Guid id)
		{
			var result = await _locationRepo.GetById(id);

			return result;
		}


		public async Task<Location> AddLocation(Location dataPoint)
		{
			var result = await _locationRepo.Add(dataPoint);

			return result;
		}



	}
}
