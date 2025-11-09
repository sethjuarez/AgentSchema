using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class McpServerApprovalModeConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        kind: never
        
        """;

        
        var instance = YamlSerializer.Deserialize<McpServerApprovalMode>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("never", instance.Kind);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for McpServerApprovalMode, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "kind": "never"
        }
        """;

        var instance = JsonSerializer.Deserialize<McpServerApprovalMode>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("never", instance.Kind);
    }
    [Fact]
    public void LoadJsonFromString()
    {
        // alternate representation as string
        var data = "\"never\"";
        var instance = JsonSerializer.Deserialize<McpServerApprovalMode>(data);
        Assert.NotNull(instance);
        Assert.Equal("never", instance.Kind);
    }


    [Fact]
    public void LoadYamlFromString()
    {
        // alternate representation as string
        /*
        var data = "\"never\"";
        var instance = YamlSerializer.Deserialize<McpServerApprovalMode>(data);
        Assert.NotNull(instance);
        Assert.Equal("never", instance.Kind);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for McpServerApprovalMode String shorthand , WiP");
    }

}