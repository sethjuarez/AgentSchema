using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class ResourceConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        name: my-resource
        kind: model
        
        """;

        
        var instance = YamlSerializer.Deserialize<Resource>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("my-resource", instance.Name);
        Assert.Equal("model", instance.Kind);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for Resource, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "name": "my-resource",
          "kind": "model"
        }
        """;

        var instance = JsonSerializer.Deserialize<Resource>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("my-resource", instance.Name);
        Assert.Equal("model", instance.Kind);
    }
}