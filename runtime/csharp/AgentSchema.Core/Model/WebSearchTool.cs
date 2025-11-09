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
/// The Bing search tool.
/// </summary>
[JsonConverter(typeof(WebSearchToolJsonConverter))]
public class WebSearchTool : Tool, IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="WebSearchTool"/>.
    /// </summary>
#pragma warning disable CS8618
    public WebSearchTool()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// The kind identifier for Bing search tools
    /// </summary>
    public override string Kind { get; set; } = "bing_search";

    /// <summary>
    /// The connection configuration for the Bing search tool
    /// </summary>
    public Connection Connection { get; set; }

    /// <summary>
    /// The configuration options for the Bing search tool
    /// </summary>
    public IDictionary<string, object>? Options { get; set; }


    public new void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type WebSearchTool");
        }

    }

    public new void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        emitter.Emit(new Scalar("connection"));
        nestedObjectSerializer(Connection);

        if (Options != null)
        {
            emitter.Emit(new Scalar("options"));
            nestedObjectSerializer(Options);
        }

    }
}
