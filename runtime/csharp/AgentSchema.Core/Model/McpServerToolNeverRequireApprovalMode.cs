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
[JsonConverter(typeof(McpServerToolNeverRequireApprovalModeJsonConverter))]
public class McpServerToolNeverRequireApprovalMode : McpServerApprovalMode, IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="McpServerToolNeverRequireApprovalMode"/>.
    /// </summary>
#pragma warning disable CS8618
    public McpServerToolNeverRequireApprovalMode()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// The kind identifier for never approval mode
    /// </summary>
    public override string Kind { get; set; } = "never";


    public new void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type McpServerToolNeverRequireApprovalMode");
        }

    }

    public new void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);
    }
}
