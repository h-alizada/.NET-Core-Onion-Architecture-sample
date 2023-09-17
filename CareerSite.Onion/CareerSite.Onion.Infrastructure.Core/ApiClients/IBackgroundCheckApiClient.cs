using System.Threading;
using System.Threading.Tasks;

namespace CareerSite.Onion.Infrastructure.Core.ApiClients
{
	public interface IBackgroundCheckApiClient
	{
		Task<bool> CheckAsync(string applicantFullName, CancellationToken cancellationToken);
	}
}
