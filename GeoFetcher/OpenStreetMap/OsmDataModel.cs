using System;

namespace GeoFetcher
{
	/// <summary>
	/// OpenStreetMap json data model
	/// </summary>
	public class OsmDataModel
	{
		public int place_id { get; set; }
		public string licence { get; set; }
		public string osm_type { get; set; }
		public int osm_id { get; set; }
		public string[] boundingbox { get; set; }
		public string lat { get; set; }
		public string lon { get; set; }
		public string display_name { get; set; }
		public string @class { get; set; }
		public string @type { get; set; }
		public double importance { get; set; }
		public string icon { get; set; }
		public GeoJson geojson { get; set; }

		public class GeoJson
		{
			public string @type { get; set; }
			public double[][][][] coordinates { get; set; }
		}
	}
}
