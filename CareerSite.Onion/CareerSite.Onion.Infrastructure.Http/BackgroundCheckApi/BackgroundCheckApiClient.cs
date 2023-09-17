using CareerSite.Onion.Infrastructure.Core.ApiClients;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CareerSite.Onion.Infrastructure.Http.BackgroundCheckApi
{
	public class BackgroundCheckApiClient : IBackgroundCheckApiClient
	{
		// just mock api
		public Task<bool> CheckAsync(string applicantFullName, CancellationToken cancellationToken)
		{
			return Task.FromResult(!applicantFullName.Equals("prohibited-fullname", StringComparison.OrdinalIgnoreCase));
		}
	}
}
