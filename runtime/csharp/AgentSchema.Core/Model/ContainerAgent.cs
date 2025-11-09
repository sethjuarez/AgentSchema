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
/// This represents a container based agent hosted by the provider/publisher.
/// The intent is to represent a container application that the user wants to run
/// in a hosted environment that the provider manages.
/// </summary>
[JsonConverter(typeof(ContainerAgentJsonConverter))]
public class ContainerAgent : AgentDefinition, IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="ContainerAgent"/>.
    /// </summary>
#pragma warning disable CS8618
    public ContainerAgent()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// Type of agent, e.g., 'hosted'
    /// </summary>
    public override string Kind { get; set; } = "hosted";

    /// <summary>
    /// Protocol used by the containerized agent
    /// </summary>
    public IList<ProtocolVersionRecord> Protocols { get; set; } = [];

    /// <summary>
    /// Environment variables to set in the container
    /// </summary>
    public IList<EnvironmentVariable>? EnvironmentVariables { get; set; }


    public new void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type ContainerAgent");
        }

    }

    public new void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        emitter.Emit(new Scalar("protocols"));
        nestedObjectSerializer(Protocols);

        if (EnvironmentVariables != null)
        {
            emitter.Emit(new Scalar("environmentVariables"));
            nestedObjectSerializer(EnvironmentVariables);
        }

    }
}
