using System;
using System.Net.Http;

namespace JobSearch.APP.Services
{
	public abstract class Service
	{
		protected HttpClient _client;
		protected string BaseAPIUrl = "https://xamarinforms2020api.azurewebsites.net/";

		public Service()
		{
			_client = new HttpClient();
		}
	}
}