using System.Text.Json.Serialization;

namespace NotJacksonIntroduction.Models;

public class Class
{
    [JsonPropertyName("classId")] public int ClassId { get; set; }

    [JsonPropertyName("classname")] public string ClassName { get; set; }

    [JsonPropertyName("students")] public List<Student> Students { get; set; }
}