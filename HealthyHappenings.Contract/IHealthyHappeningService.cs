using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHappenings.Contract
{
	/// <summary>
	/// This service contract defines the methods need to be implemented for acting as a data source for health events
	/// </summary>
	public interface IHealthyHappeningService
	{
		List<Event> GetByCity(string city);
	}
}
