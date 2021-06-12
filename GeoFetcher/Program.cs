using System;

namespace GeoFetcher
{
	class Program
	{
		static void Main(string[] args)
		{
			GeoService service = new OsmGeoService();

			service.SetQuery("Москва ювао");
			string json = service.FetchData();

			var data = new OsmGeoData(json);

			data.SaveData("moscow-osm-data.json");

			data.Shrink(3);
			data.SaveData("shrinked-moscow-osm-data.json");

			//data = GeoData.LoadData<OsmGeoData>("moscow-osm-data.json");
			//data.Shrink(3);
			//data.SaveData("/shrinked-moscow-osm-data.json");
		}
	}
}
