using System;
using System.Collections.Generic;
using System.Text;

namespace CareerSite.Onion.Infrastructure.Sql.Entities
{
	public class JobApplicationEntity
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
