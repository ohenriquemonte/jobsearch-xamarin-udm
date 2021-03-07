using System;
using System.Net.Http;
using System.Threading.Tasks;
using JobSearch.Domain.Models;

namespace JobSearch.APP.Services
{
	public class UserService : Service
	{
		public async Task<User> GetUser(string email, string password)
		{
			HttpResponseMessage response = await _client.GetAsync($"{BaseAPIUrl}/api/Users?email={email}&password={password}");

			User user = null;
			if (response.IsSuccessStatusCode)
			{
				user = await response.Content.ReadAsAsync<User>();
			}

			return user;
		}

		public async Task<User> AddUser(User user)
		{
			HttpResponseMessage response = await _client.PostAsJsonAsync($"{BaseAPIUrl}/api/Users", user);

			if (response.IsSuccessStatusCode)
			{
				user = await response.Content.ReadAsAsync<User>();
			}
			else
			{
				user = null;
			}

			return user;
		}

		public UserService()
		{
		}
	}
}
