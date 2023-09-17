using System;

namespace CareerSite.Onion.Domain.Application
{
	public class JobApplication
	{
		public Guid Id { get; set; }
		public Position PositionName { get; set; }
		public PositionLevel PositionLevel { get; set; }
		public string AppicantFullName { get; set; }
		public string ApplicantEmail { get; set; }
		public string ApplicantLinkedinUrl { get; set; }
		public decimal ApplicantSalaryExpectations { get; set; }
		public int ApplicantYearsOfExperience { get; set; }
	}
}
