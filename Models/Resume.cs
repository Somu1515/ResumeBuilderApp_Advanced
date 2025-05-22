using System.Collections.Generic;

namespace ResumeBuilderApp_Advanced.Models
{
    public class Resume
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Summary { get; set; }
        public List<Education> Educations { get; set; } = new();
        public List<Experience> Experiences { get; set; } = new();
        public List<string> Skills { get; set; } = new();
    }

    public class Education
    {
        public string School { get; set; }
        public string Degree { get; set; }
        public string Field { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
    }

    public class Experience
    {
        public string Company { get; set; }
        public string Role { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
    }
}