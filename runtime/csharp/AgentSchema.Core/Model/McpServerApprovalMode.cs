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
/// The approval mode for MCP server tools.
/// </summary>
[JsonConverter(typeof(McpServerApprovalModeJsonConverter))]
public abstract class McpServerApprovalMode : IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="McpServerApprovalMode"/>.
    /// </summary>
#pragma warning disable CS8618
    protected McpServerApprovalMode()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// The kind identifier for string approval modes
    /// </summary>
    public virtual string Kind { get; set; } = string.Empty;


    public void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {
        if (parser.TryConsume<Scalar>(out var scalar))
        {
            // check for non-numeric characters to differentiate strings from numbers
            if (scalar.Value.Length > 0 && scalar.Value.Any(c => !char.IsDigit(c) && c != '.' && c != '-'))
            {
                var stringValue = scalar.Value;
                Kind = stringValue;
                return;
            }
            else
            {
                throw new YamlException($"Unexpected scalar value '' when parsing McpServerApprovalMode. Expected one of the supported shorthand types or a mapping.");
            }
        }

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type McpServerApprovalMode");
        }

        // handle polymorphic types
        if (node.Children.TryGetValue(new YamlScalarNode("kind"), out var discriminatorNode))
        {
            var discriminatorValue = (discriminatorNode as YamlScalarNode)?.Value;
            switch (discriminatorValue)
            {
                case "always":
                    var alwaysMcpServerApprovalMode = nestedObjectDeserializer(typeof(McpServerToolAlwaysRequireApprovalMode)) as McpServerToolAlwaysRequireApprovalMode;
                    if (alwaysMcpServerApprovalMode == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type McpServerToolAlwaysRequireApprovalMode");
                    }
                    return;
                case "never":
                    var neverMcpServerApprovalMode = nestedObjectDeserializer(typeof(McpServerToolNeverRequireApprovalMode)) as McpServerToolNeverRequireApprovalMode;
                    if (neverMcpServerApprovalMode == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type McpServerToolNeverRequireApprovalMode");
                    }
                    return;
                case "specify":
                    var specifyMcpServerApprovalMode = nestedObjectDeserializer(typeof(McpServerToolSpecifyApprovalMode)) as McpServerToolSpecifyApprovalMode;
                    if (specifyMcpServerApprovalMode == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type McpServerToolSpecifyApprovalMode");
                    }
                    return;
                default:
                    throw new YamlException($"Unknown type discriminator '' when parsing McpServerApprovalMode");

            }
        }
    }

    public void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);
    }
}
