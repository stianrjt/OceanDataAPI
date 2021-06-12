using OceanDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OceanDataAPI.Repositories
{
	public interface IDataPointRepo
	{
		Task<IEnumerable<DataPoint>> GetAll();

		Task<DataPoint> GetById(Guid id);

		Task<DataPoint> Add(DataPoint dataPoint);

		Task<DataPoint> Update(DataPoint dataPoint);

		bool Exists(Guid id);
	}
}