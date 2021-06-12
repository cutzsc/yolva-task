using System;

namespace GeoFetcher
{
	public class OsmGeoService : GeoService
	{
		public OsmGeoService(string uri = "https://nominatim.openstreetmap.org/search")
			: base(uri) { }

		/// <summary>
		/// Установить запрос.
		/// </summary>
		/// <param name="query"></param>
		public override void SetQuery(string query)
		{
			uriBuilder.Query = $"q={query}&format=json&polygon_geojson=1";
		}
	}
}
