using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class ToolResourceConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        kind: tool
        id: web-search
        options:
          myToolResourceProperty: myValue
        
        """;

        
        var instance = YamlSerializer.Deserialize<ToolResource>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("tool", instance.Kind);
        Assert.Equal("web-search", instance.Id);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for ToolResource, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "kind": "tool",
          "id": "web-search",
          "options": {
            "myToolResourceProperty": "myValue"
          }
        }
        """;

        var instance = JsonSerializer.Deserialize<ToolResource>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("tool", instance.Kind);
        Assert.Equal("web-search", instance.Id);
    }
}