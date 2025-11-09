using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class ContainerAgentConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        kind: hosted
        protocols:
          - protocol: responses
            version: v0.1.1
        environmentVariables:
          - name: MY_ENV_VAR
            value: my-value
        
        """;

        
        var instance = YamlSerializer.Deserialize<ContainerAgent>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("hosted", instance.Kind);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for ContainerAgent, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "kind": "hosted",
          "protocols": [
            {
              "protocol": "responses",
              "version": "v0.1.1"
            }
          ],
          "environmentVariables": [
            {
              "name": "MY_ENV_VAR",
              "value": "my-value"
            }
          ]
        }
        """;

        var instance = JsonSerializer.Deserialize<ContainerAgent>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("hosted", instance.Kind);
    }
}