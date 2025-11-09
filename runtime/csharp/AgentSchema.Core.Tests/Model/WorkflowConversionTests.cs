using Xunit;
using System.Text.Json;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130


public class WorkflowConversionTests
{
    [Fact]
    public void LoadYamlInput()
    {
        /*
        string yamlData = """
        kind: workflow
        
        """;

        
        var instance = YamlSerializer.Deserialize<Workflow>(yamlData);

        Assert.NotNull(instance);
        Assert.Equal("workflow", instance.Kind);
        */
        Console.WriteLine("YamlSerialization Currently incomplete for Workflow, WiP");
    }

    [Fact]
    public void LoadJsonInput()
    {
        string jsonData = """
        {
          "kind": "workflow"
        }
        """;

        var instance = JsonSerializer.Deserialize<Workflow>(jsonData);
        Assert.NotNull(instance);
        Assert.Equal("workflow", instance.Kind);
    }
}