using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanDataAPI.DTOs;
using OceanDataAPI.Models;
using OceanDataAPI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OceanDataAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DataPointController : ControllerBase
	{
		private readonly IDataPointService _service;
		private readonly IMapper _mapper;
		public DataPointController(IDataPointService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}


		[HttpGet]
		public async Task<IActionResult> GetDataPoints()
		{
			var result = await _service.GetAll();

			var dto = _mapper.Map<IEnumerable<DataPointDTO>>(result);
			return Ok(result);
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> GetDataPointById(Guid id)
		{
			var result = await _service.GetDataPointById(id);

			if (result == null)
			{
				return NotFound();
			}

			var dto = _mapper.Map<DataPointDTO>(result);
			return Ok(dto);
		}


		[HttpPost]
		public async Task<IActionResult> AddDataPoint(DataPointDTO dataPointDTO)
		{
			var dataPoint = _mapper.Map<DataPoint>(dataPointDTO);
			var result = await _service.AddDataPoint(dataPoint);

			if (result == null)
			{
				return NotFound();
			}

			var dto = _mapper.Map<DataPointDTO>(result);
			return Ok(result);
		}



	}
}
