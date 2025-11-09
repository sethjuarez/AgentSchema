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
/// The MCP Server tool.
/// </summary>
[JsonConverter(typeof(McpToolJsonConverter))]
public class McpTool : Tool, IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="McpTool"/>.
    /// </summary>
#pragma warning disable CS8618
    public McpTool()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// The kind identifier for MCP tools
    /// </summary>
    public override string Kind { get; set; } = "mcp";

    /// <summary>
    /// The connection configuration for the MCP tool
    /// </summary>
    public Connection Connection { get; set; }

    /// <summary>
    /// The server name of the MCP tool
    /// </summary>
    public string ServerName { get; set; } = string.Empty;

    /// <summary>
    /// The description of the MCP tool
    /// </summary>
    public string? ServerDescription { get; set; }

    /// <summary>
    /// The approval mode for the MCP tool, either 'auto' or 'manual'
    /// </summary>
    public McpServerApprovalMode ApprovalMode { get; set; }

    /// <summary>
    /// List of allowed operations or resources for the MCP tool
    /// </summary>
    public IList<string>? AllowedTools { get; set; }


    public new void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type McpTool");
        }

    }

    public new void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        emitter.Emit(new Scalar("connection"));
        nestedObjectSerializer(Connection);

        emitter.Emit(new Scalar("serverName"));
        nestedObjectSerializer(ServerName);

        if (ServerDescription != null)
        {
            emitter.Emit(new Scalar("serverDescription"));
            nestedObjectSerializer(ServerDescription);
        }


        emitter.Emit(new Scalar("approvalMode"));
        nestedObjectSerializer(ApprovalMode);

        if (AllowedTools != null)
        {
            emitter.Emit(new Scalar("allowedTools"));
            nestedObjectSerializer(AllowedTools);
        }

    }
}
