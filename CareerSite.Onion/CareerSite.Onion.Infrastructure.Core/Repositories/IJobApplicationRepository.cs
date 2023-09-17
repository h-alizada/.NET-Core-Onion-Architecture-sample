using CareerSite.Onion.Domain.Application;
using System.Threading;
using System.Threading.Tasks;

namespace CareerSite.Onion.Infrastructure.Core.Repositories
{
	public interface IJobApplicationRepository
	{
		Task AddAsync(JobApplication application, CancellationToken cancellationToken);
	}
}
