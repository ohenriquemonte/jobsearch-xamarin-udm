using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JobSearch.APP.Models;
using JobSearch.Domain.Models;
using Newtonsoft.Json;

namespace JobSearch.APP.Services
{
	public class JobService : Service
	{
		public async Task<IEnumerable<Job>> GetJobs(string word, string cityState, int numberOfPage = 1)
		{

			HttpResponseMessage response = await _client.GetAsync($"{BaseAPIUrl}/api/Jobs?word={word}&cityState={cityState}&numberOfPage={numberOfPage}");

			List<Job> list = null;

			if (response.IsSuccessStatusCode)
			{
				list = await response.Content.ReadAsAsync<List<Job>>();
			}

			return list;
		}

		public async Task<Job> GetJob(int id)
		{
			HttpResponseMessage response = await _client.GetAsync($"{BaseAPIUrl}/api/Jobs/{id}");

			Job job = null;

			if (response.IsSuccessStatusCode)
			{
				job = await response.Content.ReadAsAsync<Job>();
			}

			return job;
		}

		public async Task<ResponseService<Job>> AddJob(Job job)
		{
			HttpResponseMessage response = await _client.PostAsJsonAsync($"{BaseAPIUrl}/api/Jobs", job);

			ResponseService<Job> responseService = new ResponseService<Job>();
			responseService.IsSuccess = response.IsSuccessStatusCode;
			responseService.StatusCode = (int)response.StatusCode;

			if (response.IsSuccessStatusCode)
			{

				responseService.Data = await response.Content.ReadAsAsync<Job>();
			}
			else
			{
				string problemResponse = await response.Content.ReadAsStringAsync();
				var errors = JsonConvert.DeserializeObject<ResponseService<Job>>(problemResponse);
				responseService.Errors = errors.Errors;
			}

			return responseService;
		}

		public JobService()
		{
		}
	}
}