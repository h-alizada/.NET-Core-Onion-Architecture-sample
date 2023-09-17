using CareerSite.Onion.Domain.Application;
using CareerSite.Onion.Infrastructure.Core.Repositories;
using CareerSite.Onion.Infrastructure.Sql.Context;
using CareerSite.Onion.Infrastructure.Sql.Mappers;
using System.Threading;
using System.Threading.Tasks;

namespace CareerSite.Onion.Infrastructure.Sql.Repositories
{
	public class JobApplicationRepository : IJobApplicationRepository
	{
		private readonly CareerSiteContext _context;
		public JobApplicationRepository()
		{
			_context = new CareerSiteContext();
		}

		public Task AddAsync(JobApplication application, CancellationToken cancellationToken)
		{
			_context.JobApplications.AddAsync(application.ToEntity(), cancellationToken);

			return _context.SaveChangesAsync(cancellationToken);
		}
	}
}
