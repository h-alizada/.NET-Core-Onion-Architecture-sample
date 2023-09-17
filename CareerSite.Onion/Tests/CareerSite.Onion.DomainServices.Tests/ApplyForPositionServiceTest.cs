using CareerSite.Onion.Domain.Application;
using CareerSite.Onion.Domain.Exceptions;
using CareerSite.Onion.DomainServices.Application;
using CareerSite.Onion.InfrastructureServices.Core.Application;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace CareerSite.Onion.DomainServices.Tests
{
	public class ApplyForPositionServiceTest
	{
		private Mock<IApplyForPositionInfrastructureService> _mockInfrastructure;
		[SetUp]
		public void Setup()
		{
			_mockInfrastructure = new Mock<IApplyForPositionInfrastructureService>();
		}

		[Test]
		public async Task Apply_YearsOfExperienceAndSalaryExpectationAndBackgroundCheckIsOkay_InsertApplication()
		{
			_mockInfrastructure.Setup(x => x.HasCleanBackground(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

			var service = new ApplyForPositionService(_mockInfrastructure.Object);

			await service.Apply(new JobApplication {
				
				AppicantFullName = It.IsAny<string>(),
				ApplicantEmail = It.IsAny<string>(),
				ApplicantLinkedinUrl = It.IsAny<string>(),
				ApplicantSalaryExpectations = 5000,
				ApplicantYearsOfExperience = 9,
				PositionLevel = PositionLevel.Senior,
				PositionName = Position.BackEndDeveloper
			}, CancellationToken.None);

			_mockInfrastructure.Verify(x => x.AddApplication(It.IsAny<JobApplication>(), CancellationToken.None), Times.Once);
		}

		[Test]
		public async Task Apply_YearsOfExperienceDoesNotMatchLevel_Throws()
		{
			_mockInfrastructure.Setup(x => x.HasCleanBackground(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

			var service = new ApplyForPositionService(_mockInfrastructure.Object);

			
			Assert.ThrowsAsync<YearsOfExperienceIsNotSatisfiedForThePositionException>(async ()=> {

				await service.Apply(new JobApplication
				{

					AppicantFullName = It.IsAny<string>(),
					ApplicantEmail = It.IsAny<string>(),
					ApplicantLinkedinUrl = It.IsAny<string>(),
					ApplicantSalaryExpectations = 5000,
					ApplicantYearsOfExperience = 1,
					PositionLevel = PositionLevel.Senior,
					PositionName = Position.BackEndDeveloper
				}, CancellationToken.None);

			});
		}

		[Test]
		public async Task Apply_SalaryExpectationDoesNotMatchLevel_Throws()
		{
			_mockInfrastructure.Setup(x => x.HasCleanBackground(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

			var service = new ApplyForPositionService(_mockInfrastructure.Object);


			Assert.ThrowsAsync<SalaryExpectationIsTooMuchException>(async () => {

				await service.Apply(new JobApplication
				{

					AppicantFullName = It.IsAny<string>(),
					ApplicantEmail = It.IsAny<string>(),
					ApplicantLinkedinUrl = It.IsAny<string>(),
					ApplicantSalaryExpectations = 15000,
					ApplicantYearsOfExperience = 10,
					PositionLevel = PositionLevel.Senior,
					PositionName = Position.BackEndDeveloper
				}, CancellationToken.None);

			});
		}

		[Test]
		public async Task Apply_BackGroundCheckHasAnIssue_Throws()
		{
			_mockInfrastructure.Setup(x => x.HasCleanBackground(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);

			var service = new ApplyForPositionService(_mockInfrastructure.Object);


			Assert.ThrowsAsync<ApplicantBackgroundIssueException>(async () => {

				await service.Apply(new JobApplication
				{

					AppicantFullName = It.IsAny<string>(),
					ApplicantEmail = It.IsAny<string>(),
					ApplicantLinkedinUrl = It.IsAny<string>(),
					ApplicantSalaryExpectations = 5000,
					ApplicantYearsOfExperience = 10,
					PositionLevel = PositionLevel.Senior,
					PositionName = Position.BackEndDeveloper
				}, CancellationToken.None);

			});
		}
	}
}