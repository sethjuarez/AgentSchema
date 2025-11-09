using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class RemoteConnectionConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        kind: remote
        name: my-reference-connection
        endpoint: https://{your-custom-endpoint}.openai.azure.com/
        
        """;

        
        var instance = YamlSerializer.Deserialize<RemoteConnection>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("remote", instance.Kind);
        Assert.Equal("my-reference-connection", instance.Name);
        Assert.Equal("https://{your-custom-endpoint}.openai.azure.com/", instance.Endpoint);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for RemoteConnection, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "kind": "remote",
          "name": "my-reference-connection",
          "endpoint": "https://{your-custom-endpoint}.openai.azure.com/"
        }
        """;

        var instance = JsonSerializer.Deserialize<RemoteConnection>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("remote", instance.Kind);
        Assert.Equal("my-reference-connection", instance.Name);
        Assert.Equal("https://{your-custom-endpoint}.openai.azure.com/", instance.Endpoint);
    }
}