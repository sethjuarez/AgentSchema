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
/// A tool for searching files.
/// This tool allows an AI agent to search for files based on a query.
/// </summary>
[JsonConverter(typeof(FileSearchToolJsonConverter))]
public class FileSearchTool : Tool, IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="FileSearchTool"/>.
    /// </summary>
#pragma warning disable CS8618
    public FileSearchTool()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// The kind identifier for file search tools
    /// </summary>
    public override string Kind { get; set; } = "file_search";

    /// <summary>
    /// The connection configuration for the file search tool
    /// </summary>
    public Connection Connection { get; set; }

    /// <summary>
    /// The IDs of the vector stores to search within.
    /// </summary>
    public IList<string> VectorStoreIds { get; set; } = [];

    /// <summary>
    /// The maximum number of search results to return.
    /// </summary>
    public int? MaximumResultCount { get; set; }

    /// <summary>
    /// File search ranker.
    /// </summary>
    public string? Ranker { get; set; }

    /// <summary>
    /// Ranker search threshold.
    /// </summary>
    public float? ScoreThreshold { get; set; }

    /// <summary>
    /// Additional filters to apply during the file search.
    /// </summary>
    public IDictionary<string, object>? Filters { get; set; }


    public new void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type FileSearchTool");
        }

    }

    public new void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        emitter.Emit(new Scalar("connection"));
        nestedObjectSerializer(Connection);

        emitter.Emit(new Scalar("vectorStoreIds"));
        nestedObjectSerializer(VectorStoreIds);

        if (MaximumResultCount != null)
        {
            emitter.Emit(new Scalar("maximumResultCount"));
            nestedObjectSerializer(MaximumResultCount);
        }


        if (Ranker != null)
        {
            emitter.Emit(new Scalar("ranker"));
            nestedObjectSerializer(Ranker);
        }


        if (ScoreThreshold != null)
        {
            emitter.Emit(new Scalar("scoreThreshold"));
            nestedObjectSerializer(ScoreThreshold);
        }


        if (Filters != null)
        {
            emitter.Emit(new Scalar("filters"));
            nestedObjectSerializer(Filters);
        }

    }
}
