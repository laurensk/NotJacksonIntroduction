using System.Text.Json.Serialization;

namespace NotJacksonIntroduction.Models;

public class Student
{
    [JsonPropertyName("firstname")] public string FirstName { get; set; }

    [JsonPropertyName("lastname")] public string LastName { get; set; }

    [JsonPropertyName("exams")] public List<Exam> Exams { get; set; }
}