using System.Configuration;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using HealthyHappenings.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Xml;
using System.Net;
using System.IO;

namespace HealthyHappenings.EBSource
{
	public class HealthyHappeningEBSourceService : IHealthyHappeningService
	{
		public const string EBSourceUrlKey = "EBSourceUrl";
		public const string EBAppKey = "EBAppKey";
		public const string EBQueryString = "app_key={0}&keywords=health&city={1}&date=This+month";

		public List<HealthyHappenings.Contract.Event> GetByCity(string city)
		{
			try
			{
				string url = ConfigurationManager.AppSettings[EBSourceUrlKey];
				if (string.IsNullOrEmpty(url))
					throw new Exception(string.Format("Url not defined in configuration - {0}", EBSourceUrlKey));

				string appKey = ConfigurationManager.AppSettings[EBAppKey];
				if (string.IsNullOrEmpty(appKey))
					throw new Exception(string.Format("App Key not defined in configuration - {0}", EBAppKey));

				string requestUrl = string.Format(url + EBQueryString, appKey, city);

				string content = DownloadData(requestUrl);

				XElement root = XElement.Load(new StringReader(content));
				IEnumerable<Event> events =
					from e in root.Elements("event")
					select new Event()
					{
						ID = (long)e.Element("id"), 
						Title = (string)e.Element("title"), 
						Url = (string)e.Element("url"), 
						Description = (string)e.Element("description"), 
						Logo = (string)e.Element("logo"), 
						StartDate = (DateTime)e.Element("start_date"), 
						EndDate = (DateTime)e.Element("end_date"), 
						Venue = (e.Element("venue") != null) ? 
							new Venue()
							{
								Name = (string)(e.Element("venue").Element("name"))
							} : null,
						Organizer = (e.Element("organizer") != null) ?
							new Organizer()
							{
								ID = (long)(e.Element("organizer").Element("id")),
								Name = (string)(e.Element("organizer").Element("name")), 
								Url = (string)(e.Element("organizer").Element("url"))
							} : null 
					};

				return events.ToList();

			}
			catch (Exception)
			{
				throw;
			}

			return null;
		}

		private string DownloadData(string url)
		{
			string content = string.Empty;

			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = "GET";
			using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
			{
				using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
				{
					content = sr.ReadToEnd();
				}
			}
			return content;
		}
	}
}
