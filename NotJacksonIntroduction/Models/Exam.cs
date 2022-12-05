using System.Text.Json.Serialization;
using NotJacksonIntroduction.Converters;

namespace NotJacksonIntroduction.Models;

public class Exam
{
    [JsonPropertyName("examId")] public int ExamId { get; set; }

    [JsonPropertyName("dateofexam")]
    [JsonDateTimeFormat("dd/MM/yyyy")]
    public DateTime DateOfExam { get; set; }

    [JsonPropertyName("duration")]
    [JsonConverter(typeof(DurationConverter))]
    public TimeSpan Duration { get; set; }
}