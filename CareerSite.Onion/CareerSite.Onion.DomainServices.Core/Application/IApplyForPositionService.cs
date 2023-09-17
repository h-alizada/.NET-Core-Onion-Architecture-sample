using CareerSite.Onion.Domain.Application;
using System.Threading;
using System.Threading.Tasks;

namespace CareerSite.Onion.DomainServices.Core.Application
{
	public interface IApplyForPositionService
	{
		Task Apply(JobApplication application, CancellationToken cancellationToken);
	}
}
