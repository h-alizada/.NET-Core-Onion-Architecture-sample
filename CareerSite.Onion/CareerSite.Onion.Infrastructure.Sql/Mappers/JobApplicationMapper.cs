using CareerSite.Onion.Domain.Application;
using CareerSite.Onion.Infrastructure.Sql.Entities;
using System;

namespace CareerSite.Onion.Infrastructure.Sql.Mappers
{
	public static class JobApplicationMapper
	{
		public static JobApplicationEntity ToEntity(this JobApplication jobApplication)
		{
			return new JobApplicationEntity
			{
				Id = Guid.NewGuid(),
				AppicantFullName = jobApplication.AppicantFullName,
				ApplicantEmail = jobApplication.ApplicantEmail,
				ApplicantLinkedinUrl = jobApplication.ApplicantLinkedinUrl,
				ApplicantSalaryExpectations = jobApplication.ApplicantSalaryExpectations,
				ApplicantYearsOfExperience = jobApplication.ApplicantYearsOfExperience,
				PositionLevel = jobApplication.PositionLevel.ToString(),
				PositionName = jobApplication.PositionName.ToString()
			};
		}
	}
}
