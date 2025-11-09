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
/// Connection configuration for AI agents.
/// `provider`, `kind`, and `endpoint` are required properties here,
/// but this section can accept additional via options.
/// </summary>
[JsonConverter(typeof(ConnectionJsonConverter))]
public abstract class Connection : IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="Connection"/>.
    /// </summary>
#pragma warning disable CS8618
    protected Connection()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// The Authentication kind for the AI service (e.g., 'key' for API key, 'oauth' for OAuth tokens)
    /// </summary>
    public virtual string Kind { get; set; } = string.Empty;

    /// <summary>
    /// The authority level for the connection, indicating under whose authority the connection is made (e.g., 'user', 'agent', 'system')
    /// </summary>
    public string AuthenticationMode { get; set; } = "system";

    /// <summary>
    /// The usage description for the connection, providing context on how this connection will be used
    /// </summary>
    public string? UsageDescription { get; set; }


    public void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type Connection");
        }

        // handle polymorphic types
        if (node.Children.TryGetValue(new YamlScalarNode("kind"), out var discriminatorNode))
        {
            var discriminatorValue = (discriminatorNode as YamlScalarNode)?.Value;
            switch (discriminatorValue)
            {
                case "reference":
                    var referenceConnection = nestedObjectDeserializer(typeof(ReferenceConnection)) as ReferenceConnection;
                    if (referenceConnection == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type ReferenceConnection");
                    }
                    return;
                case "remote":
                    var remoteConnection = nestedObjectDeserializer(typeof(RemoteConnection)) as RemoteConnection;
                    if (remoteConnection == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type RemoteConnection");
                    }
                    return;
                case "key":
                    var keyConnection = nestedObjectDeserializer(typeof(ApiKeyConnection)) as ApiKeyConnection;
                    if (keyConnection == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type ApiKeyConnection");
                    }
                    return;
                case "anonymous":
                    var anonymousConnection = nestedObjectDeserializer(typeof(AnonymousConnection)) as AnonymousConnection;
                    if (anonymousConnection == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type AnonymousConnection");
                    }
                    return;
                default:
                    throw new YamlException($"Unknown type discriminator '' when parsing Connection");

            }
        }
    }

    public void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        emitter.Emit(new Scalar("authenticationMode"));
        nestedObjectSerializer(AuthenticationMode);

        if (UsageDescription != null)
        {
            emitter.Emit(new Scalar("usageDescription"));
            nestedObjectSerializer(UsageDescription);
        }

    }
}
