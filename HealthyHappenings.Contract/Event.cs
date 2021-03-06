﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHappenings.Contract
{
	/// <summary>
	/// This class represents and instance of an event.
	/// We will be mainly using it to represent a health event. 
	/// </summary>
	public class Event
	{
		public long ID { get; set; }

		public string Title { get; set; }

		public string Url { get; set; }

		public string Description { get; set; }

		public string Logo { get; set; }

		public Venue Venue { get; set; }

		public Organizer Organizer { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; } 

	}
}
