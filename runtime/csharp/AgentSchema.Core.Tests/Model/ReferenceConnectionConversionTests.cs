using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class ReferenceConnectionConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        kind: reference
        name: my-reference-connection
        target: my-target-resource
        
        """;

        
        var instance = YamlSerializer.Deserialize<ReferenceConnection>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("reference", instance.Kind);
        Assert.Equal("my-reference-connection", instance.Name);
        Assert.Equal("my-target-resource", instance.Target);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for ReferenceConnection, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "kind": "reference",
          "name": "my-reference-connection",
          "target": "my-target-resource"
        }
        """;

        var instance = JsonSerializer.Deserialize<ReferenceConnection>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("reference", instance.Kind);
        Assert.Equal("my-reference-connection", instance.Name);
        Assert.Equal("my-target-resource", instance.Target);
    }
}