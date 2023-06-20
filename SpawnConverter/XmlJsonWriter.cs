using Newtonsoft.Json;

namespace SpawnConverter;

public class XmlJsonWriter : JsonTextWriter
{
    public XmlJsonWriter(TextWriter writer): base(writer){}

    public override void WritePropertyName(string name)
    {
        if (name.StartsWith("@") || name.StartsWith("#"))
        {
            base.WritePropertyName(name.Substring(1));
        }
        else
        {
            base.WritePropertyName(name);
        }
    }
}