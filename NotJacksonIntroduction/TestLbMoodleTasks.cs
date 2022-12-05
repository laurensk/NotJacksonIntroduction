using System.Globalization;
using System.Text.Json;
using NotJacksonIntroduction.Models;
using Xunit;

namespace NotJacksonIntroduction;

public class TestLbMoodleTasks
{
    [Fact]
    public void TestTask1()
    {
        var classes = JsonSerializer.Deserialize<List<Class>>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Resources/examdb.json"))!;

        var students = classes
            .Where(c => c.ClassName == "3BHIF")
            .SelectMany(c => c.Students)
            .Where(s => s.Exams.Any(e => e.Duration == TimeSpan.FromMinutes(30)))
            .OrderBy(s => s.LastName)
            .ToList();

        var studentNames = students
            .Select(s => $"{s.LastName} {s.FirstName}")
            .ToArray();

        Assert.Equal(new[] {"Cuffin Marcos", "Dubose Coletta", "L' Anglois Appolonia", "McPike Cary"}, studentNames);
    }

    [Fact]
    public void TestTask2()
    {
        var classes = JsonSerializer.Deserialize<List<Class>>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Resources/examdb.json"))!;

        var startDate = DateTime.ParseExact("2018-01-01", "yyyy-dd-MM", CultureInfo.InvariantCulture);
        var endDate = DateTime.ParseExact("2022-01-01", "yyyy-dd-MM", CultureInfo.InvariantCulture);

        var examCount = classes
            .SelectMany(c => c.Students)
            .Count(s => s.Exams.Any(e => e.DateOfExam >= startDate && e.DateOfExam <= endDate));

        Assert.Equal(183, examCount);
    }
}