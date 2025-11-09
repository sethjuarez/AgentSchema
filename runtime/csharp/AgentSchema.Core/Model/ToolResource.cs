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
/// Represents a tool resource required by the agent
/// </summary>
[JsonConverter(typeof(ToolResourceJsonConverter))]
public class ToolResource : Resource, IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="ToolResource"/>.
    /// </summary>
#pragma warning disable CS8618
    public ToolResource()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// The kind identifier for tool resources
    /// </summary>
    public override string Kind { get; set; } = "tool";

    /// <summary>
    /// The unique identifier of the tool resource
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Configuration options for the tool resource
    /// </summary>
    public IDictionary<string, object> Options { get; set; } = new Dictionary<string, object>();


    public new void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type ToolResource");
        }

    }

    public new void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        emitter.Emit(new Scalar("id"));
        nestedObjectSerializer(Id);

        emitter.Emit(new Scalar("options"));
        nestedObjectSerializer(Options);
    }
}
