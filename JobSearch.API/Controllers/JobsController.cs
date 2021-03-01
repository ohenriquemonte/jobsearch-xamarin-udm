using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSearch.API.Database;
using JobSearch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobSearch.API.Controllers
{
	[Route("api/[controller]")]
	public class JobsController : Controller
	{

		private JobSearchContext _data;

		public JobsController(JobSearchContext data)
		{
			_data = data;
		}

		[HttpGet]
		public IEnumerable<Job> GetJobs(string word, string cityState)
		{

			// TODO - Add Paginação (InfinityScroll)
			// TODO - Limitar pesquisa por período
			// TODO - Tratar situação em que os parâmetros são nulos (null)

			return _data.Jobs.Where(a => 
				a.CityState.ToLower().Contains(cityState) &&
				(
					a.JobTitle.ToLower().Contains(word) ||
					a.TecnologyTools.ToLower().Contains(word) ||
					a.Company.ToLower().Contains(word)
				)
			).ToList<Job>();
		}

		// api/Jobs/1
		[HttpGet("{id}")]
		public IActionResult GetJob(int id)
		{
			Job jobDB = _data.Jobs.Find(id);

			if(jobDB == null)
			{
				return NotFound();
			}

			return new JsonResult(jobDB);
		}

		[HttpPost]
		public IActionResult AddJob([FromBody] Job job)
		{
			// TODO - Add Validação

			job.PublicationDate = DateTime.Now;
			_data.Jobs.Add(job);
			_data.SaveChanges();

			return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job); // HTTP - 201
		}

		//// GET: api/values
		//[HttpGet]
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		//// GET api/values/5
		//[HttpGet("{id}")]
		//public string Get(int id)
		//{
		//	return "value";
		//}

		//// POST api/values
		//[HttpPost]
		//public void Post([FromBody] string value)
		//{
		//}

		//// PUT api/values/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/values/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
