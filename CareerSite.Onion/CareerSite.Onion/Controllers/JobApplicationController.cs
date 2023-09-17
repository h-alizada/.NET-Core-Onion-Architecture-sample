using CareerSite.Onion.DomainServices.Core.Application;
using CareerSite.Onion.WebApi.Mappers;
using CareerSite.Onion.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CareerSite.Onion.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobApplicationController : ControllerBase
	{
		private readonly IApplyForPositionService _service;
		public JobApplicationController(IApplyForPositionService service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<ActionResult> ApplyForJob([FromBody] JobApplicationDto jobApplicationDto, CancellationToken cancellationToken)
		{
			await _service.Apply(jobApplicationDto.ToDomain(), cancellationToken);

			return Created("", null);
		}
	}
}
