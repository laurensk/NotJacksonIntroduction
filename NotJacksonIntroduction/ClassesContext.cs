using System.Text.Json;
using NotJacksonIntroduction.Models;

namespace NotJacksonIntroduction;

public class ClassesContext
{
    private List<Class> Classes { get; set; }

    public ClassesContext()
    {
        Classes = JsonSerializer.Deserialize<List<Class>>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Resources/examdb.json"))!;
    }

    public List<Class> GetAllClasses()
    {
        return Classes;
    }

    public List<Student> GetStudentsByClassAndExamDuration(string className, TimeSpan examDuration)
    {
        return Classes
            .Where(c => c.ClassName == "3BHIF")
            .SelectMany(c => c.Students)
            .Where(s => s.Exams.Any(e => e.Duration == TimeSpan.FromMinutes(30)))
            .OrderBy(s => s.LastName)
            .ToList();
    }

    public int GetStudentCountForExamDateRange(DateTime startDate, DateTime endDate)
    {
        return Classes
            .SelectMany(c => c.Students)
            .Count(s => s.Exams.Any(e => e.DateOfExam >= startDate && e.DateOfExam <= endDate));
    }
}