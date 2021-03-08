using System;
using System.Net.Http;
using System.Threading.Tasks;
using JobSearch.APP.Models;
using JobSearch.Domain.Models;
using Newtonsoft.Json;

namespace JobSearch.APP.Services
{
	public class UserService : Service
	{
		public async Task<ResponseService<User>> GetUser(string email, string password)
		{
			HttpResponseMessage response = await _client.GetAsync($"{BaseAPIUrl}/api/Users?email={email}&password={password}");

			ResponseService<User> responseService = new ResponseService<User>();
			responseService.IsSuccess = response.IsSuccessStatusCode;
			responseService.StatusCode = (int)response.StatusCode;

			if (response.IsSuccessStatusCode)
			{
				responseService.Data = await response.Content.ReadAsAsync<User>();
			}
			else
			{
				string problemResponse = await response.Content.ReadAsStringAsync();
				var errors = JsonConvert.DeserializeObject<ResponseService<User>>(problemResponse);
				responseService.Errors = errors.Errors;
			}

			return responseService;
		}

		public async Task<ResponseService<User>> AddUser(User user)
		{
			HttpResponseMessage response = await _client.PostAsJsonAsync($"{BaseAPIUrl}/api/Users", user);

			ResponseService<User> responseService = new ResponseService<User>();
			responseService.IsSuccess = response.IsSuccessStatusCode;
			responseService.StatusCode = (int)response.StatusCode;

			if (response.IsSuccessStatusCode)
			{
				responseService.Data = await response.Content.ReadAsAsync<User>();
			}
			else
			{
				string problemResponse = await response.Content.ReadAsStringAsync();
				var errors = JsonConvert.DeserializeObject<ResponseService<User>>(problemResponse);
				responseService.Errors = errors.Errors;
			}

			return responseService;
		}

		public UserService()
		{
		}
	}
}