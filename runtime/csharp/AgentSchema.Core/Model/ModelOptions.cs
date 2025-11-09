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
/// Options for configuring the behavior of the AI model.
/// `kind` is a required property here, but this section can accept additional via options.
/// </summary>
[JsonConverter(typeof(ModelOptionsJsonConverter))]
public class ModelOptions : IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="ModelOptions"/>.
    /// </summary>
#pragma warning disable CS8618
    public ModelOptions()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// The frequency penalty to apply to the model's output
    /// </summary>
    public float? FrequencyPenalty { get; set; }

    /// <summary>
    /// The maximum number of tokens to generate in the output
    /// </summary>
    public int? MaxOutputTokens { get; set; }

    /// <summary>
    /// The presence penalty to apply to the model's output
    /// </summary>
    public float? PresencePenalty { get; set; }

    /// <summary>
    /// A random seed for deterministic output
    /// </summary>
    public int? Seed { get; set; }

    /// <summary>
    /// The temperature to use for sampling
    /// </summary>
    public float? Temperature { get; set; }

    /// <summary>
    /// The top-K sampling value
    /// </summary>
    public int? TopK { get; set; }

    /// <summary>
    /// The top-P sampling value
    /// </summary>
    public float? TopP { get; set; }

    /// <summary>
    /// Stop sequences to end generation
    /// </summary>
    public IList<string>? StopSequences { get; set; }

    /// <summary>
    /// Whether to allow multiple tool calls in a single response
    /// </summary>
    public bool? AllowMultipleToolCalls { get; set; }

    /// <summary>
    /// Additional custom properties for model options
    /// </summary>
    public IDictionary<string, object>? AdditionalProperties { get; set; }


    public void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type ModelOptions");
        }

    }

    public void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        if (FrequencyPenalty != null)
        {
            emitter.Emit(new Scalar("frequencyPenalty"));
            nestedObjectSerializer(FrequencyPenalty);
        }


        if (MaxOutputTokens != null)
        {
            emitter.Emit(new Scalar("maxOutputTokens"));
            nestedObjectSerializer(MaxOutputTokens);
        }


        if (PresencePenalty != null)
        {
            emitter.Emit(new Scalar("presencePenalty"));
            nestedObjectSerializer(PresencePenalty);
        }


        if (Seed != null)
        {
            emitter.Emit(new Scalar("seed"));
            nestedObjectSerializer(Seed);
        }


        if (Temperature != null)
        {
            emitter.Emit(new Scalar("temperature"));
            nestedObjectSerializer(Temperature);
        }


        if (TopK != null)
        {
            emitter.Emit(new Scalar("topK"));
            nestedObjectSerializer(TopK);
        }


        if (TopP != null)
        {
            emitter.Emit(new Scalar("topP"));
            nestedObjectSerializer(TopP);
        }


        if (StopSequences != null)
        {
            emitter.Emit(new Scalar("stopSequences"));
            nestedObjectSerializer(StopSequences);
        }


        if (AllowMultipleToolCalls != null)
        {
            emitter.Emit(new Scalar("allowMultipleToolCalls"));
            nestedObjectSerializer(AllowMultipleToolCalls);
        }


        if (AdditionalProperties != null)
        {
            emitter.Emit(new Scalar("additionalProperties"));
            nestedObjectSerializer(AdditionalProperties);
        }

    }
}
