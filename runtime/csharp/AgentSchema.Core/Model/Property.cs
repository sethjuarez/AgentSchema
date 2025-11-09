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
/// Represents a single property
/// * This model defines the structure of properties that can be used in prompts,
/// including their type, description, whether they are required, and other attributes.
/// * It allows for the definition of dynamic inputs that can be filled with data
/// and processed to generate prompts for AI models.
/// </summary>
[JsonConverter(typeof(PropertyJsonConverter))]
public class Property : IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="Property"/>.
    /// </summary>
#pragma warning disable CS8618
    public Property()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// Name of the property
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The data type of the input property
    /// </summary>
    public virtual string Kind { get; set; } = string.Empty;

    /// <summary>
    /// A short description of the input property
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Whether the property is required
    /// </summary>
    public bool? Required { get; set; }

    /// <summary>
    /// The default value of the property - this represents the default value if none is provided
    /// </summary>
    public object? Default { get; set; }

    /// <summary>
    /// Example value used for either initialization or tooling
    /// </summary>
    public object? Example { get; set; }

    /// <summary>
    /// Allowed enumeration values for the property
    /// </summary>
    public IList<object>? EnumValues { get; set; }


    public void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {
        if (parser.TryConsume<Scalar>(out var scalar))
        {
            if (scalar.Value.ToLower() == "true" || scalar.Value.ToLower() == "false")
            {
                var boolValue = scalar.Value.ToLower() == "true";
                Kind = "boolean";
                Example = boolValue;
                return;
            }
            // check for non-numeric characters to differentiate strings from numbers
            else if (scalar.Value.Length > 0 && scalar.Value.Any(c => !char.IsDigit(c) && c != '.' && c != '-'))
            {
                var stringValue = scalar.Value;
                Kind = "string";
                Example = stringValue;
                return;
            }
            else if (scalar.Value.Contains('.') || scalar.Value.Contains('e') || scalar.Value.Contains('E'))
            {
                // try parse as float
                if (float.TryParse(scalar.Value, out float floatValue))
                {
                    Kind = "float";
                    Example = floatValue;
                    return;
                }
            }
            else if (scalar.Value.All(c => char.IsDigit(c)))
            {
                // try parse as int
                if (int.TryParse(scalar.Value, out int intValue))
                {
                    Kind = "integer";
                    Example = intValue;
                    return;
                }
            }
            else
            {
                throw new YamlException($"Unexpected scalar value '' when parsing Property. Expected one of the supported shorthand types or a mapping.");
            }
        }

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type Property");
        }

        // handle polymorphic types
        if (node.Children.TryGetValue(new YamlScalarNode("kind"), out var discriminatorNode))
        {
            var discriminatorValue = (discriminatorNode as YamlScalarNode)?.Value;
            switch (discriminatorValue)
            {
                case "array":
                    var arrayProperty = nestedObjectDeserializer(typeof(ArrayProperty)) as ArrayProperty;
                    if (arrayProperty == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type ArrayProperty");
                    }
                    return;
                case "object":
                    var objectProperty = nestedObjectDeserializer(typeof(ObjectProperty)) as ObjectProperty;
                    if (objectProperty == null)
                    {
                        throw new YamlException("Failed to deserialize polymorphic type ObjectProperty");
                    }
                    return;
                default:
                    return;

            }
        }
    }

    public void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("name"));
        nestedObjectSerializer(Name);

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        if (Description != null)
        {
            emitter.Emit(new Scalar("description"));
            nestedObjectSerializer(Description);
        }


        if (Required != null)
        {
            emitter.Emit(new Scalar("required"));
            nestedObjectSerializer(Required);
        }


        if (Default != null)
        {
            emitter.Emit(new Scalar("default"));
            nestedObjectSerializer(Default);
        }


        if (Example != null)
        {
            emitter.Emit(new Scalar("example"));
            nestedObjectSerializer(Example);
        }


        if (EnumValues != null)
        {
            emitter.Emit(new Scalar("enumValues"));
            nestedObjectSerializer(EnumValues);
        }

    }
}
