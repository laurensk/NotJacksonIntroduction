using System.Text.Json;
using NotJacksonIntroduction.Models;

var classes = JsonSerializer.Deserialize<List<Class>>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Resources/examdb.json"))!;