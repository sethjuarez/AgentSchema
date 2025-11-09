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
/// 
/// </summary>
[JsonConverter(typeof(AnonymousConnectionJsonConverter))]
public class AnonymousConnection : Connection, IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="AnonymousConnection"/>.
    /// </summary>
#pragma warning disable CS8618
    public AnonymousConnection()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// The Authentication kind for the AI service (e.g., 'key' for API key, 'oauth' for OAuth tokens)
    /// </summary>
    public override string Kind { get; set; } = "anonymous";

    /// <summary>
    /// The endpoint for authenticating with the AI service
    /// </summary>
    public string Endpoint { get; set; } = string.Empty;


    public new void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type AnonymousConnection");
        }

    }

    public new void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        emitter.Emit(new Scalar("endpoint"));
        nestedObjectSerializer(Endpoint);
    }
}
