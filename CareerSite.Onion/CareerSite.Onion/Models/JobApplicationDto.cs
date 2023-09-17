using System;

namespace CareerSite.Onion.WebApi.Models
{
	public class JobApplicationDto
	{
		public Guid Id { get; set; }
		public string PositionName { get; set; }
		public string PositionLevel { get; set; }
		public string AppicantFullName { get; set; }
		public string ApplicantEmail { get; set; }
		public string ApplicantLinkedinUrl { get; set; }
		public decimal ApplicantSalaryExpectations { get; set; }
		public int ApplicantYearsOfExperience { get; set; }
	}
}
