using CareerSite.Onion.Domain.Application;
using CareerSite.Onion.WebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace CareerSite.Onion.WebApi.Mappers
{
	public static class JobApplicationMapper
	{
		public static JobApplication ToDomain(this JobApplicationDto jobApplicationDto)
		{
			return new JobApplication
			{
				AppicantFullName = jobApplicationDto.AppicantFullName,
				ApplicantEmail = jobApplicationDto.ApplicantEmail,
				ApplicantLinkedinUrl = jobApplicationDto.ApplicantLinkedinUrl,
				ApplicantSalaryExpectations = jobApplicationDto.ApplicantSalaryExpectations,
				ApplicantYearsOfExperience = jobApplicationDto.ApplicantYearsOfExperience,
				PositionName = GetPosition(jobApplicationDto.PositionName),
				PositionLevel = GetPositionLevel(jobApplicationDto.PositionLevel)
			};
		}

		private static Position GetPosition(string position)
		{
			switch (position)
			{
				case "back_end_developer": return Position.BackEndDeveloper;
				case "front_end_developer": return Position.FrontEndDeveloper;
				case "full_stack_developer":  return Position.FullStackDeveloper;
				default:throw new ValidationException($"{position} is invalid position value");
			}
		}

		private static PositionLevel GetPositionLevel(string positionLevel)
		{
			switch (positionLevel)
			{
				case "junior": return PositionLevel.Junior;
				case "middle": return PositionLevel.Middle;
				case "senior": return PositionLevel.Senior;
				default: throw new ValidationException($"{positionLevel} is invalid position level value");
			}
		}
	}
}
