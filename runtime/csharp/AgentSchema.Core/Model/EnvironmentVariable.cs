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
/// Definition for an environment variable used in containerized agents.
/// </summary>
[JsonConverter(typeof(EnvironmentVariableJsonConverter))]
public class EnvironmentVariable : IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="EnvironmentVariable"/>.
    /// </summary>
#pragma warning disable CS8618
    public EnvironmentVariable()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// Name of the environment variable
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Environment variable resolution
    /// </summary>
    public string Value { get; set; } = string.Empty;


    public void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type EnvironmentVariable");
        }

    }

    public void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("name"));
        nestedObjectSerializer(Name);

        emitter.Emit(new Scalar("value"));
        nestedObjectSerializer(Value);
    }
}
