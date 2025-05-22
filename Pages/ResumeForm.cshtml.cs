using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeBuilderApp_Advanced.Models;
using ResumeBuilderApp_Advanced.Services;
using System.Text.Json;
using System.Text;

public class ResumeFormModel : PageModel
{
    [BindProperty]
    public Resume Resume { get; set; }
    [BindProperty]
    public string SkillsInput { get; set; }
    [BindProperty]
    public string ExportFormat { get; set; }

    private readonly ResumePdfGenerator _pdf;
    private readonly ResumeDocxExporter _docx;
    private readonly ResumeHtmlExporter _html;

    public ResumeFormModel(ResumePdfGenerator pdf, ResumeDocxExporter docx, ResumeHtmlExporter html)
    {
        _pdf = pdf;
        _docx = docx;
        _html = html;
    }

    public IActionResult OnPost()
    {
        Resume.Skills = SkillsInput?.Split(',').Select(s => s.Trim()).ToList() ?? new List<string>();

        return ExportFormat switch
        {
            "PDF" => File(_pdf.Generate(Resume), "application/pdf", "resume.pdf"),
            "DOCX" => File(_docx.Generate(Resume), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "resume.docx"),
            "HTML" => File(Encoding.UTF8.GetBytes(_html.Generate(Resume)), "text/html", "resume.html"),
            "JSON" => File(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(Resume)), "application/json", "resume.json"),
            _ => Page()
        };
    }
}