using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class McpServerToolAlwaysRequireApprovalModeConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        kind: always
        
        """;

        
        var instance = YamlSerializer.Deserialize<McpServerToolAlwaysRequireApprovalMode>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("always", instance.Kind);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for McpServerToolAlwaysRequireApprovalMode, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "kind": "always"
        }
        """;

        var instance = JsonSerializer.Deserialize<McpServerToolAlwaysRequireApprovalMode>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("always", instance.Kind);
    }
}