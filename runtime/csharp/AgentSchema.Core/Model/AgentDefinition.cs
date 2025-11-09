// Copyright (c) Microsoft. All rights reserved.
using System.Text.Json.Serialization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.RepresentationModel;

#pragma warning disable IDE0130
namespace AgentSchema.Core;
#pragma warning restore IDE0130

/// <summary>
/// The following is a specification for defining AI agents with structured metadata, inputs, outputs, tools, and templates.
/// It provides a way to create reusable and composable AI agents that can be executed with specific configurations.
/// The specification includes metadata about the agent, model configuration, input parameters, expected outputs,
/// available tools, and template configurations for prompt rendering.
/// </summary>
[JsonConverter(typeof(AgentDefinitionJsonConverter))]
public abstract class AgentDefinition : IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="AgentDefinition"/>.
    /// </summary>
#pragma warning disable CS8618
    protected AgentDefinition()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// Kind represented by the document
    /// </summary>
    public virtual string Kind { get; set; } = string.Empty;

    /// <summary>
    /// Human-readable name of the agent
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Display name of the agent for UI purposes
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// Description of the agent's capabilities and purpose
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Additional metadata including authors, tags, and other arbitrary properties
    /// </summary>
    public IDictionary<string, object>? Metadata { get; set; }

    /// <summary>
    /// Input parameters that participate in template rendering
    /// </summary>
    public PropertySchema? InputSchema { get; set; }

    /// <summary>
    /// Expected output format and structure from the agent
    /// </summary>
    public PropertySchema? OutputSchema { get; set; }


    public void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type AgentDefinition");
        }

        // handle polymorphic types
        if (node.Children.TryGetValue(new YamlScalarNode("kind"), out var discriminatorNode))
        {
            var discriminatorValue = (discriminatorNode as YamlScalarNode)?.Value;
            switch (discriminatorValue)
            {
                case "prompt":
                    var promptAgentDefinition = nestedObjectDeserializer(typeof(PromptAgent)) as PromptAgent;
                    if (promptAgentDefinition == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type PromptAgent");
                    }
                    return;
                case "workflow":
                    var workflowAgentDefinition = nestedObjectDeserializer(typeof(Workflow)) as Workflow;
                    if (workflowAgentDefinition == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type Workflow");
                    }
                    return;
                case "hosted":
                    var hostedAgentDefinition = nestedObjectDeserializer(typeof(ContainerAgent)) as ContainerAgent;
                    if (hostedAgentDefinition == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type ContainerAgent");
                    }
                    return;
                default:
                    throw new YamlException($"Unknown type discriminator '' when parsing AgentDefinition");

            }
        }
    }

    public void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        emitter.Emit(new Scalar("name"));
        nestedObjectSerializer(Name);

        if (DisplayName != null)
        {
            emitter.Emit(new Scalar("displayName"));
            nestedObjectSerializer(DisplayName);
        }


        if (Description != null)
        {
            emitter.Emit(new Scalar("description"));
            nestedObjectSerializer(Description);
        }


        if (Metadata != null)
        {
            emitter.Emit(new Scalar("metadata"));
            nestedObjectSerializer(Metadata);
        }


        if (InputSchema != null)
        {
            emitter.Emit(new Scalar("inputSchema"));
            nestedObjectSerializer(InputSchema);
        }


        if (OutputSchema != null)
        {
            emitter.Emit(new Scalar("outputSchema"));
            nestedObjectSerializer(OutputSchema);
        }

    }
}
