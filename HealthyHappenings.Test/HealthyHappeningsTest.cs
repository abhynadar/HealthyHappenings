using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HealthyHappenings.EBSource;

namespace HealthyHappenings.Test
{
	[TestFixture]
	public class HealthyHappeningsTest
	{
		#region SetUp / TearDown

		[SetUp]
		public void Init()
		{ }

		[TearDown]
		public void Dispose()
		{ }

		#endregion

		#region Tests

		[Test]
		public void GetHappeningsThisMonth_ForBethesda_ShouldReturnSomeData()
		{
			HealthyHappenings.Contract.IHealthyHappeningService healthyHappeningService = new HealthyHappeningEBSourceService();

			List<HealthyHappenings.Contract.Event> healthEvents = healthyHappeningService.GetByCity("Bethesda");

			Assert.IsNotNull(healthEvents);
			Assert.Greater(healthEvents.Count, 0);
		}

		#endregion
	}
}
