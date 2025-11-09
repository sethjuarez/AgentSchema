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
/// Represents an object property.
/// This extends the base Property model to represent a structured object.
/// </summary>
[JsonConverter(typeof(ObjectPropertyJsonConverter))]
public class ObjectProperty : Property, IYamlConvertible
{
    /// <summary>
    /// Initializes a new instance of <see cref="ObjectProperty"/>.
    /// </summary>
#pragma warning disable CS8618
    public ObjectProperty()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// 
    /// </summary>
    public override string Kind { get; set; } = "object";

    /// <summary>
    /// The properties contained in the object
    /// </summary>
    public IList<Property> Properties { get; set; } = [];


    public new void Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
    {

        var node = nestedObjectDeserializer(typeof(YamlMappingNode)) as YamlMappingNode;
        if (node == null)
        {
            throw new YamlException("Expected a mapping node for type ObjectProperty");
        }

    }

    public new void Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
    {
        emitter.Emit(new MappingStart());

        emitter.Emit(new Scalar("kind"));
        nestedObjectSerializer(Kind);

        emitter.Emit(new Scalar("properties"));
        nestedObjectSerializer(Properties);
    }
}
