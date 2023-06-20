using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using SpawnConverter;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

Console.WriteLine("Type xml spawn file name:");

var spawnFile= Console.ReadLine();

if (string.IsNullOrWhiteSpace(spawnFile))
{
    Console.WriteLine("Invalid file name");
    return;
}

var filePath = Path.Combine(Environment.CurrentDirectory, spawnFile);
if (!File.Exists(filePath))
{
    Console.WriteLine("Specified file not found");
    return;
}

var content = File.ReadAllText(spawnFile);

var xDocument = XDocument.Parse(content);
var builder = new StringBuilder();
JsonSerializer.Create().Serialize(new XmlJsonWriter(new StringWriter(builder)), xDocument);

var jsonText = builder.ToString();

var originalSpawn = JsonConvert.DeserializeObject<OriginalSpawn>(jsonText);

var newSpawn = originalSpawn.spawns.spawn;

var jsonFile = filePath.Replace(".xml", ".json");

if (File.Exists(jsonFile))
{
    Console.Write("Json spawn file already exists. Do you want to replace (y|N)? ");
    var answer = Console.ReadLine();

    if (answer?.Equals("N", StringComparison.InvariantCultureIgnoreCase) ?? true) return;
    
    File.Delete(jsonFile);
}

File.WriteAllText(jsonFile, JsonConvert.SerializeObject(newSpawn, Formatting.Indented));

Console.WriteLine("Spawn file created successfully");
Console.WriteLine("Enter any key to exit");
Console.Read();



