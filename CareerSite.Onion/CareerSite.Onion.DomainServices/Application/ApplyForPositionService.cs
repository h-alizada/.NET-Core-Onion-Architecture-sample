using CareerSite.Onion.Domain.Application;
using CareerSite.Onion.Domain.Exceptions;
using CareerSite.Onion.DomainServices.Core.Application;
using CareerSite.Onion.InfrastructureServices.Core.Application;
using System.Threading;
using System.Threading.Tasks;

namespace CareerSite.Onion.DomainServices.Application
{
	public class ApplyForPositionService : IApplyForPositionService
	{
		private readonly IApplyForPositionInfrastructureService _infrastructureService;
		public ApplyForPositionService(IApplyForPositionInfrastructureService infrastructureService)
		{
			_infrastructureService = infrastructureService;
		}

		public async Task Apply(JobApplication application, CancellationToken cancellationToken)
		{
			CheckYearsOfExperience(application);
			CheckSalaryExpectation(application);

			var hasCleanBackground = await _infrastructureService.HasCleanBackground(application.AppicantFullName, cancellationToken);

			if (!hasCleanBackground)
			{
				throw new ApplicantBackgroundIssueException();
			}

			await _infrastructureService.AddApplication(application, cancellationToken);
		}

		private void CheckYearsOfExperience(JobApplication application)
		{
			if(application.PositionLevel == PositionLevel.Junior && application.ApplicantYearsOfExperience < 1)
			{
				throw new YearsOfExperienceIsNotSatisfiedForThePositionException();
			}

			if (application.PositionLevel == PositionLevel.Middle && application.ApplicantYearsOfExperience < 3)
			{
				throw new YearsOfExperienceIsNotSatisfiedForThePositionException();
			}

			if (application.PositionLevel == PositionLevel.Senior && application.ApplicantYearsOfExperience < 5)
			{
				throw new YearsOfExperienceIsNotSatisfiedForThePositionException();
			}
		}

		private void CheckSalaryExpectation(JobApplication application)
		{
			if (application.PositionLevel == PositionLevel.Junior && application.ApplicantSalaryExpectations > 2000)
			{
				throw new SalaryExpectationIsTooMuchException();
			}

			if (application.PositionLevel == PositionLevel.Middle && application.ApplicantSalaryExpectations > 4000)
			{
				throw new SalaryExpectationIsTooMuchException();
			}

			if (application.PositionLevel == PositionLevel.Senior && application.ApplicantSalaryExpectations > 6000)
			{
				throw new SalaryExpectationIsTooMuchException();
			}
		}
	}
}
