using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class ParserConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        kind: prompty
        options:
          key: value
        
        """;

        
        var instance = YamlSerializer.Deserialize<Parser>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("prompty", instance.Kind);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for Parser, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "kind": "prompty",
          "options": {
            "key": "value"
          }
        }
        """;

        var instance = JsonSerializer.Deserialize<Parser>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("prompty", instance.Kind);
    }
    [Fact]
    public void LoadJsonFromString()
    {
        // alternate representation as string
        var data = "\"example\"";
        var instance = JsonSerializer.Deserialize<Parser>(data);
        Assert.NotNull(instance);
        Assert.Equal("example", instance.Kind);
    }


    [Fact]
    public void LoadYamlFromString()
    {
        // alternate representation as string
        /*
        var data = "\"example\"";
        var instance = YamlSerializer.Deserialize<Parser>(data);
        Assert.NotNull(instance);
        Assert.Equal("example", instance.Kind);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for Parser String shorthand , WiP");
    }

}