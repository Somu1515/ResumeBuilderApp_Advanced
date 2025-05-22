using ResumeBuilderApp_Advanced.Models;

namespace ResumeBuilderApp_Advanced.Services
{
    public class ResumeHtmlExporter
    {
        public string Generate(Resume resume)
        {
            // Implement HTML export logic
            return $"<html><body><h1>{resume.FullName}</h1></body></html>";
        }
    }
}