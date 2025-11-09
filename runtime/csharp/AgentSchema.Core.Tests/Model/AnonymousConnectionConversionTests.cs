using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class AnonymousConnectionConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        kind: anonymous
        endpoint: https://{your-custom-endpoint}.openai.azure.com/
        
        """;

        
        var instance = YamlSerializer.Deserialize<AnonymousConnection>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("anonymous", instance.Kind);
        Assert.Equal("https://{your-custom-endpoint}.openai.azure.com/", instance.Endpoint);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for AnonymousConnection, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "kind": "anonymous",
          "endpoint": "https://{your-custom-endpoint}.openai.azure.com/"
        }
        """;

        var instance = JsonSerializer.Deserialize<AnonymousConnection>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("anonymous", instance.Kind);
        Assert.Equal("https://{your-custom-endpoint}.openai.azure.com/", instance.Endpoint);
    }
}