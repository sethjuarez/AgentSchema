using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class EnvironmentVariableConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        name: MY_ENV_VAR
        value: my-value
        
        """;

        
        var instance = YamlSerializer.Deserialize<EnvironmentVariable>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("MY_ENV_VAR", instance.Name);
        Assert.Equal("my-value", instance.Value);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for EnvironmentVariable, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "name": "MY_ENV_VAR",
          "value": "my-value"
        }
        """;

        var instance = JsonSerializer.Deserialize<EnvironmentVariable>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("MY_ENV_VAR", instance.Name);
        Assert.Equal("my-value", instance.Value);
    }
}