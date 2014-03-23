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
		/// <summary>
		/// This method is used to provide us with the data of health events for a given city.
		/// </summary>
		/// <param name="city">city for which health events are required</param>
		/// <returns>List of health events</returns>
		List<Event> GetByCity(string city);
	}
}
