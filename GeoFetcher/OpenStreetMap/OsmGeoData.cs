using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace GeoFetcher
{
	public class OsmGeoData : GeoData
	{
		public OsmDataModel[] Model { get; }

		public OsmGeoData()
			: this(null) { }

		public OsmGeoData(string data)
		{
			Model = JsonSerializer.Deserialize<OsmDataModel[]>(data);
		}

		/// <summary>
		/// Сохранить данные в файл.
		/// </summary>
		/// <param name="path">Путь должен кончаться на имя файла (например: "/folder/geodata.json")</param>
		public override void SaveData(string path)
		{
			if (!path.EndsWith(".json"))
				path += ".json";

			File.WriteAllText(path, JsonSerializer.Serialize(Model));
		}

		/// <summary>
		/// Обрезать координаты полигона.
		/// </summary>
		/// <param name="rate">Параметер rate опеределяет степень сжатия итоговое значение будет равно (length / rate)</param>
		public override void Shrink(uint rate)
		{
			for (int model = 0; model < Model.Length; model++)
			{
				var geodata = Model[model].geojson.coordinates;

				for (int place = 0; place < geodata.Length; place++)
				{
					var currentPlace = geodata[place];

					for (int i = 0; i < currentPlace.Length; i++)
					{
						var coords = currentPlace[i];
						double[][] shrinked = new double[coords.Length / rate][];

						for (uint coord = 0, shrinkCtr = 0;
							shrinkCtr < shrinked.Length && coord < coords.Length;
							coord += rate, shrinkCtr++)
						{
							shrinked[shrinkCtr] = new double[2];
							shrinked[shrinkCtr][0] = coords[coord][0];
							shrinked[shrinkCtr][1] = coords[coord][1];
						}

						Model[model].geojson.coordinates[place][i] = shrinked;
					}
				}
			}
		}


		//private void JsonArrayReader(JsonElement array)
		//{
		//	foreach (JsonElement elem in array.EnumerateArray())
		//	{
		//		if (elem.ValueKind == JsonValueKind.Array)
		//		{
		//			JsonArrayReader(elem);
		//		}
		//		else
		//		{
		//			Console.WriteLine(elem.GetDouble());
		//		}
		//	}
		//}
	}
}
