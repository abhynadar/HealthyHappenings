using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHappenings.Contract
{
	public interface IHealthyHappeningService
	{
		List<Event> GetByCity(string city);
	}
}
