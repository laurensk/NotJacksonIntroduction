using System.Globalization;
using Xunit;

namespace NotJacksonIntroduction;

public class ClassesContextTests
{
    [Fact]
    public void TestGetStudentsByClassAndExamDuration()
    {
        var context = new ClassesContext();

        var students = context.GetStudentsByClassAndExamDuration("3BHIF", TimeSpan.FromMinutes(30));

        var studentNames = students
            .Select(s => $"{s.LastName} {s.FirstName}")
            .ToArray();

        Assert.Equal(new[] {"Cuffin Marcos", "Dubose Coletta", "L' Anglois Appolonia", "McPike Cary"}, studentNames);
    }

    [Fact]
    public void TestGetStudentCountForExamDateRange()
    {
        var context = new ClassesContext();

        var startDate = DateTime.ParseExact("2018-01-01", "yyyy-dd-MM", CultureInfo.InvariantCulture);
        var endDate = DateTime.ParseExact("2022-01-01", "yyyy-dd-MM", CultureInfo.InvariantCulture);

        var examCount = context.GetStudentCountForExamDateRange(startDate, endDate);

        Assert.Equal(183, examCount);
    }
}