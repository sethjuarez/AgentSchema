using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class ProtocolVersionRecordConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        protocol: responses
        version: v0.1.1
        
        """;

        
        var instance = YamlSerializer.Deserialize<ProtocolVersionRecord>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("responses", instance.Protocol);
        Assert.Equal("v0.1.1", instance.Version);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for ProtocolVersionRecord, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "protocol": "responses",
          "version": "v0.1.1"
        }
        """;

        var instance = JsonSerializer.Deserialize<ProtocolVersionRecord>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("responses", instance.Protocol);
        Assert.Equal("v0.1.1", instance.Version);
    }
}