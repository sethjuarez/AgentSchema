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
/// Prompt based agent definition. Used to create agents that can be executed directly.
/// These agents can leverage tools, input parameters, and templates to generate responses.
/// They are designed to be straightforward and easy to use for various applications.
/// </summary>
[JsonConverter(typeof(PromptAgentJsonConverter))]
public class PromptAgent : AgentDefinition, IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="PromptAgent"/>.
    /// </summary>
#pragma warning disable CS8618
    public PromptAgent()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// Type of agent, e.g., 'prompt'
    /// </summary>
    public override string Kind { get; set; } = "prompt";

    /// <summary>
    /// Primary AI model configuration for the agent
    /// </summary>
    public Model Model { get; set; }

    /// <summary>
    /// Tools available to the agent for extended functionality
    /// </summary>
    public IList<Tool>? Tools { get; set; }

    /// <summary>
    /// Template configuration for prompt rendering
    /// </summary>
    public Template? Template { get; set; }

    /// <summary>
    /// Give your agent clear directions on what to do and how to do it. Include specific tasks, their order, and any special instructions like tone or engagement style. (can use this for a pure yaml declaration or as content in the markdown format)
    /// </summary>
    public string? Instructions { get; set; }

    /// <summary>
    /// Additional instructions or context for the agent, can be used to provide extra guidance (can use this for a pure yaml declaration)
    /// </summary>
    public string? AdditionalInstructions { get; set; }


    public new void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type PromptAgent");
        }

    }

    public new void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        emitter.Emit(new Scalar("model"));
        nestedObjectSerializer(Model);

        if (Tools != null)
        {
            emitter.Emit(new Scalar("tools"));
            nestedObjectSerializer(Tools);
        }


        if (Template != null)
        {
            emitter.Emit(new Scalar("template"));
            nestedObjectSerializer(Template);
        }


        if (Instructions != null)
        {
            emitter.Emit(new Scalar("instructions"));
            nestedObjectSerializer(Instructions);
        }


        if (AdditionalInstructions != null)
        {
            emitter.Emit(new Scalar("additionalInstructions"));
            nestedObjectSerializer(AdditionalInstructions);
        }

    }
}
