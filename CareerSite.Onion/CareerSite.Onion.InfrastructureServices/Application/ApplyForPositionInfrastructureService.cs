using CareerSite.Onion.Domain.Application;
using CareerSite.Onion.Infrastructure.Core.ApiClients;
using CareerSite.Onion.Infrastructure.Core.Repositories;
using CareerSite.Onion.InfrastructureServices.Core.Application;
using System.Threading;
using System.Threading.Tasks;

namespace CareerSite.Onion.InfrastructureServices.Application
{
	public class ApplyForPositionInfrastructureService : IApplyForPositionInfrastructureService
	{
		private readonly IJobApplicationRepository _repository;
		private readonly IBackgroundCheckApiClient _apiClient;
		public ApplyForPositionInfrastructureService(IJobApplicationRepository repository, IBackgroundCheckApiClient apiClient)
		{
			_repository = repository;
			_apiClient = apiClient;
		}

		public Task AddApplication(JobApplication application, CancellationToken cancellationToken)
		{
			return _repository.AddAsync(application, cancellationToken);
		}

		public Task<bool> HasCleanBackground(string applicantFullName, CancellationToken cancellationToken)
		{
			return _apiClient.CheckAsync(applicantFullName, cancellationToken);
		}
	}
}
