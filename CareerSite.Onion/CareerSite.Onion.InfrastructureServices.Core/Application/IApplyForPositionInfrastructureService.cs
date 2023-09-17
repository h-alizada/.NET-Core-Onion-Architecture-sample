using CareerSite.Onion.Domain.Application;
using System.Threading;
using System.Threading.Tasks;

namespace CareerSite.Onion.InfrastructureServices.Core.Application
{
	public interface IApplyForPositionInfrastructureService
	{
		Task AddApplication(JobApplication application, CancellationToken cancellationToken);
		Task<bool> HasCleanBackground(string applicantFullName, CancellationToken cancellationToken);
	}
}
