using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class WebSearchToolConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        kind: bing_search
        connection:
          kind: reference
        options:
          instanceName: MyBingInstance
          market: en-US
          setLang: en
          count: 10
          freshness: Day
        
        """;

        
        var instance = YamlSerializer.Deserialize<WebSearchTool>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("bing_search", instance.Kind);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for WebSearchTool, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "kind": "bing_search",
          "connection": {
            "kind": "reference"
          },
          "options": {
            "instanceName": "MyBingInstance",
            "market": "en-US",
            "setLang": "en",
            "count": 10,
            "freshness": "Day"
          }
        }
        """;

        var instance = JsonSerializer.Deserialize<WebSearchTool>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("bing_search", instance.Kind);
    }
}