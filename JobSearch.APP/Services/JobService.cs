using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JobSearch.Domain.Models;

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

		public async Task<Job> AddJob(Job job)
		{
			HttpResponseMessage response = await _client.PostAsJsonAsync($"{BaseAPIUrl}/api/Jobs", job);

			if (response.IsSuccessStatusCode)
			{
				job = await response.Content.ReadAsAsync<Job>();
			}
			else
			{
				job = null;
			}

			return job;
		}

		public JobService()
		{
		}
	}
}
