import { EmitContext, emitFile, resolvePath } from "@typespec/compiler";
import { EmitTarget, AgentSchemaEmitterOptions } from "./lib.js";
import { enumerateTypes, TypeNode } from "./ast.js";
import * as nunjucks from "nunjucks";
import formatXml, { XMLFormatterOptions } from 'xml-formatter';
import path from "path";

const csharpTypeMapper: Record<string, string> = {
  "string": "string",
  "number": "float",
  "array": "[]",
  "object": "object",
  "boolean": "bool",
  "int64": "long",
  "int32": "int",
  "float64": "double",
  "float32": "float",
  "integer": "int",
  "dictionary": "IDictionary<string, object>",
};

const jsonConverterMapper: Record<string, string> = {
  "string": "GetString",
  // this is smarter about numbers
  "number": "GetScalarValue",
  "unknown": "GetScalarValue",
  "boolean": "GetBoolean",
  "int64": "GetInt64",
  "int32": "GetInt32",
  "float64": "GetDouble",
  "float32": "GetSingle",
  "integer": "GetInt32",
};

const numberTypes = [
  "float32",
  "float64",
  "number",
  "int32",
  "int64",
  "numeric",
  "integer",
  "float",
]

export const generateBotDefinition = async (context: EmitContext<AgentSchemaEmitterOptions>, templateDir: string, node: TypeNode, emitTarget: EmitTarget) => {
  // set up template environment
  const templatePath = path.resolve(templateDir, 'botdefinition');
  const env = new nunjucks.Environment(new nunjucks.FileSystemLoader(templatePath));

  const definitionTemplate = env.getTemplate('definition.njk', true);
  const nodes = Array.from(enumerateTypes(node));

  const definition = renderDefinition(nodes, node, definitionTemplate);
  const f = formatXml as unknown as (definition: string, options: XMLFormatterOptions) => string;
  const content = f(definition, {
    indentation: "  ",
    lineSeparator: "\n",
    collapseContent: true,
  });
  await emitBotDefinitionFile(context, content, "AgentDefinition.xml", emitTarget["output-dir"]);
};


const renderDefinition = (nodes: TypeNode[], node: TypeNode, definitionTemplate: nunjucks.Template): string => {
  const definition = definitionTemplate.render({
    nodes: nodes,
  });

  return definition;
};

const emitBotDefinitionFile = async (context: EmitContext<AgentSchemaEmitterOptions>, contents: string, filename: string, outputDir?: string) => {
  outputDir = outputDir || `${context.emitterOutputDir}/definition`;
  //const typePath = type.typeName.namespace.split(".").map(part => typeLink(part));
  // replace typename with file
  //typePath.push(filename);
  const path = resolvePath(outputDir, filename);
  await emitFile(context.program, {
    path: resolvePath(path),
    content: contents,
  });
}
