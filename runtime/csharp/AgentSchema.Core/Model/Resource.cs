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
/// Represents a resource required by the agent
/// Resources can include databases, APIs, or other external systems
/// that the agent needs to interact with to perform its tasks
/// </summary>
[JsonConverter(typeof(ResourceJsonConverter))]
public abstract class Resource : IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="Resource"/>.
    /// </summary>
#pragma warning disable CS8618
    protected Resource()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// Name of the resource
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The kind of resource (e.g., model, tool)
    /// </summary>
    public virtual string Kind { get; set; } = string.Empty;


    public void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type Resource");
        }

        // handle polymorphic types
        if (node.Children.TryGetValue(new YamlScalarNode("kind"), out var discriminatorNode))
        {
            var discriminatorValue = (discriminatorNode as YamlScalarNode)?.Value;
            switch (discriminatorValue)
            {
                case "model":
                    var modelResource = nestedObjectDeserializer(typeof(ModelResource)) as ModelResource;
                    if (modelResource == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type ModelResource");
                    }
                    return;
                case "tool":
                    var toolResource = nestedObjectDeserializer(typeof(ToolResource)) as ToolResource;
                    if (toolResource == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type ToolResource");
                    }
                    return;
                default:
                    throw new YamlException($"Unknown type discriminator '' when parsing Resource");

            }
        }
    }

    public void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("name"));
        nestedObjectSerializer(Name);

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);
    }
}
