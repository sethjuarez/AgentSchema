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
[JsonConverter(typeof(McpServerToolAlwaysRequireApprovalModeJsonConverter))]
public class McpServerToolAlwaysRequireApprovalMode : McpServerApprovalMode, IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="McpServerToolAlwaysRequireApprovalMode"/>.
    /// </summary>
#pragma warning disable CS8618
    public McpServerToolAlwaysRequireApprovalMode()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// The kind identifier for always approval mode
    /// </summary>
    public override string Kind { get; set; } = "always";


    public new void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type McpServerToolAlwaysRequireApprovalMode");
        }

    }

    public new void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);
    }
}
