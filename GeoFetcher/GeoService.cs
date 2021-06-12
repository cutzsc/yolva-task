using System;
using System.Net;

namespace GeoFetcher
{
	public abstract class GeoService
	{
		protected readonly UriBuilder uriBuilder;

		public Uri Uri => uriBuilder.Uri;

		public GeoService(string uri) => uriBuilder = new UriBuilder(uri);

		/// <summary>
		/// Установить запрос.
		/// </summary>
		/// <param name="query"></param>
		public abstract void SetQuery(string query);

		/// <summary>
		/// Обращение к серверу с полученным Uri.
		/// </summary>
		/// <returns>Ответ от сервера в виде строки.</returns>
		public virtual string FetchData()
		{
			WebClient client = new WebClient();
			client.Headers.Set(HttpRequestHeader.UserAgent,
				"Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.101 Safari/537.36");

			return client.DownloadString(Uri);
		}
	}
}
