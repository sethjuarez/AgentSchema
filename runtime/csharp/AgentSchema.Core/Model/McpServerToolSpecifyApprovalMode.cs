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
[JsonConverter(typeof(McpServerToolSpecifyApprovalModeJsonConverter))]
public class McpServerToolSpecifyApprovalMode : McpServerApprovalMode, IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="McpServerToolSpecifyApprovalMode"/>.
    /// </summary>
#pragma warning disable CS8618
    public McpServerToolSpecifyApprovalMode()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// The kind identifier for specify approval mode
    /// </summary>
    public override string Kind { get; set; } = "specify";

    /// <summary>
    /// List of tools that always require approval
    /// </summary>
    public IList<string> AlwaysRequireApprovalTools { get; set; } = [];

    /// <summary>
    /// List of tools that never require approval
    /// </summary>
    public IList<string> NeverRequireApprovalTools { get; set; } = [];


    public new void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type McpServerToolSpecifyApprovalMode");
        }

    }

    public new void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        emitter.Emit(new Scalar("alwaysRequireApprovalTools"));
        nestedObjectSerializer(AlwaysRequireApprovalTools);

        emitter.Emit(new Scalar("neverRequireApprovalTools"));
        nestedObjectSerializer(NeverRequireApprovalTools);
    }
}
