using System;
using System.IO;

namespace GeoFetcher
{
	public abstract class GeoData
	{
		/// <summary>
		/// Обрезать координаты полигона.
		/// </summary>
		/// <param name="rate">Параметер rate опеределяет степень сжатия итоговое значение будет равно (length / rate)</param>
		public abstract void Shrink(uint rate);

		/// <summary>
		/// Сохранить данные в файл.
		/// </summary>
		/// <param name="path">Путь должен кончаться на имя файла (например: "/folder/geodata.json")</param>
		public abstract void SaveData(string path);

		/// <summary>
		/// Загрузить данные из json файла.
		/// </summary>
		/// <typeparam name="T">Модель данные соответствующая данным в json.</typeparam>
		/// <param name="path">Путь должен кончаться на имя файла (например: "/folder/geodata.json")</param>
		/// <returns></returns>
		public static T LoadData<T>(string path) where T : GeoData, new()
		{
			if (!File.Exists(path))
				throw new ArgumentException("Файл не найден.");

			string json = File.ReadAllText(path);
			return (T)Activator.CreateInstance(typeof(T), json);
		}
	}
}
